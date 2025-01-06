namespace FunTextLibrary.Models;
public class TranslatorModel
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string BaseUrl { get; set; } = "";

    public string? ApiKey { get; set; }
}
