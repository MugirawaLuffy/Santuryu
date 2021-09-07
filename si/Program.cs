using System.Text;
using Santuryu.CodeAnalysis.Binding;

namespace Santuryu
{

    internal static class Program
    {
        public static void Main()
        {
            var repl = new SantoryuRepl();
            repl.Run();
        }

    }
}
