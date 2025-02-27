﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Policy;
using System.IO;
using System.Net;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;

namespace Proyecto_Estructuras
{

    public class CripRSA
    {

        private string publicKey = @"-----BEGIN PUBLIC KEY-----
        MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAjI4EwndbkBcAXGopGUUY
        0w3VAUcNK3GuOzFKf/7wpmAgQq9Ld7n9I6eSRMwO1299qNWh1e8xmH+VXN6EG0dt
        I+NCh/MS6b0/peQzI0hW136MS0s0F8k7mFXHPuDy81a3Vz8BBU8+V3crx1rP48l0
        NU/xguq67SkuJvDWSrs5f4ydgYHcK0hD6yO8tWA8EyB+JRMEugmz/RUOLkvoNBTU
        CG8k0lgXFE3CeTNQaJG5Dbyn5Mw8+NT4avRM1JATUZyjSQKAt9QD/dyQufe5hWL7
        xxOh2N15v0k3TrBM3JQefVqfW2ajlDWzrv0kQv7kxRgXECdaquXmDMQGKnnRJS62
        HQIDAQAB
        -----END PUBLIC KEY-----";

        private string privateKey = @"-----BEGIN RSA PRIVATE KEY-----
        MIIEowIBAAKCAQEAjI4EwndbkBcAXGopGUUY0w3VAUcNK3GuOzFKf/7wpmAgQq9L
        d7n9I6eSRMwO1299qNWh1e8xmH+VXN6EG0dtI+NCh/MS6b0/peQzI0hW136MS0s0
        F8k7mFXHPuDy81a3Vz8BBU8+V3crx1rP48l0NU/xguq67SkuJvDWSrs5f4ydgYHc
        K0hD6yO8tWA8EyB+JRMEugmz/RUOLkvoNBTUCG8k0lgXFE3CeTNQaJG5Dbyn5Mw8
        +NT4avRM1JATUZyjSQKAt9QD/dyQufe5hWL7xxOh2N15v0k3TrBM3JQefVqfW2aj
        lDWzrv0kQv7kxRgXECdaquXmDMQGKnnRJS62HQIDAQABAoIBABn/Ys39ecgrGPv+
        /t8XssHG+zEjTUJN4qY8NcV7CFQdz5nGBrV8h2AC7MEg5VXf32RNL4P8nDXS03O8
        DL9m9L8AmBvBUCw/vvgWP4c1KCrv009R9662n/lLVHFC9m0gCwVuN+gdgjB3cHeN
        Soqdhosd4FQQysZ3KXw2a8yi2L3IpDqTwSBLCCKcwylTXAJwT02L9JhmJRi26y7N
        WIX14TUfvj6cYfaCGuQH37JZ293yaJ9uSkQvKQ3rN+H6o8T57rh1N+1B8R8zvySk
        QiKrNZ94atCrnsvawEkQIIWqX3kmTd0nawbTG7/vgSFoXWdGx7jM7TLGK/3JCh97
        3cygQJkCgYEAyzzB6KinVUgACZF5SqIVNBkFDFvOTyysKFKHEy0UtM3VWIPN23BY
        DqCo0/Zt/Nf3Xkojzo9fKsQ1XXKdrA4thXr4pWduBKe9lv2IPl0aFZrgiGx87Au9
        O1+ReICnIgy2k17sUEJRegG0ZXigq1uoSkN7v1wm6nQiQHnYLy5vIxMCgYEAsQtZ
        iDoE+7Iy/pL5oEQN/3WJYmsZRtmIXecTya4f8bfbPKaBxf2rlr3Us+YMSfZd4PGQ
        G+mev09kuHLqTJPcLe5kvj6pW5nESOw37DT4QxSLv9Cuc0Wc4EXIVh3GnFFuozUB
        plprqwUG1SgwCrR9Cpn40P9acSS2DEyywP9yuA8CgYBQB8HX6ynRdEPHgMiBcifl
        VwDc5/3qwY2dZzoXfAYOWIttiqFyit+yCuPQa9bN3QFk2M8W1PBFt/PHs42RJhgY
        2t60y3DQVnlazsVqwWC3J0DJl+btUIYYrj5rdEXcK6NtjtCBnkvVPnyaBJFISRSR
        Adfl99S/ODIQr6pIkgFjjwKBgQCb2f3q6ghQ+cHiUMfmyYH5DCLwvI73y6872puU
        wu/j/ZHFhl5fSLuwa1O/Ohg/U924k23k5HeWufFUXfTbjJ4a4O1WfBriRC6Cc0+X
        Y9nYU1HifXXUi8dZtpRxGq0oFpdqnNLi+l4lorstEb+Y7OHWX0ylzuRzDXokwa/q
        LfVzCQKBgDuUG9QSyqoq14rj2ntsXMnazDekMotxjJkDB/xbF+9i4FuiOS7uGXK2
        Aq9Eh1aLBvtSgpKmZBzf4ELH9RcLGC7pc2Tg0WgpRG4fm4Eyyc5dkU7hMFBRLMhO
        WjAvT7mtB7wwRLfPlx1aaWFQJQaoBWAzVFfu+uJZ38CJ9V1OEmc5
        -----END RSA PRIVATE KEY-----";


        public string Encriptar(string contraseña)
        {
            RSACryptoServiceProvider RSApublicKey = ImportarLlavePublica(publicKey);

            // Usa la misma codificación en todos los métodos
            byte[] contraseñaBytes = Encoding.UTF8.GetBytes(contraseña); // Cambiado a UTF8

            byte[] encryptedBytes = RSApublicKey.Encrypt(contraseñaBytes, false);

            return Convert.ToBase64String(encryptedBytes);
        }

        public string Desencriptar(string contraEncriptada)
        {
            RSACryptoServiceProvider RSAprivateKey = ImportarLlavePrivada(privateKey);

            byte[] bytesContraEncriptada = Convert.FromBase64String(contraEncriptada);

            byte[] decryptedBytes = RSAprivateKey.Decrypt(bytesContraEncriptada, false);

            // Usa UTF8 también aquí
            return Encoding.UTF8.GetString(decryptedBytes);
        }
        public RSACryptoServiceProvider ImportarLlavePrivada(string pem)
        {
            PemReader pr = new PemReader(new StringReader(pem));
            AsymmetricCipherKeyPair kp = (AsymmetricCipherKeyPair)pr.ReadObject();
            RSAParameters rsaParams = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)kp.Private);

            RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
            csp.ImportParameters(rsaParams);
            return csp;
        }

        public RSACryptoServiceProvider ImportarLlavePublica(string pem)
        {
            PemReader pr = new PemReader(new StringReader(pem));
            AsymmetricKeyParameter publicKey = (AsymmetricKeyParameter)pr.ReadObject();
            RSAParameters rsaParams = DotNetUtilities.ToRSAParameters((RsaKeyParameters)publicKey);

            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();// cspParams);
            csp.ImportParameters(rsaParams);
            return csp;
        }


    }
}
