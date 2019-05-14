using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace Mandelbrot
{
    public partial class MandelbrotForm : Form
    {
        private int _vertexBufferId;
        
        private readonly List<Vector2> _vertexBufferData = new List<Vector2>
        {
            new Vector2(-1, -1),
            new Vector2(1, -1),
            new Vector2(1, 1),

            new Vector2(-1, -1),
            new Vector2(-1, 1),
            new Vector2(1, 1)
        };

        private int _uvBufferId;

        private readonly List<Vector2> _uvBufferData = new List<Vector2>
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),

            new Vector2(0, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };

        private readonly string ShadersDir = "Shaders";
        private readonly string FragmentShader = "Mandelbrot.fragmentshader";
        private readonly string VertexShader = "Mandelbrot.vertexshader";

        private int _shadersProgramId;

        private int _textureId;
        private int _uniformIdTextureSampler;
        private readonly string UniformNameTextureSampler = "TextureSampler";

        private int _uniformIdMaxIterations;
        private readonly string UniformNameMaxIterations = "MaxIterations";

        private int[] _data;

        private int _maxIterations;

        private BackgroundWorker _bwSetCalculator = new BackgroundWorker();

        public Section DataSection
        {
            get => sectionBindingSource.DataSource as Section;
            set
            {
                if (DataSection != null)
                {
                    // ReSharper disable DelegateSubtraction
                    npRe.OnIncrease -= DataSection.IncreaseRe;
                    npRe.OnDecrease -= DataSection.DecreaseRe;

                    npIm.OnIncrease -= DataSection.IncreaseIm;
                    npIm.OnDecrease -= DataSection.DecreaseIm;

                    npWidth.OnIncrease -= DataSection.IncreaseWidth;
                    npWidth.OnDecrease -= DataSection.DecreaseWidth;

                    npHeight.OnIncrease -= DataSection.IncreaseHeight;
                    npHeight.OnDecrease -= DataSection.DecreaseHeight;
                    // ReSharper enable DelegateSubtraction
                }

                sectionBindingSource.DataSource = value;

                if (DataSection != null)
                {
                    npRe.OnIncrease += DataSection.IncreaseRe;
                    npRe.OnDecrease += DataSection.DecreaseRe;

                    npIm.OnIncrease += DataSection.IncreaseIm;
                    npIm.OnDecrease += DataSection.DecreaseIm;

                    npWidth.OnIncrease += DataSection.IncreaseWidth;
                    npWidth.OnDecrease += DataSection.DecreaseWidth;

                    npHeight.OnIncrease += DataSection.IncreaseHeight;
                    npHeight.OnDecrease += DataSection.DecreaseHeight;
                }
            }
        }

        [DllImport(@"Mandelbrot.Core.dll", CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "CalculateMandelbrotDouble")]
        public static extern IntPtr CalculateMandelbrotDouble(double re, double im, double scale_x, double scale_y,
            int width, int height, int maxIterations);

        [DllImport(@"Mandelbrot.Core.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "FreeMemory")]
        public static extern void FreeMemory(IntPtr ptr);

        public MandelbrotForm()
        {
            InitializeComponent();
            DataSection = new Section {Re = 0.0f, Im = 0.0f, Height = 2.0f, Width = 2.0f};
            _maxIterations = tbNumOfIters.Value;
            txtIterations.Text = tbNumOfIters.Value.ToString();
            npRe.OnIncrease += RedrawIfAutoRedraw;
            npRe.OnDecrease += RedrawIfAutoRedraw;
            npIm.OnIncrease += RedrawIfAutoRedraw;
            npIm.OnDecrease += RedrawIfAutoRedraw;
            npWidth.OnIncrease += RedrawIfAutoRedraw;
            npWidth.OnDecrease += RedrawIfAutoRedraw;
            npHeight.OnIncrease += RedrawIfAutoRedraw;
            npHeight.OnDecrease += RedrawIfAutoRedraw;
            
            _bwSetCalculator.DoWork += (sender, args) => { RedrawInternal(); };
            _bwSetCalculator.RunWorkerCompleted += (sender, args) =>
            {
                glRenderPanel.Invalidate();
            };
        }

        private void btnRedraw_Click(object sender, EventArgs e)
        {
            Redraw();
        }

        private void glRenderPanel_Load(object sender, EventArgs e)
        {
            glRenderPanel.MakeCurrent();

            var vertexShaderFilePath = Path.Combine(ShadersDir, VertexShader);
            var fragmentShaderFilePath = Path.Combine(ShadersDir, FragmentShader);

            _shadersProgramId = ShadersLoader.LoadShaders(vertexShaderFilePath, fragmentShaderFilePath);

            _textureId = GL.GenTexture();

            _uniformIdMaxIterations = GL.GetUniformLocation(_shadersProgramId, UniformNameMaxIterations);
            _uniformIdTextureSampler = GL.GetUniformLocation(_shadersProgramId, UniformNameTextureSampler);

            _vertexBufferId = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferId);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertexBufferData.Count * Vector2.SizeInBytes,
                _vertexBufferData.ToArray(), BufferUsageHint.StaticDraw);

            _uvBufferId = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _uvBufferId);
            GL.BufferData(BufferTarget.ArrayBuffer, _uvBufferData.Count * Vector2.SizeInBytes, _uvBufferData.ToArray(),
                BufferUsageHint.StaticDraw);
        }

        private void glRenderPanel_Paint(object sender, PaintEventArgs e)
        {
            glRenderPanel.MakeCurrent();

            GL.UseProgram(_shadersProgramId);

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, _textureId);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, glRenderPanel.Width,
                glRenderPanel.Height, 0, PixelFormat.Rgba, PixelType.Byte, _data);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int) TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int) TextureWrapMode.Repeat);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
                (int) TextureMinFilter.LinearMipmapLinear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
                (int) TextureMagFilter.Linear);

            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            var errorCode = GL.GetError();
            Console.WriteLine(errorCode);
            GL.Uniform1(_uniformIdTextureSampler, 0);

            GL.Uniform1(_uniformIdMaxIterations, _maxIterations);

            GL.ClearColor(Color.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.EnableVertexAttribArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferId);
            GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 0, IntPtr.Zero);

            GL.EnableVertexAttribArray(1);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _uvBufferId);
            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 0, IntPtr.Zero);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 3 * 2);

            glRenderPanel.SwapBuffers();
        }

        private void MandelbrotForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GL.DeleteProgram(_shadersProgramId);
            GL.DeleteBuffer(_vertexBufferId);
            GL.DeleteBuffer(_uvBufferId);
        }

        private void RedrawIfAutoRedraw()
        {
            if (cbAutoRedraw.Checked)
            {
                Redraw();
            }
        }

        private void Redraw()
        {
            if (!_bwSetCalculator.IsBusy)
            {
                _bwSetCalculator.RunWorkerAsync();
            }
        }

        private void RedrawInternal()
        {
            var result = CalculateMandelbrotDouble(DataSection.Re, DataSection.Im, DataSection.Width,
                DataSection.Height, glRenderPanel.Width, glRenderPanel.Height, _maxIterations);
            _data = new int[glRenderPanel.Width * glRenderPanel.Height];
            Marshal.Copy(result, _data, 0, glRenderPanel.Width * glRenderPanel.Height);

            FreeMemory(result);
        }

        private void tbNumOfIters_Scroll(object sender, EventArgs e)
        {
            _maxIterations = tbNumOfIters.Value;
            txtIterations.Text = tbNumOfIters.Value.ToString();

            RedrawIfAutoRedraw();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            DataSection.IncreaseIm();
            RedrawIfAutoRedraw();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            DataSection.DecreaseIm();
            RedrawIfAutoRedraw();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            DataSection.DecreaseRe();
            RedrawIfAutoRedraw();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            DataSection.IncreaseRe();
            RedrawIfAutoRedraw();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            DataSection.DecreaseWidth();
            DataSection.DecreaseHeight();
            RedrawIfAutoRedraw();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            DataSection.IncreaseWidth();
            DataSection.IncreaseHeight();
            RedrawIfAutoRedraw();
        }
    }
}