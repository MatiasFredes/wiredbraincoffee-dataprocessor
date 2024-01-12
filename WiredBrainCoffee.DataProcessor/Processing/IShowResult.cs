using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiredBrainCoffee.DataProcessor.Processing
{
    public interface IShowResult
    {
        string Message { get; set; }
        void ShowResult();
    }

    public class ShowResultConsole : IShowResult
    {
        public string Message { get; set; }


        public void ShowResult()
        {
            Console.WriteLine(Message);
        }
    }
}
