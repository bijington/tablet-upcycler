using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace dashy.Widgets
{
    public partial class ClockWidget
    {
        public DateTime Time => DateTime.Now;

        public ClockWidget()
        {
            InitializeComponent();
            this.BindingContext = this;

            Device.StartTimer(
                TimeSpan.FromSeconds(1),
                () =>
                {
                    this.OnPropertyChanged(nameof(Time));
                    return true;
                }
            );
        }
    }
}
