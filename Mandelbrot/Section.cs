using System.ComponentModel;
using System.Runtime.CompilerServices;
using Mandelbrot.Annotations;

namespace Mandelbrot
{
    public class Section : INotifyPropertyChanged
    {
        private static double ChangeOffset = 0.2f;

        private double _re;
        private double _im;
        private double _width;
        private double _height;

        public double Re
        {
            get => _re;
            set
            {
                if (value.Equals(_re)) return;
                _re = value;
                OnPropertyChanged();
            }
        }

        public double Im
        {
            get => _im;
            set
            {
                if (value.Equals(_im)) return;
                _im = value;
                OnPropertyChanged();
            }
        }

        public double Width
        {
            get => _width;
            set
            {
                if (value.Equals(_width)) return;
                _width = value;
                OnPropertyChanged();
            }
        }

        public double Height
        {
            get => _height;
            set
            {
                if (value.Equals(_height)) return;
                _height = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void IncreaseRe()
        {
            Re += Width * ChangeOffset;
        }

        public void DecreaseRe()
        {
            Re -= Width * ChangeOffset;
        }

        public void IncreaseIm()
        {
            Im += Height * ChangeOffset;
        }

        public void DecreaseIm()
        {
            Im -= Height * ChangeOffset;
        }

        public void IncreaseWidth()
        {
            Width += Width * ChangeOffset;
        }

        public void DecreaseWidth()
        {
            Width -= Width * ChangeOffset;
        }

        public void IncreaseHeight()
        {
            Height += Height * ChangeOffset;
        }

        public void DecreaseHeight()
        {
            Height -= Height * ChangeOffset;
        }
    }
}