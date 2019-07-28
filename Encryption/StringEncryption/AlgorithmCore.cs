using System.Security.Cryptography;
using System.Text;

namespace Encryption.StringEncryption
{
  static class AlgorithmCore
  {
    internal static RijndaelManaged GetAlgorithm(
      string initializationVector = "User password IV", 
      string secretKey = "TheSecretKeymg5x8qc39k7c3p9JUnnZ")
    {
      RijndaelManaged algorithm = new RijndaelManaged
      {
        IV = Encoding.UTF8.GetBytes(initializationVector),
        Key = Encoding.UTF8.GetBytes(secretKey)
      };

      return algorithm;
    }
  }
}
