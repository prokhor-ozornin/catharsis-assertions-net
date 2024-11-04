using System.Security.Cryptography;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="SymmetricAlgorithmAssertions"/>.</para>
/// </summary>
public sealed class SymmetricAlgorithmAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="SymmetricAlgorithmAssertions.BlockSize(IAssertion, SymmetricAlgorithm, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void BlockSize_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => Assert.To.BlockSize(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("algorithm");

      Aes.Create().With(algorithm => Validate(true, algorithm, algorithm.BlockSize));
      Validate(false, Aes.Create(), int.MinValue);
      Validate(false, Aes.Create(), int.MaxValue);
    }

    return;

    static void Validate(bool result, SymmetricAlgorithm algorithm, int size)
    {
      using (algorithm)
      {
        AssertionExtensions.Should(() => SymmetricAlgorithmAssertions.BlockSize(null, algorithm, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

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
      AssertionExtensions.Should(() => Assert.To.KeySize(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("algorithm");

      Aes.Create().With(algorithm => Validate(true, algorithm, algorithm.KeySize));
      Validate(false, Aes.Create(), int.MinValue);
      Validate(false, Aes.Create(), int.MaxValue);
    }

    return;

    static void Validate(bool result, SymmetricAlgorithm algorithm, int size)
    {
      using (algorithm)
      {
        AssertionExtensions.Should(() => SymmetricAlgorithmAssertions.KeySize(null, algorithm, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

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