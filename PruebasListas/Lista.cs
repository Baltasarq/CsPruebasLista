// ReSharper disable All
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

            return;
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

        Nodo ppio;
        Nodo fin;
        Nodo actual;
    }
}
