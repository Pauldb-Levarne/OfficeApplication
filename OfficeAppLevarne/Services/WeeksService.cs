﻿using OfficeAppLevarne;
using OfficeAppLevarne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace OfficeAppLevarne.Services
{

    public class WeeksService
    {
        HttpClient client = new();
        private string endpoint = "http://localhost:5050/getWeeks";
        
        List<Week> weekList = new();

        public  async Task<List<Week>> GetWeeks()
        {
            var msg = new HttpRequestMessage(HttpMethod.Get, endpoint);
            var res = await client.SendAsync(msg);

            if (res.IsSuccessStatusCode)
            {
                weekList = await res.Content.ReadFromJsonAsync<List<Week>>();
            }
            return weekList;
        }

    }
}