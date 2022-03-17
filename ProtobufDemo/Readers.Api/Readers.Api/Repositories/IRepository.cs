using Readers.Api.Models;

namespace Readers.Api.Repositories
{
    public interface IRepository
    {
        List<Reader> GetAll();
    }
}
