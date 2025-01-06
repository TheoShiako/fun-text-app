namespace FunTextLibrary.DataAccess;
public class ApiAccess
{
    private static HttpClient InitializeClient(string url)
    {
        var client = new HttpClient() { BaseAddress = new Uri(url) };
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return client;
    }

    //Method to translate search text
    public static async Task<string> Translate(string searchText, string apiAddress)
    {
        using var client = InitializeClient(apiAddress);
        var response = await client.GetAsync($@"?text=" + searchText);
        if (response.IsSuccessStatusCode)
        {
            SearchResponseModel? searchResponse = await response.Content.ReadFromJsonAsync<SearchResponseModel>();
            var translatedText = searchResponse?.Contents.Translated!;

            return translatedText;
        }
        else
        {
            var error = await response.Content.ReadFromJsonAsync<SearchErrorModel>();

            var errorMessage = error?.Error.Message;

            throw new Exception(errorMessage);
        }
    }
}
