using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();     
        void Add(T data);
        void Update(T data);
        void Delete(int id);
        void Save();


    }
}
