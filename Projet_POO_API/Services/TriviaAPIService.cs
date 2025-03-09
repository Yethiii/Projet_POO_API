using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using System.Net;

namespace Projet_POO_API.Services;

public class TriviaAPIService
{
    private readonly HttpClient _httpClient; //HttpClient effectue des requêtes HTTP vers l’API
    public string SetupUrl { get; set; }

    public TriviaAPIService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Question>> GetQuizAsync()
    {
        var response = await _httpClient.GetAsync(SetupUrl); //Reccupère le quizz dans l'API
        response.EnsureSuccessStatusCode(); //Verifie si la reqsuète à fonctionné

        var json = await response.Content.ReadAsStringAsync(); //Converti en chaine de caractères
        var result =
            JsonSerializer.Deserialize<QuizResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }); //permet d’ignorer la casse des noms

        return result?.Results ?? new List<Question>(); //Retourne une liste de questions sauf si vide
    }
    
    public async Task<List<Categorie>> GetCategoriesAsync()
    {
        var response = await _httpClient.GetAsync("https://opentdb.com/api_category.php");
        response.EnsureSuccessStatusCode(); //Verifie si la reqsuète à fonctionné

        var json = await response.Content.ReadAsStringAsync(); //Converti en chaine de caractères
        var resultat = JsonSerializer.Deserialize<CategoryResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }); //permet d’ignorer la casse des noms

        return resultat?.Categories ?? new List<Categorie>(); //Retourne une liste de catégories sauf si vide
    }

    public void GenererUrl(string categorie, string difficulte, string type)
    {
       SetupUrl = $"https://opentdb.com/api.php?amount=10&category={categorie}&difficulty={difficulte}&type={type}";
    }
}
