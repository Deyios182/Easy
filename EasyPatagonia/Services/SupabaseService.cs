using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EasyPatagonia.Models;
namespace EasyPatagonia.Services
{
    public class SupabaseService
    {
        private const string SupabaseUrl = "https://zvvlwpujvjttmwgcnlyk.supabase.co";
        private const string AnonKey = "sb_publishable_mnaYZsNg6wP-GSGtDad96A_KNyXN1wU";
        private readonly HttpClient _httpClient;
        public SupabaseService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("apikey", AnonKey);
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + AnonKey);
        }
        public async Task<List<Empresa>> ListarEmpresasAsync()
        {
            try {
                var response = await _httpClient.GetStringAsync(SupabaseUrl + "/rest/v1/companies?select=*");
                return JsonConvert.DeserializeObject<List<Empresa>>(response);
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return new List<Empresa>();
            }
        }
        public async Task<List<Actividad>> ListarTodasActividadesAsync()
        {
            try {
                var response = await _httpClient.GetStringAsync(SupabaseUrl + "/rest/v1/services?select=*");
                return JsonConvert.DeserializeObject<List<Actividad>>(response);
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return new List<Actividad>();
            }
        }
    }
}
