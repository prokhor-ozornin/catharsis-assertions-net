using System.Security.Cryptography;
using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="SymmetricAlgorithmExpectations"/>.</para>
/// </summary>
public sealed class SymmetricAlgorithmExpectationsTest : UnitTest
{
  private SymmetricAlgorithm Algorithm { get; } = Aes.Create();

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

      Algorithm.Expect().BlockSize(int.MinValue).Result.Should().BeFalse();
      Algorithm.Expect().BlockSize(int.MaxValue).Result.Should().BeFalse();
      Algorithm.Expect().BlockSize(Algorithm.BlockSize).Result.Should().BeTrue();
    }

    return;

    static void Validate()
    {

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

      Algorithm.Expect().KeySize(int.MinValue).Result.Should().BeFalse();
      Algorithm.Expect().KeySize(int.MaxValue).Result.Should().BeFalse();
      Algorithm.Expect().KeySize(Algorithm.KeySize).Result.Should().BeTrue();
    }

    return;

    static void Validate()
    {

    }
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