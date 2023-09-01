using ExampleApi.Models;
using ExampleApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExampleApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExamplesController : ControllerBase
{
    private readonly IExampleService _exampleService;

    public ExamplesController(IExampleService exampleService)
    {
        _exampleService = exampleService;
    }

    [HttpGet("examples/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Example>> GetExampleAsync([FromRoute] long id)
    {
        var result = await _exampleService.GetExampleAsync(id);

        if (result == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(result);
        }
    }

    [HttpGet("examples")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<Example>>> GetExamplesAsync()
    {
        var result = await _exampleService.GetExamplesAsync();

        if (result == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(result);
        }
    }
}