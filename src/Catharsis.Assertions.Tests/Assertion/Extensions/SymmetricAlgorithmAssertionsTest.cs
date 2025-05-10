using System.Security.Cryptography;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="SymmetricAlgorithmAssertions"/>.</para>
/// </summary>
public sealed class SymmetricAlgorithmAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="SymmetricAlgorithmAssertions.BlockSize(IAssertion, SymmetricAlgorithm, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void BlockSize_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => Assert.To.BlockSize(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("algorithm");

      Aes.Create().With(algorithm => Test(true, algorithm, algorithm.BlockSize));
      Test(false, Aes.Create(), int.MinValue);
      Test(false, Aes.Create(), int.MaxValue);
    }

    return;

    static void Test(bool result, SymmetricAlgorithm algorithm, int size)
    {
      using (algorithm)
      {
        AssertionExtensions.Should(() => SymmetricAlgorithmAssertions.BlockSize(null, algorithm, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

        if (result)
        {
          Assert.To.BlockSize(algorithm, size).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.BlockSize(algorithm, size, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SymmetricAlgorithmAssertions.KeySize(IAssertion, SymmetricAlgorithm, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void KeySize_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => Assert.To.KeySize(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("algorithm");

      Aes.Create().With(algorithm => Test(true, algorithm, algorithm.KeySize));
      Test(false, Aes.Create(), int.MinValue);
      Test(false, Aes.Create(), int.MaxValue);
    }

    return;

    static void Test(bool result, SymmetricAlgorithm algorithm, int size)
    {
      using (algorithm)
      {
        AssertionExtensions.Should(() => SymmetricAlgorithmAssertions.KeySize(null, algorithm, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

        if (result)
        {
          Assert.To.KeySize(algorithm, size).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.KeySize(algorithm, size, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }
}