using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Encryption.StringEncryption
{
  public static class Encryptor
  {
    public static string EncryptString(string value)
    {
      using (RijndaelManaged algorithm = AlgorithmCore.GetAlgorithm())
      {
        return EncryptString(value, algorithm);
      }
    }

    private static string EncryptString(string value, SymmetricAlgorithm mCSP)
    {
      return EncryptString(value, mCSP, Encoding.UTF8);
    }

    private static string EncryptString(string value, SymmetricAlgorithm mCSP, Encoding encoding)
    {
      byte[] byt;
      byte[] encryptedBytes;

      byt = encoding.GetBytes(value);
      encryptedBytes = EncryptByteArray(byt, mCSP);

      return Convert.ToBase64String(encryptedBytes);
    }

    private static byte[] EncryptByteArray(byte[] value, SymmetricAlgorithm mCSP)
    {
      using (var ms = new MemoryStream())
      using (var ct = mCSP.CreateEncryptor(mCSP.Key, mCSP.IV))
      using (var cs = new CryptoStream(ms, ct, CryptoStreamMode.Write))
      {
        cs.Write(value, 0, value.Length);
        cs.FlushFinalBlock();

        cs.Close();

        return ms.ToArray();
      }
    }
  }
}
