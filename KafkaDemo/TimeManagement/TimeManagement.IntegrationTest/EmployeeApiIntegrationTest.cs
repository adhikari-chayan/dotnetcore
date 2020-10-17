using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TimeManagement.Data;
using TimeManagement.Service;
using Xunit;

namespace TimeManagement.IntegrationTest
{
    public class EmployeeApiIntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        //https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-3.1#basic-tests-with-the-default-webapplicationfactory    
        private readonly WebApplicationFactory<Startup> _factory;

        public EmployeeApiIntegrationTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Test_Get_All()
        {
            //var client = new TestClientProvider().Client;
            var client = _factory.CreateClient();


            var response = await client.GetAsync("/api/employee");

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            //Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Test_Post()
        {
            
            var client = _factory.CreateClient();


            var response = await client.PostAsync("/api/employee"
                  , new StringContent(
                  JsonConvert.SerializeObject(new Employee()
                  {
                      Address = "Test",
                      FirstName = "John",
                      LastName = "Mak",
                      CellPhone = "111-222-3333",
                      HomePhone = "222-333-4444"
                  }),
              Encoding.UTF8,
              "application/json"));

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }


 }

