using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting async example...");

        string url = "https://jsonplaceholder.typicode.com/posts/1";
        string result = await FetchDataAsync(url);

        Console.WriteLine("Data fetched:");
        Console.WriteLine(result);

        Console.WriteLine("Async example completed.");

        // Uncomment the following line to see the deadlock example
        DeadlockExample();
    }

    static async Task<string> FetchDataAsync(string url)
    {
        using HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    // create deadlock scenario
    static void DeadlockExample()
    {
        var task = Task.Run(async () =>
        {
            await Task.Delay(10000);
            Console.WriteLine("Task completed");
        });

        // Wait for the task to complete
        task.Wait(); // This will cause a deadlock if called from the main thread
    }
}