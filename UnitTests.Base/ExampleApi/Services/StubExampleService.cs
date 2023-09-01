using ExampleApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleApi.Services;

public class StubExampleService : IExampleService
{
    private readonly IList<Example> _examples;

    public StubExampleService()
    {
        _examples = new List<Example>
        {
            new Example
            {
                Id = 1,
                IsExample = true,
                Title = "Example 1"
            },
            new Example
            {
                Id = 2,
                IsExample = false,
                Title = "Example 2"
            }
        };
    }

    public async Task<Example> GetExampleAsync(long id)
    {
        return await Task.Run(() => _examples.SingleOrDefault(x => x.Id == id));
    }

    public async Task<IEnumerable<Example>> GetExamplesAsync()
    {
        return await Task.Run(() => _examples.ToList());
    }
}