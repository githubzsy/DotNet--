using DtoModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        static List<AnimalDto> animals=new List<AnimalDto>();

        [HttpGet]
        public AnimalDto GetTest(string name)
        {
            return animals.SingleOrDefault(x => x.Name == name);
        }

        [HttpGet]
        public IEnumerable<AnimalDto> GetAllTest()
        {
            return animals;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<AnimalDto> PostTest(AnimalDto dto)
        {
            if (animals.Any(a => a.Name == dto.Name))
            {
                return BadRequest("名称重复了");
            }
            animals.Add(dto);
            return dto;
        }

        /// <summary>
        /// 新增或修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public AnimalDto PutTest(AnimalDto dto)
        {
            var animal = animals.SingleOrDefault(a=>a.Name == dto.Name);
            if (animal == null)
            {
                animals.Add(dto);
            }
            else animal.Age = dto.Age;
            return dto;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpDelete]
        public int DeleteTest(string name)
        {
           return animals.RemoveAll(a => a.Name == name);
        }
    }
}
