using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Extensions.utils
{    
    public class Context : IDisposable
    {
        private string _name;
        private Stopwatch _sw = new Stopwatch();

        public Action<string> Log = (msg) => Console.WriteLine(msg);

        public Context(string name)
        {
            _sw.Start();
            _name = name;
        }

        public void Dispose()
        {
            _sw.Stop();
            Log($"{_name} took {_sw.ElapsedMilliseconds}ms");
        }
    }
}