using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace TemplateHttp
{

    public static class timer
    {
        public static int started = 0;
        [FunctionName("timer")]
        public static void Run([TimerTrigger("* */5 * * * *", RunOnStartup = true)]TimerInfo myTimer, ILogger log)
        {
            if (started == 0)
            {
                started = 1;

                log.LogInformation($"Kicking off the Function Call to the Http Trigger");
            }

            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
