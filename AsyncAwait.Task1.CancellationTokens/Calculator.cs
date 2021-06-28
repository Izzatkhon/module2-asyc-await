using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait.Task1.CancellationTokens
{
    static class Calculator
    {
        public static Task<long> Calculate(int n, CancellationToken token)
        {
            var task = new Task<long>(() =>
            {
                long sum = 0;

                for (var i = 0; i < n; i++)
                {
                    // i + 1 is to allow 2147483647 (Max(Int32)) 
                    sum += i + 1;

                    Thread.Sleep(10);

                    if (token.IsCancellationRequested)
                    {
                        token.ThrowIfCancellationRequested();
                    }
                }

                return sum;

            }, token);

            task.Start();

            return task;
        }
    }
}
