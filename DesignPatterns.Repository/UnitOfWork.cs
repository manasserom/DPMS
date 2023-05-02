using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Models.Data;

namespace DesignPatterns.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DpmsContext _context;
        private IRepository<Companie> _companies;
        private IRepository<Course> _courses;
        private IRepository<Plataform> _plataforms;
        private IRepository<Project> _projects;
        private IRepository<TechStack> _techStacks;
        public UnitOfWork(DpmsContext context)
        {
            _context = context;
        }

        public IRepository<Companie> Companies
        {
            get { return _companies == null ? _companies = new Repository<Companie>(_context) : _companies; }
        }        
        public IRepository<Course> Courses
        {
            get { return _courses == null ? _courses = new Repository<Course>(_context) : _courses; }
        }        
        public IRepository<Plataform> Plataforms
        {
            get { return _plataforms == null ? _plataforms = new Repository<Plataform>(_context) : _plataforms; }
        }        
        public IRepository<Project> Projects
        {
            get { return _projects == null ? _projects = new Repository<Project>(_context) : _projects; }
        }        
        public IRepository<TechStack> TechStacks
        {
            get { return _techStacks == null ? _techStacks = new Repository<TechStack>(_context) : _techStacks; }
        }
        public void Save() => _context.SaveChanges(); 
    }
}
