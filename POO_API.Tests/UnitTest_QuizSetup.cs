using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components;
using Projet_POO_API.Pages;
using Projet_POO_API.Services;

namespace POO_API.Tests;

using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Moq;
using Microsoft.JSInterop;
using Projet_POO_API.Services;
using Xunit;

public class QuizSetupTests
{
    [Fact]
    public async Task StartQuizTest()
    {
        var mockTriviaAPIService = new Mock<TriviaAPIService>();
       //Pas fini
    }

}