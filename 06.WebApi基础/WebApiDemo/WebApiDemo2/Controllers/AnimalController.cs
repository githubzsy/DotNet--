using DtoModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApiDemo2.Controllers
{
    /// <summary>
    /// 动物测试
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        static List<AnimalDto> animals { get; set; }

        /// <summary>
        /// http://域名:端口/api/animal/GetTest
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTe")]
        public string GetTest()
        {
            return "123";
        }

        /// <summary>
        /// Post测试
        /// </summary>
        /// <param name="animalDto"></param>
        /// <returns></returns>
        [HttpPost]
        public AnimalDto PostTest(AnimalDto animalDto)
        {
            animals.Add(animalDto);
            return animalDto;
        }


    }
}
