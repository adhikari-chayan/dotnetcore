using CQRS.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CQRS.Api.Context
{
    public interface IApplicationContext
    {
        DbSet<Product> Products { get; set; }

        Task<int> SaveChanges();
    }
}