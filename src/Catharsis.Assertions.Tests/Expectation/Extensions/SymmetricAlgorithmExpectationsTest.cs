using System.Security.Cryptography;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="SymmetricAlgorithmExpectations"/>.</para>
/// </summary>
/// <seealso cref="SymmetricAlgorithmExpectations"/>
public sealed class SymmetricAlgorithmExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="SymmetricAlgorithmExpectations.BlockSize(IExpectation{SymmetricAlgorithm}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void BlockSize_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => SymmetricAlgorithmExpectations.BlockSize(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((SymmetricAlgorithm) null).Expect().BlockSize(0)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Aes.Create().With(algorithm => Test(true, algorithm, algorithm.BlockSize));
      Test(false, Aes.Create(), int.MinValue);
      Test(false, Aes.Create(), int.MaxValue);
    }

    return;

    static void Test(bool result, SymmetricAlgorithm algorithm, int size)
    {
      using (algorithm)
      {
        algorithm.Expect().BlockSize(size).Should().BeOfType<Expectation<SymmetricAlgorithm>>().Which.Result.Should().Be(result);
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SymmetricAlgorithmExpectations.KeySize(IExpectation{SymmetricAlgorithm}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void KeySize_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => SymmetricAlgorithmExpectations.KeySize(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((SymmetricAlgorithm) null).Expect().KeySize(0)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Aes.Create().With(algorithm => Test(true, algorithm, algorithm.KeySize));
      Test(false, Aes.Create(), int.MinValue);
      Test(false, Aes.Create(), int.MaxValue);
    }

    return;

    static void Test(bool result, SymmetricAlgorithm algorithm, int size)
    {
      using (algorithm)
      {
        algorithm.Expect().KeySize(size).Should().BeOfType<Expectation<SymmetricAlgorithm>>().Which.Result.Should().Be(result);
      }
    }
  }
}