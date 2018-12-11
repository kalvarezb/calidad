using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibreriaTaller;

namespace LibreriaTurismo.UnitTests
{
    [TestClass]
    public class EtapaTests
    {
        [TestMethod]
        public void CodigoFormat_CodigoIsValid_ReturnsEtapaWithSubmittedCodigo()
        {
            var etapa = new Etapa(123, "etapa 1", "descripcion", 234);

            Assert.IsTrue(etapa.Codigo == 123);
            Assert.IsInstanceOfType(etapa, typeof(Etapa));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Doesn't validates maximum of 8 hours")]
        public void TiempoDuration_DurationIsLargerThan480Minutes_ReturnsArgumentException()
        {
            var etapa = new Etapa(123, "etapa 1", "descripcion", 1000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TiempoDuration_DurationIsLessThanOneMinute_ReturnsArgumentException()
        {
            var etapa = new Etapa(123, "etapa 1", "descripcion", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NombreLength_NombreLengthIsOneCharacter_ReturnsArgumentException()
        {
            var etapa = new Etapa(123, "a", "descripcion", 40);
        }

        [TestMethod]
        public void NombreLength_NombreHasMoreThanTwoCharacters_ReturnsEtapa()
        {
            var etapa = new Etapa(123, "nombre", "descripcion", 40);

            Assert.IsTrue(etapa.Nombre == "nombre");
            Assert.IsInstanceOfType(etapa, typeof(Etapa));
        }
    }
}
