using System.Threading;

namespace CustomContext
{
    public class ConsoleContext
    {
        private static ThreadLocal<ConsoleContext> _context = new ThreadLocal<ConsoleContext>();
        private string _consoleName;

        public string ConsoleName { get => _consoleName; }

        public static ConsoleContext Current { get => _context.Value; }

        public ConsoleContext(string consoleName)
        {
            _consoleName = consoleName;
            _context.Value = this;
        }

        public static void ResetContext() => _context.Value = null;
    }
}
