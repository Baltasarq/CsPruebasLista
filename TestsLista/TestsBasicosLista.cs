namespace TestsLista
{
    using PruebasListas;
    using NUnit.Framework;
    
    
    [TestFixture]
    public class TestsBasicosLista
    {
        [SetUp]
        public void Inicio()
        {
            this.lista = new Lista<int>();
        }
        
        [Test]
        public void TestNingunElemento()
        {
            Assert.IsTrue( this.lista.EsFinal() );
        }
        
        [Test]
        public void TestUnElemento()
        {
            this.lista.Add( 1 );

            this.lista.IrPrincipio();
            Assert.AreEqual( 1, this.lista.Actual );
        }

        [Test]
        public void TestVariosElementos()
        {
            int[] v = {1, 2, 3, 4, 5, 6, 7, 8};

            foreach (int x in v) {
                this.lista.Add( x );
            }

            int i = 0;
            this.lista.IrPrincipio();
            while ( !this.lista.EsFinal() ) {
                Assert.AreEqual(
                    v[ i ],
                    this.lista.Actual );
                
                ++i;
                this.lista.IrSiguiente();
            }
        }

        [Test]
        public void TestEstaVacia()
        {
            Assert.IsTrue( this.lista.EstaVacia() );
        }

        Lista<int> lista;
    }
}
