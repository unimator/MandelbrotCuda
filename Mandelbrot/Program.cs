using System;
using System.Windows.Forms;

namespace Mandelbrot
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mandelbrotForm = new MandelbrotForm();
            Application.Run(mandelbrotForm);
        }
    }
}
