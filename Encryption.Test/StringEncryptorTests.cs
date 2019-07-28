using Encryption.StringEncryption;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Encryption.Test
{
  public class StringEncryptorTests
  {
    [Theory]
    [InlineData("12345", "Wd3tp1ciYflcI96Y/QdHaw==")]
    [InlineData("sample", "sI5hHnj3QPWj/8OT/exP3w==")]
    [InlineData("Sample", "N5BzjF4op/u1uFI4AUhKoA==")]
    [InlineData("Sample123", "QQgxZ8zODkdGPZ67cHnElg==")]
    [InlineData("Sample#123", "Jj+9AxgLpAaKw6/Bwyi+/Q==")]
    [InlineData("Qhx0ObpQA4rRNNEFYYdHkcUZ", "rDY0+Uw9B56W0njVEe3bOUuqSM2W2sIlXtJ04fURRXI=")]
    public void EncryptorTests(string value, string expectedValue)
    {
      //Arrange

      //Act
      var result = Encryptor.EncryptString(value);

      //Assert
      result.Should().Be(expectedValue);
    }

    [Theory]
    [InlineData("Wd3tp1ciYflcI96Y/QdHaw==", "12345")]
    [InlineData("sI5hHnj3QPWj/8OT/exP3w==", "sample")]
    [InlineData("N5BzjF4op/u1uFI4AUhKoA==", "Sample")]
    [InlineData("QQgxZ8zODkdGPZ67cHnElg==", "Sample123")]
    [InlineData("Jj+9AxgLpAaKw6/Bwyi+/Q==", "Sample#123")]
    [InlineData("rDY0+Uw9B56W0njVEe3bOUuqSM2W2sIlXtJ04fURRXI=", "Qhx0ObpQA4rRNNEFYYdHkcUZ")]
    public void DecryptorTests(string value, string expectedValue)
    {
      //Arrange

      //Act
      var result = Decryptor.DecryptString(value);

      //Assert
      result.Should().Be(expectedValue);
    }

    //private IEnumerable<Tuple<string, string>> testData = new List<Tuple<string, string>>
    //{
    //  new Tuple<string, string>("12345", "Wd3tp1ciYflcI96Y/QdHaw=="),
    //  new Tuple<string, string>("sample", "sI5hHnj3QPWj/8OT/exP3w=="),
    //  new Tuple<string, string>("Sample", "N5BzjF4op/u1uFI4AUhKoA=="),
    //  new Tuple<string, string>("Sample123", "QQgxZ8zODkdGPZ67cHnElg=="),
    //  new Tuple<string, string>("Sample#123", "Jj+9AxgLpAaKw6/Bwyi+/Q=="),
    //  new Tuple<string, string>("Qhx0ObpQA4rRNNEFYYdHkcUZ", "rDY0+Uw9B56W0njVEe3bOUuqSM2W2sIlXtJ04fURRXI="),
    //};
  }
}
