namespace FunTextUI.ViewModels;
public partial class TranslateViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(GetTranslationCommand))]
    private string searchText = "";

    [ObservableProperty]
    private string? translatedText;

    [ObservableProperty]
    private IEnumerable<TranslatorModel> translators = [];

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(GetTranslationCommand))]
    private TranslatorModel? selectedTranslator;

    public bool CanTranslate => SelectedTranslator != null && string.IsNullOrWhiteSpace(SearchText) is false;

    public TranslateViewModel()
    {
        InitialiseTranslators();
    }

    private void InitialiseTranslators()
    {
        Translators = [new() { Name = "Leetspeak", BaseUrl = "https://api.funtranslations.com/translate/leetspeak.json" }];
    }

    [RelayCommand(CanExecute = nameof(CanTranslate))]
    private async Task GetTranslation()
    {
        try
        {
            TranslatedText = await ApiAccess.Translate(SearchText, SelectedTranslator!.BaseUrl);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error translating text.\n{ex.Message}");
        }
    }
}
