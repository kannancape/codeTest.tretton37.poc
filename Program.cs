using codeTest.tretton37.poc.Models;
using System;
using System.Collections;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace codeTest.tretton37.poc
{
    public class Program
    {

        static async Task Main(string[] args)
        {

            ModelService obj = new ModelService();
            ArrayList arrayList = obj.GetListings();
            await obj.SaveWebsourceAsync(arrayList);
            using (var progress = new ProgressBar())
            {
                for (int i = 0; i <= 100; i++)
                {
                    progress.Report((double)i / 100);
                    Thread.Sleep(20);
                }
            }
        }

    }
}
