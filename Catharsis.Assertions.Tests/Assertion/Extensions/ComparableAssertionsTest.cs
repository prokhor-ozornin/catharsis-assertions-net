using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ComparableAssertions"/>.</para>
/// </summary>
public sealed class ComparableAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ComparableAssertions.Positive{T}(IAssertion, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Positive_Method()
  {
    AssertionExtensions.Should(() => ComparableAssertions.Positive<int>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ComparableAssertions.Negative{T}(IAssertion, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Negative_Method()
  {
    AssertionExtensions.Should(() => ComparableAssertions.Negative<int>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ComparableAssertions.Zero{T}(IAssertion, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Zero_Method()
  {
    AssertionExtensions.Should(() => ComparableAssertions.Zero<int>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ComparableAssertions.Greater{T}(IAssertion, T, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Greater_Method()
  {
    AssertionExtensions.Should(() => ComparableAssertions.Greater<int>(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ComparableAssertions.GreaterOrEqual{T}(IAssertion, T, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void GreaterOrEqual_Method()
  {
    AssertionExtensions.Should(() => ComparableAssertions.GreaterOrEqual<int>(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ComparableAssertions.Lesser{T}(IAssertion, T, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Lesser_Method()
  {
    AssertionExtensions.Should(() => ComparableAssertions.Lesser<int>(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ComparableAssertions.LesserOrEqual{T}(IAssertion, T, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void LesserOrEqual_Method()
  {
    AssertionExtensions.Should(() => ComparableAssertions.Lesser<int>(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ComparableAssertions.InRange{T}(IAssertion, T, T, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void InRange_Method()
  {
    AssertionExtensions.Should(() => ComparableAssertions.InRange<int>(null, default, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ComparableAssertions.OutOfRange{T}(IAssertion, T, T, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void OutOfRange_Method()
  {
    AssertionExtensions.Should(() => ComparableAssertions.OutOfRange<int>(null, default, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }
}