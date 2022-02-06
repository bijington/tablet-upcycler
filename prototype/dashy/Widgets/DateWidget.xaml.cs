using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace dashy.Widgets
{
    public partial class DateWidget
    {
        public DateTime DateTime => DateTime.Now;

        public DateWidget()
        {
            InitializeComponent();
            this.BindingContext = this;

            Device.StartTimer(
                TimeSpan.FromSeconds(1),
                () =>
                {
                    this.OnPropertyChanged(nameof(DateTime));
                    return true;
                }
            );
        }
    }
}
