using System;
using Laba_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encoding.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DecryptRus_string_key_encryptStringReturned()
        {     //arrange
            string x = "бщцфаирщри, бл ячъбиуъ щбюэсяёш гфуаа!!!";
            string y = "скорпион";
            string expected = "поздравляю, ты получил исходный текст!!!";
             //act
            VigenereCipher a = new VigenereCipher(true);
            string actual = a.Decrypt(x, y);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EncryptRus_string_key_encryptStringReturned()
        {
            
            string x = "поздравляю, ты получил исходный текст!!!";
            string y = "скорпион";
            string expected = "бщцфаирщри, бл ячъбиуъ щбюэсяёш гфуаа!!!";
            //act
            VigenereCipher a = new VigenereCipher(true);
            string actual = a.Encrypt(x, y);

            //assert
            Assert.AreEqual(expected, actual);
        }

        

    }
}
