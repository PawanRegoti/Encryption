using Encryption.StringEncryption;
using FluentAssertions;
using Xunit;

namespace Encryption.Test
{
  public class StringEncryptorTests
  {
    [Theory]
    [InlineData("sample", "THmA9/ZDI+cuR/fiE8f56g==")]
    [InlineData("Sample", "pTpTOSpIcS40Fshkiv9ztw==")]
    [InlineData("Sample123", "uhUEUgf07XGCmwQSIx5VDg==")]
    [InlineData("Sample#123", "iDQjVP6/wzufepSz86NwLw==")]
    [InlineData("12345", "yIlLjNFTHQ4bjlYc+xDNPA==")]
    [InlineData("Qhx0ObpQA4rRNNEFYYdHkcUZ", "0C8QS5A5OrU90Z3TTsnUPaBlCfXogayqQCahe1wFSb8=")]
    public void EncryptorTests(string value, string expectedValue)
    {
      //Arrange

      //Act
      var result = Encryptor.EncryptString(value);

      //Assert
      result.Should().Be(expectedValue);
    }

    [Theory]
    [InlineData("THmA9/ZDI+cuR/fiE8f56g==", "sample")]
    [InlineData("pTpTOSpIcS40Fshkiv9ztw==", "Sample")]
    [InlineData("uhUEUgf07XGCmwQSIx5VDg==", "Sample123")]
    [InlineData("iDQjVP6/wzufepSz86NwLw==", "Sample#123")]
    [InlineData("yIlLjNFTHQ4bjlYc+xDNPA==", "12345")]
    [InlineData("0C8QS5A5OrU90Z3TTsnUPaBlCfXogayqQCahe1wFSb8=", "Qhx0ObpQA4rRNNEFYYdHkcUZ")]
    public void DecryptorTests(string value, string expectedValue)
    {
      //Arrange

      //Act
      var result = Decryptor.DecryptString(value);

      //Assert
      result.Should().Be(expectedValue);
    }
  }
}
