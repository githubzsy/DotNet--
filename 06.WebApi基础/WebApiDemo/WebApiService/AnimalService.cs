using DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiDAL.Repository;

namespace WebApiService
{
    public class AnimalService
    {
        /// <summary>
        /// 所有动物
        /// </summary>
        static List<AnimalDto> animals { get; set; } = new List<AnimalDto>();

        AnimalRepository repository=new AnimalRepository();

        public void Add(AnimalDto animal)
        {
            animals.Add(animal);
        }

        public void Delete(string name)
        {
            animals.RemoveAll(a => a.Name == name);
        }

        public AnimalDto Get(string name)
        {
            return animals.SingleOrDefault(a => a.Name == name);
        }

        public List<AnimalDto> GetAll()
        {
            return repository.GetAll().Select(animal => new AnimalDto
            {
                Age = animal.Age,
                Name = animal.Name,
                Id = animal.Id
            }).ToList();
        }
    }
}
