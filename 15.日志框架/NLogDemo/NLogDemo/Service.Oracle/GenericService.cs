using IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Oracle
{
    public class GenericService<T> : IGenericService<T>
    {
        public T SayHello(T message)
        {
            return message;
        }
    }
}
