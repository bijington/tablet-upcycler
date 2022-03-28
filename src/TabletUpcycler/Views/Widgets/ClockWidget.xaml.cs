using TabletUpcycler.ViewModels.Widgets;

namespace TabletUpcycler.Views.Widgets;

public partial class ClockWidget
{
	public ClockWidget(ClockWidgetViewModel clockWidgetViewModel)
	{
		InitializeComponent();
		BindingContext = clockWidgetViewModel;
	}
}