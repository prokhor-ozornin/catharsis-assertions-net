using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="NumericProtections"/>.</para>
/// </summary>
public sealed class NumericProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="NumericProtections.Positive{T}(IProtection, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Positive_Method()
  {
    AssertionExtensions.Should(() => NumericProtections.Positive(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="NumericProtections.Negative{T}(IProtection, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Negative_Method()
  {
    AssertionExtensions.Should(() => NumericProtections.Negative(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="NumericProtections.Zero{T}(IProtection, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Zero_Method()
  {
    AssertionExtensions.Should(() => NumericProtections.Zero(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="NumericProtections.OutOfRange{T}(IProtection, T, T, T, string)"/></description></item>
  ///     <item><description><see cref="NumericProtections.OutOfRange(IProtection, int, Range, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void OutOfRange_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => NumericProtections.OutOfRange(null, 0, 0, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => NumericProtections.OutOfRange(null, 0, ..0)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    }

    throw new NotImplementedException();
  }
}