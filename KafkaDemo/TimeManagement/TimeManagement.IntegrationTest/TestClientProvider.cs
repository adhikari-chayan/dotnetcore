using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using TimeManagement.Service;

namespace TimeManagement.IntegrationTest
{
   public class TestClientProvider
    {
        public HttpClient Client { get; private set; }
        public TestClientProvider()
        {
            //https://stackoverflow.com/questions/53826747/xunit-net-core-web-api-integration-test-the-connectionstring-property-has-not
            var server = new TestServer(new WebHostBuilder()
                .UseContentRoot(@"C:\MyStuff\Practice Projects\dotnetcore\DotnetCoreCentral\TimeManagement\TimeManagement.Service")
                .UseStartup<Startup>());
            Client = server.CreateClient();
        }
    }
}
