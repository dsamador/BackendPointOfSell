using POS.Application.Interfaces;
using POS.Persistence.Contexts;
using Ardalis.Specification.EntityFrameworkCore;

namespace POS.Persistence.Repository
{
    public class MyRepositoryAsync<T>: 
        RepositoryBase<T>, IRepositoryAsync<T> where T:class
    {
        private readonly ApplicationDbContext _dbContext;

        public MyRepositoryAsync(ApplicationDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }
        
    }
}
