using System.Security.Cryptography;
using Catharsis.Commons;
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
  ///   <para>Performs testing of <see cref="SymmetricAlgorithmAssertions.BlockSize(IAssertion, SymmetricAlgorithm, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void BlockSize_Method()
  {
    AssertionExtensions.Should(() => SymmetricAlgorithmAssertions.BlockSize(null, Algorithm, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.BlockSize(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("algorithm");

    AssertionExtensions.Should(() => Assert.To.BlockSize(Algorithm, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.BlockSize(Algorithm, int.MaxValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.BlockSize(Algorithm, Algorithm.BlockSize).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SymmetricAlgorithmAssertions.KeySize(IAssertion, SymmetricAlgorithm, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void KeySize_Method()
  {
    AssertionExtensions.Should(() => SymmetricAlgorithmAssertions.KeySize(null, Algorithm, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.KeySize(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("algorithm");

    AssertionExtensions.Should(() => Assert.To.KeySize(Algorithm, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.KeySize(Algorithm, int.MaxValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.KeySize(Algorithm, Algorithm.KeySize).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public override void Dispose()
  {
    base.Dispose();
    Algorithm.Dispose();
  }
}