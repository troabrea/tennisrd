using System.Net;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Supabase.Functions;
using TennisRD.Dtos;

namespace TennisRD.Services;

public class DatabaseService
{
    private readonly Supabase.Client _client;
	private readonly AuthenticationStateProvider _customAuthStateProvider;
	private readonly ILocalStorageService _localStorage;
	private readonly ILogger<DatabaseService> _logger;
    private readonly Blazorise.IMessageService _dialogService;

    public DatabaseService(
        Supabase.Client client,
        AuthenticationStateProvider customAuthStateProvider,
        ILocalStorageService localStorage,
        ILogger<DatabaseService> logger,
        Blazorise.IMessageService dialogService)
    {
        logger.LogInformation("------------------- CONSTRUCTOR -------------------");

        _client = client;
        _customAuthStateProvider = customAuthStateProvider;
        _localStorage = localStorage;
        _logger = logger;
        _dialogService = dialogService;
    }

    public Supabase.Client Client => _client;
    
    public async Task<IReadOnlyList<TModel>> From<TModel>() where TModel : BaseModelApp, new()
	{
		var modeledResponse = await _client
			.From<TModel>()
			.Get();
		return modeledResponse.Models;
	}

	public async Task<List<TModel>> Delete<TModel>(TModel item) where TModel : BaseModelApp, new()
	{
		var modeledResponse = await _client
			.From<TModel>()
			.Delete(item);
		return modeledResponse.Models;
	}

	public async Task<List<TModel>?> Insert<TModel>(TModel item) where TModel : BaseModelApp, new()
	{
		Postgrest.Responses.ModeledResponse<TModel> modeledResponse;
		try
		{
			modeledResponse = await _client
				.From<TModel>()
				.Insert(item);			
			
			return modeledResponse.Models;
		}
		catch (Client.RequestException ex)
		{
			if(ex.Response?.StatusCode == HttpStatusCode.Forbidden)
				await _dialogService.Warning(
					"Warning",
					"This database resquest was forbidden."
				);
			else		
				await _dialogService.Warning(
					"Warning",
					"This request was not completed because of some problem with the http request. \n "
					+ex.Response?.RequestMessage
				);
		}
		
		return null;		
	}

	
}