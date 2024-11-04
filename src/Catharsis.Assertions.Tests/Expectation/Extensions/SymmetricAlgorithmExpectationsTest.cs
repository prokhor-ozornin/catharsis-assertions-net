using System.Security.Cryptography;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="SymmetricAlgorithmExpectations"/>.</para>
/// </summary>
public sealed class SymmetricAlgorithmExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="SymmetricAlgorithmExpectations.BlockSize(IExpectation{SymmetricAlgorithm}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void BlockSize_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => SymmetricAlgorithmExpectations.BlockSize(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((SymmetricAlgorithm) null).Expect().BlockSize(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Aes.Create().With(algorithm => Validate(true, algorithm, algorithm.BlockSize));
      Validate(false, Aes.Create(), int.MinValue);
      Validate(false, Aes.Create(), int.MaxValue);
    }

    return;

    static void Validate(bool result, SymmetricAlgorithm algorithm, int size)
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
      AssertionExtensions.Should(() => SymmetricAlgorithmExpectations.KeySize(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((SymmetricAlgorithm) null).Expect().KeySize(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Aes.Create().With(algorithm => Validate(true, algorithm, algorithm.KeySize));
      Validate(false, Aes.Create(), int.MinValue);
      Validate(false, Aes.Create(), int.MaxValue);
    }

    return;

    static void Validate(bool result, SymmetricAlgorithm algorithm, int size)
    {
      using (algorithm)
      {
        algorithm.Expect().KeySize(size).Should().BeOfType<Expectation<SymmetricAlgorithm>>().Which.Result.Should().Be(result);
      }
    }
  }
}