using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesCartuchera;


namespace TestCartuchera
{
    [TestClass]
    public class TestCartuchera
    {
        [TestMethod]
        public void AgregarUtilTest()
        {
            //arrenge
            Cartuchera<Utiles> miCartuchera = new Cartuchera<Utiles>("carlos", 12);
            Lapiz miLapiz = new Lapiz("marca",100,"escolar",4,"rojo",12);
            bool resultadoEsperado = true;
            bool resultado;

            //act
            resultado = miCartuchera + miLapiz;

            //assert
            Assert.AreEqual(resultado, resultadoEsperado);
        }

        [TestMethod]
        public void CompararCartucheraTest()
        {
            //arrenge
            Cartuchera<Utiles> miCartuchera1 = new Cartuchera<Utiles>("carlos", 12);
            Cartuchera<Utiles> miCartuchera2 = new Cartuchera<Utiles>("juan", 12);
            bool resultadoEsperado = true;
            bool resultado;

            //act
            resultado = (miCartuchera1==miCartuchera2);

            //assert
            Assert.AreEqual(resultado, resultadoEsperado);
        }
    }
}
