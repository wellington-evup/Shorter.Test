using NUnit.Framework;
using Shorter.Core;
using System;

namespace Shorter.Test
{
    public class TranslatorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Success_Up()
        {
            //Arrange
            ITranslator<string, EncryptedString> translator = new ECBTranslator();
            var original = "6649596";
            var expected = "6cQtxboOoBc=";
            string received;

            //Act
            received = translator.Translate(original).Value;

            //Assert
            Assert.AreEqual(received, expected);
        }

        [Test]
        public void Success_Down()
        {
            //Arrange
            ITranslator<string, EncryptedString> translator = new ECBTranslator();
            var original = new EncryptedString("6cQtxboOoBc=");
            var expected = "6649596";
            string received;

            //Act
            received = translator.Translate(original);

            //Assert
            Assert.AreEqual(received, expected);
        }
    }
}