﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_FormationMobile.Tools
{
    public class ApiRequester
    {
        private string _baseAddress;

        private HttpClient _client;

        public HttpClient Client
        {
            get { return _client; }
        }


        public ApiRequester(string baseAdress = null)
        {
            _client = new HttpClient();
            if (!(baseAdress is null))
            {
                _baseAddress = baseAdress;
                _client.BaseAddress = new Uri(_baseAddress);
            }
            
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<TResult> Get<TResult>(string url, string token = null)
        {
            if (token != null)
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using (HttpResponseMessage message = await _client.GetAsync(url))
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                string json = await message.Content.ReadAsStringAsync();


                return JsonConvert.DeserializeObject<TResult>(json);
            }
        }

        public async void Post<TEntity>(string url, TEntity entity, string token = null)
        {
            if (token != null)
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            string json = JsonConvert.SerializeObject(entity);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpResponseMessage message = await _client.PostAsync(url, content))
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }
            }
        }

        public async void Delete(string url, int id, string token = null)
        {
            if (token != null)
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using (HttpResponseMessage message = await _client.DeleteAsync(url + id))
            {
                if (!message.IsSuccessStatusCode)
                    throw new HttpRequestException();
            }
        }

        public async void Update<TEntity>(string url, int id, TEntity entity, string token = null)
        {

            if (token != null)
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            string json = JsonConvert.SerializeObject(entity);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpResponseMessage message = await _client.PutAsync(url + id, content))
            {
                if (!message.IsSuccessStatusCode)
                    throw new HttpRequestException();
            }
        }
    }
}
