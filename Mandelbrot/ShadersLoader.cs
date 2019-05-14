using System;
using System.IO;
using OpenTK.Graphics.OpenGL;

namespace Mandelbrot
{
    public static class ShadersLoader
    {
        public static int LoadShaders(string vertexFilePath, string fragmentFilePath)
        {
            var programId = GL.CreateProgram();

            var vertexShaderProgram = File.ReadAllText(vertexFilePath);
            var fragmentShaderProgram = File.ReadAllText(fragmentFilePath);

            var vertexShaderId = GL.CreateShader(ShaderType.VertexShader);
            var fragmentShaderId = GL.CreateShader(ShaderType.FragmentShader);
            
            GL.ShaderSource(vertexShaderId, vertexShaderProgram);
            GL.CompileShader(vertexShaderId);

            var log = GL.GetShaderInfoLog(vertexShaderId);

            if (!string.IsNullOrEmpty(log))
            {
                throw new Exception(log);
            }

            GL.ShaderSource(fragmentShaderId, fragmentShaderProgram);
            GL.CompileShader(fragmentShaderId);

            log = GL.GetShaderInfoLog(fragmentShaderId);

            if (!string.IsNullOrEmpty(log))
            {
                throw new Exception(log);
            }

            GL.AttachShader(programId, vertexShaderId);
            GL.AttachShader(programId, fragmentShaderId);

            GL.LinkProgram(programId);

            GL.DetachShader(programId, vertexShaderId);
            GL.DetachShader(programId, fragmentShaderId);

            GL.DeleteShader(vertexShaderId);
            GL.DeleteShader(fragmentShaderId);

            return programId;
        }
    }
}