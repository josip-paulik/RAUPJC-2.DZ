using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Normal invocation - long operation

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            LongOperation("A");
            LongOperation("B");
            LongOperation("C");
            LongOperation("D");
            LongOperation("E");
            stopwatch.Stop();

            Console.WriteLine("Synchronous long operation calls finished {0} sec.", stopwatch.Elapsed.TotalSeconds);

            #endregion


            #region Parallel invocation - long operation



            stopwatch.Restart();
            Parallel.Invoke(() => LongOperation("A"),
                            () => LongOperation("B"),
                            () => LongOperation("C"),
                            () => LongOperation("D"),
                            () => LongOperation("E"));
            stopwatch.Stop();

            Console.WriteLine("Parallel long operation calls finished {0} sec.", stopwatch.Elapsed.TotalSeconds);


            #endregion


            #region Parallel calls - short operation

            

            stopwatch.Restart();
            Parallel.For(0, 1000, (i) =>
            {
                var x = 2;
                var y = 2;
                var sum = x + y;
            });
            stopwatch.Stop();

            Console.WriteLine("Parallel calls finished {0} ms.", stopwatch.Elapsed.TotalMilliseconds);



            #endregion

            #region Sync operation calls

            stopwatch.Restart();
            for(int i = 0; i < 1000; i++)
            {
                var x = 2;
                var y = 2;
                var sum = x + y;
            }
            stopwatch.Stop();

            Console.WriteLine("Sync operation calls finished {0} ms.", stopwatch.Elapsed.TotalMilliseconds);

            #endregion
            Console.ReadLine();
        }

        public static void LongOperation(string taskName)
        {
            Thread.Sleep(1000);
            Console.WriteLine("{0} Finished. Executing Thread: {1}", taskName,
                Thread.CurrentThread.ManagedThreadId);
        }
    }
}
