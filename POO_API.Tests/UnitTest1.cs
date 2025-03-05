using System.Runtime.CompilerServices;
using Projet_POO_API.Services;

namespace POO_API.Tests;

using Xunit;
using Projet_POO_API;

public class TriviaAPIServiceTests
{
    [Fact]
    public void GenererUrlTest()
    {
        var connexion = new TriviaAPIService(new HttpClient());
        
        connexion.GenererUrl("1", "easy", "multiple");
        
        Assert.Equal("https://opentdb.com/api.php?amount=10&category=1&difficulty=easy&type=multiple", connexion.SetupUrl);
    }

    [Fact]

    public async Task GetCategoriesTest()
    {
        var httpClient = new HttpClient();
        var service = new TriviaAPIService(httpClient);
        
        var categories = await service.GetCategoriesAsync();
        
        Assert.NotNull(categories);
        Assert.NotEmpty(categories);
        
    }
    
    [Fact]
    public async Task GetQuizTest()
    {
        var httpClient = new HttpClient();
        var service = new TriviaAPIService(httpClient);
        
       service.GenererUrl("9", "easy", "multiple");
       var quiz = await service.GetQuizAsync(); 
       
        Assert.NotNull(quiz);
        Assert.NotEmpty(quiz);
    }
}