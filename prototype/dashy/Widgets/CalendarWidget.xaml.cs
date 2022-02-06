using System;
using System.Collections.ObjectModel;

namespace dashy.Widgets
{
    public partial class CalendarWidget
    {
        public ObservableCollection<CalendarItem> CalendarItems { get; } = new ObservableCollection<CalendarItem>();

        public double ItemHeight { get; set; } = 25;

        public CalendarWidget()
        {
            InitializeComponent();

            this.BindingContext = this;

            var currentMonthIndex = DateTime.Today.Month;
            var currentDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            for (int i = (int)currentDate.DayOfWeek; i > 0; i--)
            {
                CalendarItems.Add(new CalendarItem());
            }

            while (currentDate.Month == currentMonthIndex)
            {
                CalendarItems.Add(new CalendarItem { Name = $"{currentDate.Day}", IsToday = currentDate.Day == DateTime.Today.Day });

                currentDate = currentDate.AddDays(1);
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (height == -1)
            {
                return;
            }

            var numberOfRows = Math.Ceiling((double)CalendarItems.Count / 7) + 1;
            ItemHeight = height / numberOfRows;
            OnPropertyChanged(nameof(ItemHeight));
        }
    }

    public class CalendarItem
    {
        public string Name { get; set; }

        public bool IsToday { get; set; }
    }
}
