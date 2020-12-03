// ReSharper disable All

using System;
using System.Diagnostics;

namespace PruebasListas
{
    public class Lista<T> {
        class Nodo {
            public T Dato {
                get; set;
            }

            public Nodo Sig {
                get; set;
            }

            public Nodo Prev {
                get; set;
            }
        }

        public Lista()
        {
            this.ppio = this.fin = 
                this.actual = null;
        }

        public void Add(T x)
        {
            Debug.WriteLine( "List.Add()" );
            Debug.Indent();
            Debug.Assert( x != null, "Lista.Add(): x es null" );

            int numNodosPpio = this.Conteo();
            Debug.WriteLine( "Nodos antes de añadir: " + numNodosPpio );
            
            #if DEBUG
                if ( x == null )
                {
                    throw new ArgumentException( "x es null en Lista.Add()" );
                }
            #endif
            
            var nodo = new Nodo {
                Dato = x
            };

            if ( this.fin == null ) {
                this.ppio =
                    this.fin =
                        this.actual = nodo;
            } else {
                this.fin.Sig = nodo;
                nodo.Prev = this.fin;
                this.fin = nodo;
            }

            this.CompruebaRecorridoLista();
            
            Debug.WriteLine( "Nodos despues de añadir: " + this.Conteo() );
            Debug.Assert( this.fin.Dato.Equals( x ) );
            Debug.Assert( numNodosPpio == ( this.Conteo() - 1 ), "num. nodos no incrementado en 1" );
            Debug.Unindent();
            return;
        }

        [Conditional("DEBUG")]
        void CompruebaRecorridoLista()
        {
            Nodo n = this.ppio;

            while (n != null
                   && n.Sig != null)
            {
                n = n.Sig;
            }

            Debug.Assert( n == this.fin, "CompruebaRecorrido: no ha llegado al final" );
            
            n = this.fin;

            while (n != null
                   && n.Prev != null)
            {
                n = n.Prev;
            }
            
            Debug.Assert( n == this.ppio, "CompruebaRecorrido: no ha llegado al principio" );
        }

        public void IrPrincipio()
        {
            this.actual = this.ppio;
        }

        public void IrSiguiente()
        {
            if ( this.actual != null ) {
                this.actual = this.actual.Sig;
            }
        }

        public bool EsFinal()
        {
            return this.actual == null;
        }
        
        public T Actual {
            get
            {
                T toret = default(T);
                
                if ( this.actual != null ) {
                    toret = this.actual.Dato;
                }

                return toret;
            }
        }
        
        public bool EstaVacia()
        {
            this.IrPrincipio();
            return this.EsFinal();
        }

        public int Conteo()
        {
            int toret = 0;
            Nodo n = this.ppio;
            
            while ( n != null )
            {
                n = n.Sig;
                ++toret;
            }

            return toret;
        }

        Nodo ppio;
        Nodo fin;
        Nodo actual;
    }
}
