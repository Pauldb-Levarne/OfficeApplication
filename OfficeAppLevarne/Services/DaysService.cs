using OfficeAppLevarne;
using OfficeAppLevarne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OfficeAppLevarne.Services
{

    public class DaysService
    {
        HttpClient client = new();
        private string endpoint = "http://10.0.2.2:5050/";

        Day day;

        public async Task<Day> UpdateDay(string weekId, Day payload)
        {
            var target = endpoint + "updateDay?weekId=" + weekId;
            var json = JsonSerializer.Serialize(payload);
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var res = await client.PostAsync(target, httpContent);

            

            if (res.IsSuccessStatusCode)
            {
                day = await res.Content.ReadFromJsonAsync<Day>();
            }
            return day;
        }

    }
}
