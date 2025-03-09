
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text.Json;
using Microsoft.JSInterop;

namespace Projet_POO_API.Services;

public class FavorisService
{
    private readonly IJSRuntime _jsRuntime; //pour interagir avec LocalStorage
    
    public FavorisService(IJSRuntime jsRuntime) 
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<List<FavorisQuizz>> RecupererFavoris()
    {
        var result = await _jsRuntime.InvokeAsync<string>("localStorage.getItem","Favoris"); //Récupère la liste des favoris de JSON
        return string.IsNullOrEmpty(result) ? new List<FavorisQuizz>(): JsonSerializer.Deserialize<List<FavorisQuizz>>(result);
        //si pas vide, déserialise en une liste d'objets
    }
    
    public async Task AjouterAuxFavoris(FavorisQuizz NouveauFavori)    
    {
        var listFavoris = await RecupererFavoris();
        if (!listFavoris.Any(favori => favori.Categorie == NouveauFavori.Categorie &&
                             favori.Difficulte == NouveauFavori.Difficulte &&
                             favori.Type == NouveauFavori.Type))
        {
            listFavoris.Add(NouveauFavori);
            var SerializeFavoris = JsonSerializer.Serialize(listFavoris); //Convertir en JSON
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "Favoris", SerializeFavoris); //Stock dans LocalStorage
        }
    }

    public async Task SupprimerFavoris(FavorisQuizz FavoriASupprimer)
    {
        var listFavoris = await RecupererFavoris();
        listFavoris = listFavoris.Where(favori => 
            favori.Categorie != FavoriASupprimer.Categorie || 
            favori.Difficulte != FavoriASupprimer.Difficulte || 
            favori.Type != FavoriASupprimer.Type).ToList();
        //Where garde uniquement les quiz différents de celui à supprimer
        
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