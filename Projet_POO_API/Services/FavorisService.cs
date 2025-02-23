
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text.Json;
using Microsoft.JSInterop;

namespace Projet_POO_API.Services;

public class FavorisService
{
    private readonly IJSRuntime _jsRuntime;
    
    public FavorisService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<List<FavorisQuizz>> RecupererFavoris()
    {
        var result = await _jsRuntime.InvokeAsync<string>("localStorage.getItem","Favoris");
        return string.IsNullOrEmpty(result) ? new List<FavorisQuizz>(): JsonSerializer.Deserialize<List<FavorisQuizz>>(result);
    }
    
    public async Task AjouterAuxFavoris(FavorisQuizz NouveauFavori)    
    {
        var listFavoris = await RecupererFavoris();
        if (!listFavoris.Any(favori => favori.Categorie == NouveauFavori.Categorie &&
                             favori.Difficulte == NouveauFavori.Difficulte &&
                             favori.Type == NouveauFavori.Type))
        {
            listFavoris.Add(NouveauFavori);
            var SerializeFavoris = JsonSerializer.Serialize(listFavoris);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "Favoris", SerializeFavoris);
        }
    }

    public async Task SupprimerFavoris(FavorisQuizz FavoriASupprimer)
    {
        var listFavoris = await RecupererFavoris();
        listFavoris = listFavoris.Where(favori => 
            favori.Categorie != FavoriASupprimer.Categorie || 
            favori.Difficulte != FavoriASupprimer.Difficulte || 
            favori.Type != FavoriASupprimer.Type).ToList();
        
        var SerializeFavoris = JsonSerializer.Serialize(listFavoris);   
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "Favoris", SerializeFavoris);
    }
    
    public class FavorisQuizz
    {
        public string Categorie { get; set; }
        public string Difficulte { get; set; }
        public string Type { get; set; }
        public List<Question> Questions { get; set; } = new();
    }
    public class Question
    {
        public string Texte { get; set; }
        public string ReponseCorrecte { get; set; }
        public List<string> ReponsesIncorrectes { get; set; } = new();
    }
}