using System;
using LibreriaTaller;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibreriaTurismo.UnitTests
{
    [TestClass]
    public class ClienteTests
    {
        [TestMethod]
        public void ValidarEmail_EmailIsValid_ReturnsTrue()
        {
            var email = new Cliente("173180101", "name", "12345678", "valid@email.com").validarEmail("valid@email.com");
          
            Assert.IsTrue(email);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidarEmail_EmailIsNotValid_ReturnsArgumentException()
        {
            var email = new Cliente("173180101", "name", "12345678", "not valid email").validarEmail("not valid email");

            Assert.IsFalse(email);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ValidarRut_RutIsNotValid_ReturnsFormatException()
        {
            var cliente = new Cliente("not valid rut", "name", "12345678", "valid@email.com");

            Assert.IsNull(cliente);
        }

        [TestMethod]
        public void ValidarRut_RutIsValid_ReturnsClient()
        {
            var cliente = new Cliente("173180101", "name", "12345678", "valid@email.com");

            Assert.IsNotNull(cliente);
            Assert.IsInstanceOfType(cliente, typeof(Cliente));
            Assert.IsTrue(cliente.Rut == "173180101");
        }

        [TestMethod]
        public void ValidarRut_RutIsValid_ReturnsRutWithCorrectFormat()
        {
            var cliente = new Cliente("17.318.010-1", "name", "12345678", "valid@email.com");

            Assert.IsNotNull(cliente);
            Assert.IsInstanceOfType(cliente, typeof(Cliente));
            Assert.IsTrue(cliente.Rut == "17.318.010-1");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NombreLength_NombreHasLessThanThreeCharacters_ReturnsArgumentException()
        {
            var cliente = new Cliente("173180101", "pi", "12345678", "valid@email.com");

            Assert.IsNull(cliente);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Doesn't validates invalid input types for Nombre field")]
        public void NombreFormat_NombreHasNumbers_ReturnsArgumentException()
        {
            var cliente = new Cliente("173180101", "123name123", "12345678", "valid@email.com");

            Assert.IsNull(cliente);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Doesn't validates invalid input types for Telefono field")]
        public void TelefonoFormat_TelefonoHasLetters_ReturnsFormatException()
        {
            var cliente = new Cliente("173180101", "name", "12345678", "valid@email.com");

            Assert.IsNull(cliente);
        }
    }
}
