using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Run();
            // RunAsync2();
            RunWithErrors();
            Console.ReadLine();
        }

        static void Run()
        {
            string g1 = Greeting("Stephanie", 2000);
            string g2 = Greeting("Matthias", 1500);
            Console.WriteLine($"{g1} {g2}");
        }

        static void RunAsync()
        {
            ShowThread(nameof(RunAsync));
            Task<string> t1 = GreetingAsync("Stephanie", 2000);
            Task<string> t2 = GreetingAsync("Matthias", 3000);
            Task.WaitAll(t1, t2);
            Console.WriteLine($"{t1.Result} {t2.Result}");
            ShowThread(nameof(RunAsync));
        }

        static async void RunAsync2()
        {
            ShowThread(nameof(RunAsync));
            Task<string> t1 = GreetingAsync("Stephanie", 2000);
            Task<string> t2 = GreetingAsync("Matthias", 3000);
            await Task.WhenAll(t1, t2);

            //GreetingAsync("Katharina", 4000).ContinueWith(tx =>
            //{

            //});

            Console.WriteLine($"{t1.Result} {t2.Result}");
            ShowThread(nameof(RunAsync));
        }

        static async void RunWithErrors()
        {
            Task allTasks = null;
            try
            {
                Task t1 = ThrowAfterAsync("one", 3000);
                Task t2 = ThrowAfterAsync("two", 2000);
                allTasks = Task.WhenAll(t2, t1);
                await allTasks;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"caught error {ex.Message}");
                AggregateException ex2 = allTasks.Exception;
                foreach (var ex3 in ex2.InnerExceptions)
                {
                    Console.WriteLine($"{ex3.Message}");
                }
            }
        }

        static void ShowThread(string title) =>
            Console.WriteLine($"{title}: running in thread {Thread.CurrentThread.ManagedThreadId} in task {Task.CurrentId}");
        // Async Pattern .NET 1.0
        /*
         * void Foo()
         * IAsyncResult BeginFoo()
         * EndFoo()
         * */
        // Async Event Pattern .NET 2.0
        /*
         * void Foo()
         * FooCompleted event - SendOrPostCallback delegate
         * void FooAsync()
         * */
        // Task-based async pattern C# 5
        /*
         * void Foo()
         * Task FooAsync()
         * Task FooTaskAsync()
         * 
         * await FooAsync()
         * 
         * */

        public static Task<string> GreetingAsync(string name, int ms)
        {
            return Task<string>.Run<string>(() =>
            {
                ShowThread(nameof(GreetingAsync));
                string result = Greeting(name, ms);
                return result;
            });
        }

        public static string Greeting(string name, int ms)
        {
            Thread.Sleep(ms);
            return $"Hello, {name}";
        }

        public async static Task ThrowAfterAsync(string message, int ms)
        {
            await Task.Delay(ms);
            throw new Exception(message);
        }
    }
}
