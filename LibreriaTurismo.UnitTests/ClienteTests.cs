﻿using System;
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
            var cliente = new Cliente("173180101", "nombre", "12345678", "email@email.com").validarEmail("email@email.com");
          
            Assert.IsTrue(cliente);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidarEmail_EmailIsNotValid_ReturnsArgumentException()
        {
            var cliente = new Cliente("173180101", "nombre", "12345678", "not valid email").validarEmail("not valid email");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ValidarRut_RutIsNotValid_ReturnsFormatException()
        {
            var cliente = new Cliente("not valid rut", "nombre", "12345678", "valid@email.com");
        }

        [TestMethod]
        public void ValidarRut_RutIsValid_ReturnsClient()
        {
            var cliente = new Cliente("173180101", "nombre", "12345678", "valid@email.com");

            Assert.IsInstanceOfType(cliente, typeof(Cliente));
        }

        [TestMethod]
        public void ValidarRut_RutIsValid_ReturnsRutWithCorrectFormat()
        {
            var cliente = new Cliente("17.318.010-1", "nombre", "12345678", "valid@email.com");
            
            Assert.IsTrue(cliente.Rut == "17.318.010-1");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NombreLength_NombreHasLessThanThreeCharacters_ReturnsArgumentException()
        {
            var cliente = new Cliente("173180101", "pi", "12345678", "valid@email.com");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Doesn't validates invalid input types for Nombre field")]
        public void NombreFormat_NombreHasNumbers_ReturnsArgumentException()
        {
            var cliente = new Cliente("173180101", "123name123", "12345678", "valid@email.com");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Doesn't validates invalid input types for Telefono field")]
        public void TelefonoFormat_TelefonoHasLetters_ReturnsFormatException()
        {
            var cliente = new Cliente("173180101", "123name123", "12345678", "valid@email.com");
        }
    }
}