using IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Oracle;
using System;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        IAnimalService service;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="service"></param>
        public AnimalController(IAnimalService service,IAnimalService service2)
        {
            this.service = service;
            Console.WriteLine(service == service2);
        }

        [HttpPost]
        public string Add(string animal)
        {
            service.Add(animal);
            return animal;
        }
    }
}
