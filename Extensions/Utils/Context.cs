using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Extensions.Utils
{    
    public class Context : IDisposable
    {
        private string _name;
        private Stopwatch _sw = new Stopwatch();

        private Ilogger? _logger = null;

        public Context(string name, Ilogger looger)
        {
            _sw.Start();
            _name = name;
            _logger = looger;
            _logger?.Debug($"Starting {_name}");
        }

        public void OnError(string message)
        {
            _sw.Stop();
            _logger?.Error(message);
        }


        public void Dispose()
        {
            _sw.Stop();
            _logger?.Perf($"{_name} took {_sw.ElapsedMilliseconds}ms");
        }
    }

    public class ContextFactory
    {
        private Ilogger _logger;

        public ContextFactory(Ilogger logger)
        {
            _logger = logger;
        }

        public Context Create(string name)
        {
            return new Context(name, _logger);
        }
    }
}