using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodingGym14.GetWebServiceAsync
{
    class Program
    {
        private static string theEbook;

        static void Main(string[] args)
        {
            // WebClient class is a member of System.Net
            WebClient webClient = new WebClient();
            var progress = new ProgressBar();
            
            // webClient.DownloadStringCompleted += (s, eArgs) =>
            // {
            //     theEBook = eArgs.Result;
            //     Console.WriteLine("EBook telah selesai diunduh");
            //     GetStats();
            // };
            
            webClient.DownloadStringCompleted += async (s, eArgs) =>
            {
                progress.Dispose();
                theEbook = eArgs.Result;
                Console.WriteLine("Done.");
                // await GetStatsAsync();
                await GetStatsBetterAsync();
            };
            
            webClient.DownloadProgressChanged += (object sender, DownloadProgressChangedEventArgs e) =>
            {
                progress.Report((double)e.ProgressPercentage / 100);
            };            

            // I/O bound operation
            // webClient.DownloadStringAsync(new Uri("http://www.gutenberg.org/cache/epub/78/pg78.txt"));
            webClient.DownloadStringAsync(new Uri("https://ocw.mit.edu/ans7870/6/6.006/s08/lecturenotes/files/t8.shakespeare.txt"));
            Console.Write("Downloading EBook: ");
            Console.ReadLine();
        }

        
        #region Asynchronous helper methods
        private static async Task GetStatsBetterAsync()
        {
            StringBuilder bookStats = new StringBuilder();
            string[] tenMostCommon;
            string longestWord;
            // Get the words from the e-book.
            string[] words = theEbook.Split(new char[]
            { ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/' },
            StringSplitOptions.RemoveEmptyEntries);

            Task<string[]> tenMostCommonTask = FindTenMostCommonAsync(words);
            Task<string> longestWordTask = FindLongestWordAsync(words);

            Console.WriteLine("Calculate words statistic in the EBook...");

            List<Task> allTasks = new List<Task> { tenMostCommonTask, longestWordTask };

            while (allTasks.Any())
            {
                Task finished = await Task.WhenAny(allTasks);

                if (finished == tenMostCommonTask)
                {
                    tenMostCommon = tenMostCommonTask.Result;
                    bookStats.AppendLine("\n10 most used words:");
                    foreach (string s in tenMostCommon)
                    {
                        bookStats.AppendLine($"- {s}");
                    }
                }
                else if (finished == longestWordTask)
                {
                    longestWord = longestWordTask.Result;
                    bookStats.AppendFormat("\nLongest word: {0}", longestWord);
                    bookStats.AppendLine();
                }
                allTasks.Remove(finished);
            }
            Console.WriteLine(bookStats.ToString(), "Book info");
        }

        private static async Task GetStatsAsync()
        {
            // Get the words from the e-book.
            string[] words = theEbook.Split(new char[]
            { ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/' },
            StringSplitOptions.RemoveEmptyEntries);

            Task<string[]> tenMostCommonTask = FindTenMostCommonAsync(words);
            Task<string> longestWordTask = FindLongestWordAsync(words);

            Console.WriteLine("Calculate words statistic in the EBook...");

            string longestWord = await longestWordTask;
            string[] tenMostCommon = await tenMostCommonTask;

            // Now that all tasks are complete, build a string to show all stats.
            StringBuilder bookStats = new StringBuilder();
            bookStats.AppendLine("\n10 most used words:\n");
            foreach (string s in tenMostCommon)
            {
                bookStats.AppendLine($"- {s}");
            }

            bookStats.AppendFormat("\nLongest word: {0}", longestWord);
            bookStats.AppendLine();

            Console.WriteLine(bookStats.ToString(), "Book info");
        }

        // CPU bound operation
        private static async Task<string> FindLongestWordAsync(string[] words)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            return (from w in words orderby w.Length descending select w).FirstOrDefault();
        }

        // this is also a CPU bound operation
        private static async Task<string[]> FindTenMostCommonAsync(string[] words)
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
            var frequencyOrder = from word in words
                                    where word.Length > 6
                                    group word by word into g
                                    orderby g.Count() descending
                                    select g.Key;
            return (frequencyOrder.Take(10)).ToArray();
        }
        #endregion

        #region Syncronous helper methods
        private static void GetStats()
        {
            // Get the words from the e-book.
            // \u000A -> \n (Line Feed/new line)
            string[] words = theEbook.Split(new char[]
            { ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/' }, StringSplitOptions.RemoveEmptyEntries);

            // Get the longest word.
            string longestWord = FindLongestWord(words);

            // Now, find the ten most common words.
            string[] tenMostCommon = FindTenMostCommon(words);

            Console.WriteLine("Calculate words statistic in the EBook...");

            // Now that all tasks are complete, build a string to show all stats.
            StringBuilder bookStats = new StringBuilder();
            bookStats.AppendLine("\n10 most used words:\n");
            foreach (string s in tenMostCommon)
            {
                bookStats.AppendLine($"- {s}");
            }

            bookStats.AppendFormat("\nLongest word: {0}", longestWord);
            bookStats.AppendLine();
            
            Console.WriteLine(bookStats.ToString(), "Book info");
        }

        private static string FindLongestWord(string[] words)
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            return (from w in words orderby w.Length descending select w).FirstOrDefault();
        }

        private static string[] FindTenMostCommon(string[] words)
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            var frequencyOrder = from word in words
                                 where word.Length > 6
                                 group word by word into g
                                 orderby g.Count() descending
                                 select g.Key;
            
            return (frequencyOrder.Take(10)).ToArray();
        }
        #endregion
    }
}