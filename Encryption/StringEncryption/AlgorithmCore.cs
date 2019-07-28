using System.Security.Cryptography;
using System.Text;

namespace Encryption.StringEncryption
{
  static class AlgorithmCore
  {
    internal static RijndaelManaged GetAlgorithm(
      string initializationVector = "Light Weight- IV", 
      string secretKey = "TheSecretKeypg6z8qc49k8d3p9JVwnT")
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
