/*
 *┌──────────────────────────────────────────┐
 *│  描   述: AnimalService
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/21 16:05:41
 *│  说   明:
 *└──────────────────────────────────────────┘
 */
using DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WinformDemo.BLL
{
    public class AnimalService
    {
        static string routePrefix = "http://localhost:5000/api/Test/";

        static JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = false,
            PropertyNamingPolicy = null
        };

        public async Task<IList<AnimalDto>> GetAnimals()
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(5);
                var response = await client.GetAsync(routePrefix + "GetAllTest");
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string str = await response.Content.ReadAsStringAsync();
                    var animals = JsonSerializer.Deserialize<IList<AnimalDto>>(str);
                    return animals;
                }
                else
                {
                    throw new Exception(response.StatusCode.ToString());
                }
            }
        }

    }
}
