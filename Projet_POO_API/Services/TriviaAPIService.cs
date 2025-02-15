using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using System.Net;

namespace Projet_POO_API.Services;

public class TriviaAPIService
{
    private readonly HttpClient _httpClient;
    public string SetupUrl { get; set; }

    public TriviaAPIService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Question>> GetQuizAsync()
    {
        var response = await _httpClient.GetAsync(SetupUrl);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var result =
            JsonSerializer.Deserialize<QuizResponse>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return result?.Results ?? new List<Question>();
    }
    
    public async Task<List<Categorie>> GetCategoriesAsync()
    {
        var response = await _httpClient.GetAsync("https://opentdb.com/api_category.php");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var resultat = JsonSerializer.Deserialize<CategoryResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return resultat?.Categories ?? new List<Categorie>();
    }

    public void GenererUrl(string categorie, string difficulte, string type)
    {
       SetupUrl = $"https://opentdb.com/api.php?amount=10&category={categorie}&difficulty={difficulte}&type={type}";
    }
}
