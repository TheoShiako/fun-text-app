namespace FunTextUI.Views;
/// <summary>
/// Interaction logic for TranslateView.xaml
/// </summary>
public partial class TranslateView : UserControl
{
    public TranslateView()
    {
        InitializeComponent();
        DataContext = new TranslateViewModel();
    }
}
