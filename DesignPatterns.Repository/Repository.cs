using DesignPatterns.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DpmsContext _context;
        private DbSet<T> _dbset;

        public Repository(DpmsContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public void Add(T data)=> _dbset.Add(data);

        public void Delete(int id)
        {
            var dataToDelete = _dbset.Find(id);
            _dbset.Remove(dataToDelete);
        }

        public IEnumerable<T> Get() => _dbset.ToList();

        public T Get(int id) => _dbset.Find(id);


        public void Update(T data)
        {
            _dbset.Attach(data);
            _context.Entry(data).State = EntityState.Modified;
        }
        public void Save() => _context.SaveChanges();
    }
}
