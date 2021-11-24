using Lab6_7.DataAccess.Models;
using Lab6_7.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_7.DataAccess.Repositories.Realizations.Sql
{
    public class SqlContractorRepo : IContractorRepo
    {
        private readonly LabDbContext _context;

        public SqlContractorRepo(LabDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Contractor> GetAllContractors()
        {
            return _context.Contractors.ToList();
        }

        public Contractor GetContractorById(int id)
        {
            return _context.Contractors.FirstOrDefault(p => p.Id == id);
        }
    }
}
