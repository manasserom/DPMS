using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Repository;
using DesignPatterns.Models.Data;

namespace DesignPatterns.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Companie> Companies { get; }
        IRepository<Course> Courses { get; }
        IRepository<Plataform> Plataforms { get; }
        IRepository<Project> Projects { get; }
        IRepository<TechStack> TechStacks { get; }
        void Save();
    }
}
