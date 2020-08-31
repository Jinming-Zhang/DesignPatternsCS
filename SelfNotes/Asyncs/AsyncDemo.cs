using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
namespace AsyncDemo
{
    public class AsyncHTTPRequest
    {

        string url, result;
        private static readonly HttpClient client = new HttpClient();
        private AsyncHTTPRequest(string url)
        {
            this.url = url;
        }
        public override string ToString()
        {
            return this.result;
        }
        private async Task<AsyncHTTPRequest> GetRequestAsync()
        {
            Console.WriteLine($"Making request to {this.url}...");
            var response = await client.GetStringAsync(this.url);
            Console.WriteLine($"Got response from the url...");
            this.result = response;
            return this;
        }

        public static async Task<AsyncHTTPRequest> GetRequest(string url)
        {
            AsyncHTTPRequest req = new AsyncHTTPRequest(url);
            return await req.GetRequestAsync();
        }


        public static async Task<AsyncHTTPRequest> GetFakeRequestAsync(int timeToSpend)
        {
            AsyncHTTPRequest fakeRequest = new AsyncHTTPRequest("fakeurl");
            await Task.Delay(timeToSpend * 1000);
            fakeRequest.result = "Finally finished the fake task";
            return fakeRequest;
        }

        public static AsyncHTTPRequest GetFakeRequesntSync(int timeToSpend)
        {
            AsyncHTTPRequest fake = new AsyncHTTPRequest("fake url");
            Thread.Sleep(timeToSpend * 1000);
            fake.result = "Finally finished the fake task";
            return fake;
        }
    }
    public class AsyncDemo
    {
        public static async Task Demo()
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            // without async programming
            Console.WriteLine("Starting tasks synchronously.");
            AsyncHTTPRequest req1 = AsyncHTTPRequest.GetFakeRequesntSync(1);
            AsyncHTTPRequest req2 = AsyncHTTPRequest.GetFakeRequesntSync(2);
            AsyncHTTPRequest req3 = AsyncHTTPRequest.GetFakeRequesntSync(3);
            watch.Stop();
            Console.WriteLine($"Total time used without Async programming: {watch.ElapsedMilliseconds} ms.");

            // with async programming
            watch.Reset();
            watch.Start();
            Console.WriteLine("Starting tasks asynchronously.");
            Task<AsyncHTTPRequest> reqAsync1 = AsyncHTTPRequest.GetFakeRequestAsync(1);
            Task<AsyncHTTPRequest> reqAsync2 = AsyncHTTPRequest.GetFakeRequestAsync(2);
            Task<AsyncHTTPRequest> reqAsync3 = AsyncHTTPRequest.GetFakeRequestAsync(3);
            await reqAsync2;
            Task.WaitAll(reqAsync1, reqAsync2, reqAsync3);
            watch.Stop();
            Console.WriteLine($"Total time used with Async programming: {watch.ElapsedMilliseconds} ms.");

            // a real http request to get the current date
            Console.WriteLine("A real http request to get the current date:");
            string url = "http://worldtimeapi.org/api/Asia/Shanghai";
            Console.WriteLine("Starting async request...");
            Task<AsyncHTTPRequest> sampleRequest = AsyncHTTPRequest.GetRequest(url);
            // check the status of the task
            Console.WriteLine("Here the code continues while the async task starts performing.");
            // await the async task
            AsyncHTTPRequest sample = await sampleRequest;
            Console.WriteLine("Use the stored Task to wait for its to finish. \nData:");

            string pattern = @".*?([0-9]{4}-[0-9]{2}-[0-9]{2})";
            Regex r = new Regex(pattern);
            Match m = r.Match(sample.ToString());
            while (m.Success)
            {
                Group g = m.Groups[1];
                Console.WriteLine(g);
                m = m.NextMatch();
            }
        }
    }


}