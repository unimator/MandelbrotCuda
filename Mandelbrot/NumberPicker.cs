using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class NumberPicker : UserControl
    {
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public string LabelText
        {
            get => lblText.Text;
            set => lblText.Text = value;
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public double Value
        {
            get => double.TryParse(mtbNumber.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var result) 
                ? result : double.NaN;
            set => mtbNumber.Text = value.ToString(CultureInfo.InvariantCulture);
        }

        public delegate void OnNumberChange();

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public OnNumberChange OnIncrease;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public OnNumberChange OnDecrease;

        public NumberPicker()
        {
            InitializeComponent();
        }

        private void btnInc_Click(object sender, EventArgs e)
        {
            OnIncrease?.Invoke();
        }

        private void btnDec_Click(object sender, EventArgs e)
        {
            OnDecrease?.Invoke();
        }
    }
}
