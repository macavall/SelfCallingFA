using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace TemplateHttp
{

    public static class timer
    {
        public static HttpClient client = new HttpClient();

        public static int started = 0;
        [FunctionName("timer")]
        public static async Task Run([TimerTrigger("*/1 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            if (started == 0)
            {
                //started = 1;

                log.LogInformation($"Kicking off the Function Call to the Http Trigger");

                string selfUri = Environment.GetEnvironmentVariable("WEBSITE_HOSTNAME");
                selfUri = "https://" + selfUri + "/api/httpex";

                Uri myUri = new(selfUri);

                var msg = new HttpRequestMessage(HttpMethod.Get, selfUri);

                var response = await client.SendAsync(msg);
            }

            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
