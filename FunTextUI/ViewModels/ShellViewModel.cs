namespace FunTextUI.ViewModels;
public partial class ShellViewModel : ObservableObject
{
    [ObservableProperty]
    private UserControl currentView;

    public ShellViewModel()
    {
        CurrentView = new TranslateView();
    }
}
