using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Drawing;

namespace Project8.Diags
{
    static class CreatingPerformanceCounters
    {
        public const string counterCategoryName = "My Images Processed Counter";
        public const string totalImagesCounterName = "My Total Images Processed";
        public const string imagesProcessedPerSecondCounterName = "My Images Processed Per Second";
        public const string totalImagesCounterHelp = "Represents the total number of images that have been processed since the creation of counter.";
        public const string imagesProcessedPerSecondCounterHelp = "Represents the average number of images processed per second.";
        public const string counterCategoryHelp = "Image processing counter describing the total number images that have been processed and the average" +
            " number of images processed per second.";

        static PerformanceCounter TotalImagesCounter;
        static PerformanceCounter ImagesProcessPerSecondCounter;

        public static void Run()
        {
            Demo();
        }

        static void Demo()
        {
            if (SetupCounters() == CounterSetupResult.Created)
            {
                Console.WriteLine("Performance counters created");
                Console.WriteLine("Restart the program");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Processing started");

            SequentialTest();

            ParallelTest();

            Console.WriteLine("Processing complete. Press any key to exit.");
            Console.ReadKey();
        }

        public static CounterSetupResult SetupCounters()
        {
            if (PerformanceCounterCategory.Exists(counterCategoryName))
            {
                TotalImagesCounter = new PerformanceCounter(
                    categoryName: counterCategoryName,
                    counterName: totalImagesCounterName,
                    readOnly: false);
                ImagesProcessPerSecondCounter = new PerformanceCounter(
                    categoryName: counterCategoryName,
                    counterName: imagesProcessedPerSecondCounterName,
                    readOnly: false);
                return CounterSetupResult.Loaded;
            }

            CounterCreationData[] counterData = new CounterCreationData[]
            {
                new CounterCreationData(totalImagesCounterName, totalImagesCounterHelp, PerformanceCounterType.NumberOfItems64),
                new CounterCreationData(imagesProcessedPerSecondCounterName, imagesProcessedPerSecondCounterHelp, PerformanceCounterType.RateOfCountsPerSecond32)
            };

            CounterCreationDataCollection counterCollection = new CounterCreationDataCollection(counterData);
            PerformanceCounterCategory.Create(
                categoryName: counterCategoryName,
                categoryHelp: counterCategoryHelp,
                categoryType: PerformanceCounterCategoryType.SingleInstance,
                counterData: counterCollection);

            return CounterSetupResult.Created;
        }

        static void MakeThumbnail(string sourceFile, string destDir, int width, int height)
        {
            TotalImagesCounter.Increment();

            ImagesProcessPerSecondCounter.Increment();

            //String filename = Path.GetFileName(sourceFile);

            //String destPath = Path.Combine(destDir, filename);

            //Bitmap bitmap = new Bitmap(sourceFile);

            //float scale = Math.Min((float)width / bitmap.Width, (float)height / bitmap.Height);

            //int scaleWidth = (int)(bitmap.Width * scale);
            //int scaleHeight = (int)(bitmap.Height * scale);

            //Bitmap resized = new Bitmap(bitmap, new Size(scaleWidth, scaleHeight));
            //resized.Save(destPath);
        }

        static void MakeThumbnailsSeq(string sourceDir, string destDir, int width = 320, int height = 240)
        {
            String[] files = Directory.GetFiles(sourceDir, "*.jpg");

            Directory.CreateDirectory(destDir);

            foreach (string filename in files)
            {
                MakeThumbnail(filename, destDir, width, height);
            }
        }

        static void MakeThumbnailsParallel(string sourceDir, string destDir, int width = 320, int height = 240)
        {
            String[] files = Directory.GetFiles(sourceDir, "*.jpg");

            Directory.CreateDirectory(destDir);

            Parallel.ForEach(files, (filename) =>
            {
                MakeThumbnail(filename, destDir, width, height);
            });
        }

        public static void SequentialTest()
        {
            MakeThumbnailsSeq(sourceDir: @"..\..\..\images",
                destDir: @"Images\Serial"); ;
        }

        public static void ParallelTest()
        {
            MakeThumbnailsParallel(sourceDir: @"..\..\..\images",
                destDir: @"Images\Parallel");
        }
    }

    enum CounterSetupResult
    {
        Created,
        Loaded
    }
}
