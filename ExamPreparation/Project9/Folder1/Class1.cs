using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Threading;
using System.Reflection;

namespace Project9.Folder1
{
    static class Class1
    {
        public static void Run()
        {
            //DemoHashing();
            //RunningTotalQuestion();
            //TaskStatusCancelled();
            LoadAssemblyTest();
        }

        static void LoadAssemblyTest()
        {
            File.Copy(
                sourceFileName: @"..\..\SignedAssembly.dll",
                destFileName: "SignedAssembly.dll",
                overwrite: true);
            var assemblyName = "SignedAssembly, Version=2.1.0.9, Culture=neutral, PublicKeyToken=1f59f2ea13bb832a";
            var ass = Assembly.Load(assemblyName);
        }

        static void TaskStatusCancelled()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            Console.WriteLine("Starting tasks. Press c to cancel...");
            Thread.Sleep(1000);

            var tasks = new[]
            {
                Task.Run(() => DemoCancelByPolling(token, "Task1", false)),
                Task.Run(() => DemoCancelByPolling(token, "Task2", true)),
                Task.Run(() => DemoCancelByCallback(token, "Task3", false)),
                Task.Run(() => DemoCancelByCallback(token, "Task4", true))
            };

            var ch = Console.ReadKey(true).KeyChar;
            if (ch == 'c' || ch == 'C')
            {
                cts.Cancel();
            }

            try
            {
                Task.WaitAll(tasks);
            }
            catch (AggregateException ex)
            {
                ex.InnerExceptions.Where(e => e is OperationCanceledException).ToList().ForEach(e =>
                {
                    Console.WriteLine($"{e.Message}, {e.StackTrace}");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                });
            }

            for (int i = 0; i < tasks.Length; i++)
            {
                Console.WriteLine($"Task{i + 1} status: {tasks[i].Status}");
            }
            

            void DemoCancelByPolling(CancellationToken ct, string taskName, bool throwIfCancelled)
            {
                while (!ct.IsCancellationRequested)
                {
                    Console.WriteLine($"{taskName} running...");
                    Thread.Sleep(500);
                }

                Console.Write($"{taskName} has been cancelled");
                if (!throwIfCancelled)
                {
                    Console.WriteLine(" without throwing on cancelled.");
                }
                else
                {
                    Console.WriteLine(" with throw on cancelled");
                    ct.ThrowIfCancellationRequested();
                }
            }

            void DemoCancelByCallback(CancellationToken ct, string taskName, bool throwIfCancelled)
            {
                bool isCancellationRequested = false;
                ct.Register(() =>
                {
                    Console.WriteLine($"Cancellation has been requested for {taskName}. Asynchronously cancelling the task.");
                    isCancellationRequested = true;
                });

                while (!isCancellationRequested)
                {
                    Console.WriteLine($"{taskName} running...");
                    Thread.Sleep(500);
                }

                Console.Write($"{taskName} has been cancelled asynchronously");
                if (!throwIfCancelled)
                {
                    Console.WriteLine(" without throwing on cancelled.");
                }
                else
                {
                    Console.WriteLine(" with throw on cancelled");
                    ct.ThrowIfCancellationRequested();
                }
            }
        }

        static void RunningTotalQuestion()
        {
            var arr = new[] { 1, 2, 3, 4, 5 };

            for (int i = 1; i < arr.Length; i++)
            {
                arr[i] += arr[i - 1];
            }

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        static void DemoHashing()
        {
            string sampleData = "My sample data";
            Encoding encoding = Encoding.UTF8;
            HashAlgorithm algo = HashAlgorithm.Create();

            byte[] simpleHashBytes = ComputeHashSimple();
            string simpleHashString = BytesToHexString(simpleHashBytes);

            byte[] blocksHashBytes = ComputeHashInBlocks(5);
            string blocksHashString = BytesToHexString(blocksHashBytes);
            
            Console.WriteLine($"Simple hash: {simpleHashString}");
            Console.WriteLine($"Blocked hash: {blocksHashString}");

            byte[] ComputeHashSimple()
            {
                byte[] bytes = encoding.GetBytes(sampleData);
                return algo.ComputeHash(bytes);
            }

            byte[] ComputeHashInBlocks(int blockSize)
            {
                var algo2 = HashAlgorithm.Create();
                int offset = 0;
                var bytes = encoding.GetBytes(sampleData);

                while (sampleData.Length - offset >= blockSize)
                    offset += algo.TransformBlock(bytes, offset, blockSize, bytes, offset);
                algo.TransformFinalBlock(bytes, offset, bytes.Length - offset);

                return algo.Hash;
            }
        }

        static string[] SplitString(string data, int partsCount)
        {
            int blockLength = data.Length / partsCount;
            string[] parts = new string[partsCount];
            int nextIndex = 0;
            for (int i = 0; i < partsCount - 1; i++)
            {
                var part = data.Substring(nextIndex, blockLength);
                nextIndex = nextIndex + blockLength;
                parts[i] = part;
            }

            parts[parts.Length - 1] = data.Substring(nextIndex);

            return parts;
        }

        static string BytesToHexString(byte[] data)
        {
            var sb = new StringBuilder();
            foreach (var item in data)
            {
                sb.Append(item.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
