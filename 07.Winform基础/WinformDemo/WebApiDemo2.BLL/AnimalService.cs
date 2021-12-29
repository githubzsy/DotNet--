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

        /// <summary>
        /// 传输文件
        /// </summary>
        /// <param name="fileName"></param>
        public void PostFile(string fileName)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                //添加字符串参数，参数名为qq
                content.Add(new StringContent("123456"), "qq");

                FileInfo fileInfo = new FileInfo(fileName);
                
                //添加文件参数，参数名为files，文件名为123.png
                content.Add(new ByteArrayContent(System.IO.File.ReadAllBytes(fileName)), "file", fileInfo.Name);

                var requestUri = "http://localhost:5000/api/Animal/SaveFile";
                var result = client.PostAsync(requestUri, content).Result.Content.ReadAsStringAsync().Result;

                Console.WriteLine(result);
            }
        }
    }
}