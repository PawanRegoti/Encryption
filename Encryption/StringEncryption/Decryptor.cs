using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Encryption.StringEncryption
{
  public static class Decryptor
  {
    public static string DecryptString(string value)
    {
      using (RijndaelManaged algorithm = AlgorithmCore.GetAlgorithm())
      {
        return DecryptString(value, algorithm);
      }
    }

    private static string DecryptString(string value, SymmetricAlgorithm mCSP)
    {
      return DecryptString(value, mCSP, Encoding.UTF8);
    }

    private static string DecryptString(string value, SymmetricAlgorithm mCSP, Encoding encoding)
    {
      byte[] byt;
      byte[] decryptedBytes;

      byt = Convert.FromBase64String(value);
      decryptedBytes = DecryptByteArray(byt, mCSP);

      return encoding.GetString(decryptedBytes);
    }

    private static byte[] DecryptByteArray(byte[] value, SymmetricAlgorithm mCSP)
    {
      using (var ms = new MemoryStream())
      using (var ct = mCSP.CreateDecryptor(mCSP.Key, mCSP.IV))
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
