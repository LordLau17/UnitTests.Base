using AutoFixture.Xunit2;
using ExampleApi.BusinessObjects;
using ExampleApi.Controllers;
using ExampleApi.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitTests.Base.AutoFixture;
using Xunit;

namespace UnitTests.Base.Controllers
{
    public class ExampleControllerTests
    {
        [Theory, AutoDomainData]
        public async Task GetExampleAsync_ExampleIdExists_ReturnsOkSpecificExample(
            [Frozen] Mock<IExampleService> exampleServiceMock,
            Example example,
            ExampleController sut)
        {
            exampleServiceMock.Setup(x => x.GetExampleAsync(example.Id)).Returns(Task.FromResult(example));

            var result = await sut.GetExampleAsync(example.Id);

            var okObjectResult = result.Result as OkObjectResult;
            okObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            okObjectResult.Value.Should().Be(example);
        }

        [Theory, AutoDomainData]
        public async Task GetExampleAsync_ExampleIdDoestNotExist_ReturnsNotFound(
            [Frozen] Mock<IExampleService> exampleServiceMock,
            Example example,
            ExampleController sut)
        {
            exampleServiceMock.Setup(x => x.GetExampleAsync(example.Id)).Returns(Task.FromResult<Example>(null));

            var result = await sut.GetExampleAsync(example.Id);

            var notfoundResult = result.Result as NotFoundResult;
            notfoundResult.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Theory]
        [AutoDomainInlineData(true)]
        [AutoDomainInlineData(false)]
        public async Task GetExampleAsync_IsExampleCases_ReturnsMatchingIsExample(
            bool isExample,
            [Frozen] Mock<IExampleService> exampleServiceMock,
            Example example,
            ExampleController sut)
        {
            example.IsExample = isExample;
            exampleServiceMock.Setup(x => x.GetExampleAsync(example.Id)).Returns(Task.FromResult(example));

            var result = await sut.GetExampleAsync(example.Id);

            var okObjectResult = result.Result as OkObjectResult;
            okObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            okObjectResult.Value.Should().Be(example);
            (okObjectResult.Value as Example).IsExample.Should().Be(isExample);
        }

        [Theory, AutoDomainData]
        public async Task GetExamplesAsync_ExamplesExist_ReturnsOkExamples(
            [Frozen] Mock<IExampleService> exampleServiceMock,
            IEnumerable<Example> examples,
            ExampleController sut)
        {
            exampleServiceMock.Setup(x => x.GetExamplesAsync()).Returns(Task.FromResult(examples));

            var result = await sut.GetExamplesAsync();

            var okObjectResult = result.Result as OkObjectResult;
            okObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            okObjectResult.Value.Should().BeEquivalentTo(examples);
        }

        [Theory, AutoDomainData]
        public async Task GetExamplesAsync_ExamplesDoNotExist_ReturnsNotFound(
            [Frozen] Mock<IExampleService> exampleServiceMock,
            ExampleController sut)
        {
            exampleServiceMock.Setup(x => x.GetExamplesAsync()).Returns(Task.FromResult<IEnumerable<Example>>(null));

            var result = await sut.GetExamplesAsync();

            var notfoundResult = result.Result as NotFoundResult;
            notfoundResult.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }
    }
}