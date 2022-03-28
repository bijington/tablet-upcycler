using Microsoft.Maui.Dispatching;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace TabletUpcycler.ViewModels.Widgets;

public class ClockWidgetViewModel : ObservableObject
{
	readonly IDispatcher dispatcher;

    public DateTime Time => DateTime.Now;

    public ClockWidgetViewModel(IDispatcher dispatcher)
    {
        this.dispatcher = dispatcher;

        this.dispatcher.StartTimer(
            TimeSpan.FromSeconds(1),
            () =>
            {
                this.OnPropertyChanged(nameof(Time));
                return true;
            });
    }
}
