using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class Corriger
{
    private string apiKey;

    public Corriger(string apiKey)
    {
        this.apiKey = apiKey;
    }

    public async Task<string> CorrectTextAsync(string textToCorrect)
    {
        string apiUrl = "https://api.openai.com/v1/engines/text-davinci-003/completions";

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            string prompt = $"Corrigez le texte suivant : '{textToCorrect}'";

            var requestContent = new
            {
                prompt,
                max_tokens = 50
            };

            string jsonContent = System.Text.Json.JsonSerializer.Serialize(requestContent);

            var response = await client.PostAsync(apiUrl, new StringContent(jsonContent, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return $"Erreur : {response.StatusCode}";
            }
        }
    }
}
