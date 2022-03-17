using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IService
{
    public interface IGenericService<T>
    {
        public T SayHello(T message);
    }
}
