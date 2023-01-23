using System.Security.Cryptography;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="SymmetricAlgorithmAssertions"/>.</para>
/// </summary>
public sealed class SymmetricAlgorithmAssertionsTest : UnitTest
{
  private SymmetricAlgorithm Algorithm { get; } = Aes.Create();

  /// <summary>
  ///   <para>Performs testing of <see cref="SymmetricAlgorithmAssertions.BlockSize(IAssertion, System.Security.Cryptography.SymmetricAlgorithm, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void BlockSize_Method()
  {
    AssertionExtensions.Should(() => SymmetricAlgorithmAssertions.BlockSize(null, Algorithm, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.BlockSize(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("algorithm");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SymmetricAlgorithmAssertions.KeySize(IAssertion, System.Security.Cryptography.SymmetricAlgorithm, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void KeySize_Method()
  {
    AssertionExtensions.Should(() => SymmetricAlgorithmAssertions.KeySize(null, Algorithm, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.KeySize(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("algorithm");

    throw new NotImplementedException();
  }

  public override void Dispose()
  {
    base.Dispose();
    Algorithm.Dispose();
  }
}