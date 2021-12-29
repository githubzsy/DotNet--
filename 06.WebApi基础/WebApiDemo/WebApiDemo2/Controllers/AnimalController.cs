using DtoModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebApiService;

namespace WebApiDemo2.Controllers
{
    /// <summary>
    /// 动物测试
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        AnimalService service = new AnimalService();

        /// <summary>
        /// http://域名:端口/api/animal/GetTest
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public AnimalDto GetTest(string name)
        {
            return  service.Get(name);
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<AnimalDto> GetAll()
        {
            return service.GetAll();
        }


        /// <summary>
        /// Post测试
        /// </summary>
        /// <param name="animalDto"></param>
        /// <returns></returns>
        [HttpPost]
        public AnimalDto PostTest(AnimalDto animalDto)
        {
            service.Add(animalDto);
            return animalDto;
        }

        /// <summary>
        /// 删除测试
        /// </summary>
        /// <param name="name"></param>
        [HttpDelete]
        public void DeleteTest(string name)
        {
            service.Delete(name);
        }

        /// <summary>
        /// 接收文件
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="file"></param>
        [HttpPost]
        public void SaveFile([FromForm] string qq, IFormFile file)
        {
            var filefullPath = Path.Combine(Directory.GetCurrentDirectory(), file.FileName);
            using (FileStream fs = new FileStream(filefullPath, FileMode.Create))
            {
                file.CopyTo(fs);
                fs.Flush();
            };
        }
    }
}
