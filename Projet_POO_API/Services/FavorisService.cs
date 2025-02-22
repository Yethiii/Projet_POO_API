
using System.Net.NetworkInformation;
using Microsoft.JSInterop;

namespace Projet_POO_API.Services;

public class FavorisService
{
    private readonly IJSRuntime _jsRuntime;
    
    public FavorisService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<List<string>> ReccupererFavoris()
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem","macle","mesvaleurs");
        // envoie mes données
        var result = await _jsRuntime.InvokeAsync<string>("localStorage.setItem","macle","mesvaleurs");
        //réccupère mes données
        
        //Serialiser JAVAS
    }
}