using System;

namespace PruebasListas
{
    using System.Diagnostics;

    class A
    {
        public int X
        {
            get;
            set;
        }
    }

    internal class Program
    {
        [Conditional("DEBUG")]
        private static void PreparaTrace()
        {
            Trace.Listeners.Add( new ConsoleTraceListener() );
            Trace.AutoFlush = true;
        }
        public static void Main(string[] args)
        {
            PreparaTrace();
            Trace.WriteLine( "Empieza el programa" );

            var l = new Lista<A>();

            l.Add( new A{ X = 11 } );
            l.Add( new A{ X = 22 } );
            l.Add( new A{ X = 33 } );
            
            l.IrPrincipio();
            while (!l.EsFinal())
            {
                Console.WriteLine( l.Actual.X );
                l.IrSiguiente();
            }
            
            Trace.WriteLine( "Fin de programa" );
            Trace.Close();
        }
    }
}