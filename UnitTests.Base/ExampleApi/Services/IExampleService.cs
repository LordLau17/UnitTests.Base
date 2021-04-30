using ExampleApi.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExampleApi.Services
{
    public interface IExampleService
    {
        Task<Example> GetExampleAsync(long id);

        Task<IEnumerable<Example>> GetExamplesAsync();
    }
}