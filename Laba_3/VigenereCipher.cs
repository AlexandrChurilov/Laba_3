using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3
{
    public class VigenereCipher
    {
        
        private string _alphabet;

        public VigenereCipher(string alphabet )
        {
            _alphabet = alphabet;
        }

        
        private string GetKey(string str, int count)
        {
            string k = str;
            while (k.Length < count)
            {
                k += k;
            }

            return k.Substring(0, count);
        }

        private string Vigenere(string text, string keyCipher, bool encrAndDecr)
        {
            int encrypt = 0;
            if(encrAndDecr)
            {
                encrypt = 1;
            }
            else
            {
                encrypt = -1;
            }

            int alphabetCount = _alphabet.Length;
            string key = GetKey(keyCipher, text.Length);
            string stringV = "";
           
            int j = -1;
            for (int i = 0; i < text.Length; i++)
            {
                var alphabetIndex = _alphabet.IndexOf(text[i]);
                
                if (alphabetIndex < 0)
                {

                    stringV += text[i].ToString();
                }
                else
                {
                    j++;
                    var codeIndex = _alphabet.IndexOf(key[j]);
                    stringV += _alphabet[(alphabetCount + alphabetIndex + encrypt * codeIndex) % alphabetCount].ToString();
                }
            }

            return stringV;
        }

        public string Encrypt(string text, string key)
        { 
            
            return Vigenere(text, key, true);
        }



        public string Decrypt(string text, string key)
        { 
            
            return Vigenere(text, key, false);
        }
        

    }
}