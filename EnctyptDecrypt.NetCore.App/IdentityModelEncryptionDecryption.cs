using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnctyptDecrypt.NetCore.App
{
    internal class IdentityModelEncryptionDecryption
    {
        public void Test()
        {
            var jwkJson1 = "{\"kty\":\"oct\",\"k\":\"Fdh9u8rINxfivbrianbbVT1u232VQBZYKx1HGAGPt2I\"}";

            var jwksJson = @"
                { 
                   ""keys"":[ 
                      { 
                         ""e"":""AQAB"",
                         ""kid"":""unique key"",
                         ""kty"":""RSA"",
                         ""n"":""some value""
                      }
                   ]
                }";
            var key =JsonWebKey.Create(jwksJson);
            var jwks = new JsonWebKeySet(jwksJson);


            var key1 = JsonWebKey.Create(jwkJson1);
            var jwks1 = new JsonWebKeySet(jwkJson1);


            

        }
    }
}
