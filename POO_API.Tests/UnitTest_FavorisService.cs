using System.Runtime.CompilerServices;
using Projet_POO_API.Services;

namespace POO_API.Tests;

using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Moq;
using Microsoft.JSInterop;
using Projet_POO_API.Services;
using Xunit;

public class FavorisServiceTests
{
    [Fact]
    public async Task RecupererFavorisTest()
    {
        var mockJsRuntime = new Mock<IJSRuntime>();  // Simule IJSRuntime
        mockJsRuntime
            .Setup(js => js.InvokeAsync<string>("localStorage.getItem", It.IsAny<object[]>()))
            .ReturnsAsync("");  // Simule un localStorage vide
        
        //Setup(...) "Quand localStorage.getItem("Favoris") est appelé, retourne une chaîne vide"

        var service = new FavorisService(mockJsRuntime.Object); //crée un FavorisService avec le faux LocalStoragee.
        
        var resultat = await service.RecupererFavoris();
        
        Assert.NotNull(resultat);
        Assert.Empty(resultat);
    }

    [Fact]

    public async Task AjouterFavorisTest()
    {
        var mockJsRuntime = new Mock<IJSRuntime>(); 
        mockJsRuntime
            .Setup(js => js.InvokeAsync<string>("localStorage.getItem", It.IsAny<object[]>()))
            .ReturnsAsync("");  
        
        var service = new FavorisService(mockJsRuntime.Object);

        var NouveauFavoris = new FavorisService.FavorisQuizz
        {
            Categorie = "Science", Difficulte = "easy", Type = "multiple", Questions = new List<FavorisService.Question>
            {
                new FavorisService.Question { Texte = "Quelle est ce type de Quiz ?", ReponseCorrecte = "multiple" }
            }
        };
        await service.AjouterAuxFavoris(NouveauFavoris);
        
        mockJsRuntime.Verify(js => js.InvokeAsync<object>(
            "localStorage.setItem",
            It.IsAny<object[]>()
        ), Times.Once);
        //permet de vérifier que localStorage.setItem a été appelé 
        
    }

   // [Fact]

   // public async Task SupprimerFavorisTest()
    //{ }
}