using DtoModels;
using System.Text.Json;

namespace WebApiDemo2.BLL
{
    public class AnimalService
    {
        /// <summary>
        /// 获取所有动物
        /// </summary>
        /// <returns></returns>
        public async Task<List<AnimalDto>> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(5);
                var response = await client.GetAsync("http://localhost:5000/api/Animal/GetAll");
                string str = await response.Content.ReadAsStringAsync();
                var animals = JsonSerializer.Deserialize<List<AnimalDto>>(str);
                return animals;
            }
        }
    }
}