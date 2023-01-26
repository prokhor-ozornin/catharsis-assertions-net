using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ComparableExpectations"/>.</para>
/// </summary>
public sealed class ComparableExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ComparableExpectations.Positive{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Positive_Method()
  {
    AssertionExtensions.Should(() => ComparableExpectations.Positive<int>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ComparableExpectations.Negative{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Negative_Method()
  {
    AssertionExtensions.Should(() => ComparableExpectations.Negative<int>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ComparableExpectations.Zero{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Zero_Method()
  {
    AssertionExtensions.Should(() => ComparableExpectations.Zero<int>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ComparableExpectations.Greater{T}(IExpectation{T}, T)"/> method.</para>
  /// </summary>
  [Fact]
  public void Greater_Method()
  {
    AssertionExtensions.Should(() => ComparableExpectations.Greater<int>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ComparableExpectations.GreaterOrEqual{T}(IExpectation{T}, T)"/> method.</para>
  /// </summary>
  [Fact]
  public void GreaterOrEqual_Method()
  {
    AssertionExtensions.Should(() => ComparableExpectations.GreaterOrEqual<int>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ComparableExpectations.Lesser{T}(IExpectation{T}, T)"/> method.</para>
  /// </summary>
  [Fact]
  public void Lesser_Method()
  {
    AssertionExtensions.Should(() => ComparableExpectations.Lesser<int>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ComparableExpectations.LesserOrEqual{T}(IExpectation{T}, T)"/> method.</para>
  /// </summary>
  [Fact]
  public void LesserOrEqual_Method()
  {
    AssertionExtensions.Should(() => ComparableExpectations.Lesser<int>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ComparableExpectations.InRange{T}(IExpectation{T}, T, T)"/> method.</para>
  /// </summary>
  [Fact]
  public void InRange_Method()
  {
    AssertionExtensions.Should(() => ComparableExpectations.InRange<int>(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ComparableExpectations.OutOfRange{T}(IExpectation{T}, T, T)"/> method.</para>
  /// </summary>
  [Fact]
  public void OutOfRange_Method()
  {
    AssertionExtensions.Should(() => ComparableExpectations.OutOfRange<int>(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }
}