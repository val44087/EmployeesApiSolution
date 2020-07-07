using EmployeesApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeesApiIntergrationTests1
{
    public class APISmokeTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public APISmokeTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/books")]
        public async Task ResourceAreAlive(string url)
        {
            //given
            var client = _factory.CreateClient();

            //when
            var response = await client.GetAsync(url);

            //Assert
            Assert.True(response.IsSuccessStatusCode);


        }
    }
}
