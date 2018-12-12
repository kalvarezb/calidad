using System;
using LibreriaTaller;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibreriaTurismo.UnitTests
{
    [TestClass]
    public class RutaTests
    {
        [TestMethod]
        public void CodigoFormat_ShouldBeValidCodigo_ReturnsRutaWithSubmittedCodigo()
        {
            var ruta = new Ruta(123, "ruta 1", 40000, 30000, 20000);

            Assert.IsTrue(ruta.Codigo == 123);
            Assert.IsInstanceOfType(ruta, typeof(Ruta));
            Assert.IsNotNull(ruta);
        }

        [TestMethod]
        public void CalcularCostoRuta_ShouldBeCorrectCosto_ReturnsCosto()
        {
            var costoRuta = new Ruta(123, "ruta 1", 40000, 30000, 20000).CalcularCostoRuta();

            Assert.IsTrue(costoRuta == 90000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Doesn't validates maximum of 8 hours")]
        public void MaxRutaDuration_ShouldBeLessThan480Minutes_ReturnsArgumentException()
        {
            var etapa1 = new Etapa(123, "etapa 1", "descripcion", 200);
            var etapa2 = new Etapa(456, "etapa 2", "descripcion", 200);
            var etapa3 = new Etapa(789, "etapa 3", "descripcion", 200);

            var ruta = new Ruta(123, "ruta 1", 40000, 30000, 20000);

            ruta.AgregarEtapa(etapa1);
            ruta.AgregarEtapa(etapa2);
            ruta.AgregarEtapa(etapa3);

            Assert.IsFalse(ruta.Etapas.Contains(etapa3));
        }

        [TestMethod]
        public void AgregarEtapa_ShouldAddEtapaToRuta_RutaHasAddedEtapa()
        {
            var etapa1 = new Etapa(123, "etapa 1", "descripcion", 200);
            var ruta = new Ruta(123, "ruta 1", 40000, 30000, 20000);

            ruta.AgregarEtapa(etapa1);

            Assert.IsTrue(ruta.Etapas.Contains(etapa1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Doesn't validates duplicity of etapas within ruta")]
        public void AgregarEtapa_ShouldNotAddExistentEtapaToRuta_ReturnsArgumentException()
        {
            var etapa1 = new Etapa(123, "etapa 1", "descripcion", 200);
            var etapa2 = new Etapa(123, "etapa 2", "descripcion", 200);
            var ruta = new Ruta(123, "ruta 1", 40000, 30000, 20000);

            ruta.AgregarEtapa(etapa1);
            ruta.AgregarEtapa(etapa2);

            Assert.IsFalse(ruta.Etapas.Contains(etapa2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Doesn't validate negative values for arriendoFurgon")]
        public void ArriendoFurgonValue_ShouldNotBeNegative_ReturnsArgumentException()
        {
            var ruta = new Ruta(123, "ruta 1", 40000, 30000, -20000);

            Assert.IsNull(ruta);
        }




    }
}
