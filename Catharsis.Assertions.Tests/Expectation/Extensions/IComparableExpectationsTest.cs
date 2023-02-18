using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IComparableExpectations"/>.</para>
/// </summary>
public sealed class IComparableExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableExpectations.Positive{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Positive_Method()
  {
    AssertionExtensions.Should(() => IComparableExpectations.Positive<int>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    int.MinValue.Expect().Positive().Result.Should().BeFalse();
    0.Expect().Positive().Result.Should().BeFalse();
    int.MaxValue.Expect().Positive().Result.Should().BeTrue();

    DateTime.MinValue.Expect().Positive().Result.Should().BeFalse();
    DateTime.Today.Expect().Positive().Result.Should().BeTrue();
    DateTime.MaxValue.Expect().Positive().Result.Should().BeTrue();

    Guid.Empty.Expect().Positive().Result.Should().BeFalse();
    Guid.NewGuid().Expect().Positive().Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableExpectations.Negative{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Negative_Method()
  {
    AssertionExtensions.Should(() => IComparableExpectations.Negative<int>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    int.MinValue.Expect().Negative().Result.Should().BeTrue();
    0.Expect().Negative().Result.Should().BeFalse();
    int.MaxValue.Expect().Negative().Result.Should().BeFalse();

    DateTime.MinValue.Expect().Negative().Result.Should().BeFalse();
    DateTime.Today.Expect().Negative().Result.Should().BeFalse();
    DateTime.MaxValue.Expect().Negative().Result.Should().BeFalse();

    Guid.Empty.Expect().Negative().Result.Should().BeFalse();
    Guid.NewGuid().Expect().Negative().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableExpectations.Zero{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Zero_Method()
  {
    AssertionExtensions.Should(() => IComparableExpectations.Zero<int>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    int.MinValue.Expect().Zero().Result.Should().BeFalse();
    0.Expect().Zero().Result.Should().BeTrue();
    int.MaxValue.Expect().Zero().Result.Should().BeFalse();

    DateTime.MinValue.Expect().Zero().Result.Should().BeTrue();
    DateTime.Today.Expect().Zero().Result.Should().BeFalse();
    DateTime.MaxValue.Expect().Zero().Result.Should().BeFalse();

    Guid.Empty.Expect().Zero().Result.Should().BeTrue();
    Guid.NewGuid().Expect().Zero().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableExpectations.Greater{T}(IExpectation{T}, T)"/> method.</para>
  /// </summary>
  [Fact]
  public void Greater_Method()
  {
    AssertionExtensions.Should(() => IComparableExpectations.Greater<int>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    0.Expect().Greater(int.MinValue).Result.Should().BeTrue();
    0.Expect().Greater(0).Result.Should().BeFalse();
    0.Expect().Greater(int.MaxValue).Result.Should().BeFalse();

    DateTime.Today.Expect().Greater(DateTime.MinValue).Result.Should().BeTrue();
    DateTime.Today.Expect().Greater(DateTime.Today).Result.Should().BeFalse();
    DateTime.Today.Expect().Greater(DateTime.MaxValue).Result.Should().BeFalse();

    Guid.Empty.Expect().Greater(Guid.Empty).Result.Should().BeFalse();
    Guid.Empty.Expect().Greater(Guid.NewGuid()).Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableExpectations.GreaterOrEqual{T}(IExpectation{T}, T)"/> method.</para>
  /// </summary>
  [Fact]
  public void GreaterOrEqual_Method()
  {
    AssertionExtensions.Should(() => IComparableExpectations.GreaterOrEqual<int>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    0.Expect().GreaterOrEqual(int.MinValue).Result.Should().BeTrue();
    0.Expect().GreaterOrEqual(0).Result.Should().BeTrue();
    0.Expect().GreaterOrEqual(int.MaxValue).Result.Should().BeFalse();

    DateTime.Today.Expect().GreaterOrEqual(DateTime.MinValue).Result.Should().BeTrue();
    DateTime.Today.Expect().GreaterOrEqual(DateTime.Today).Result.Should().BeTrue();
    DateTime.Today.Expect().GreaterOrEqual(DateTime.MaxValue).Result.Should().BeFalse();

    Guid.Empty.Expect().GreaterOrEqual(Guid.Empty).Result.Should().BeTrue();
    Guid.Empty.Expect().Greater(Guid.NewGuid()).Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableExpectations.Lesser{T}(IExpectation{T}, T)"/> method.</para>
  /// </summary>
  [Fact]
  public void Lesser_Method()
  {
    AssertionExtensions.Should(() => IComparableExpectations.Lesser<int>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    0.Expect().Lesser(int.MinValue).Result.Should().BeFalse();
    0.Expect().Lesser(0).Result.Should().BeFalse();
    0.Expect().Lesser(int.MaxValue).Result.Should().BeTrue();

    DateTime.Today.Expect().Lesser(DateTime.MinValue).Result.Should().BeFalse();
    DateTime.Today.Expect().Lesser(DateTime.Today).Result.Should().BeFalse();
    DateTime.Today.Expect().Lesser(DateTime.MaxValue).Result.Should().BeTrue();

    Guid.Empty.Expect().Lesser(Guid.Empty).Result.Should().BeFalse();
    Guid.Empty.Expect().Lesser(Guid.NewGuid()).Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableExpectations.LesserOrEqual{T}(IExpectation{T}, T)"/> method.</para>
  /// </summary>
  [Fact]
  public void LesserOrEqual_Method()
  {
    AssertionExtensions.Should(() => IComparableExpectations.Lesser<int>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    0.Expect().LesserOrEqual(int.MinValue).Result.Should().BeFalse();
    0.Expect().LesserOrEqual(0).Result.Should().BeTrue();
    0.Expect().LesserOrEqual(int.MaxValue).Result.Should().BeTrue();

    DateTime.Today.Expect().LesserOrEqual(DateTime.MinValue).Result.Should().BeFalse();
    DateTime.Today.Expect().LesserOrEqual(DateTime.Today).Result.Should().BeTrue();
    DateTime.Today.Expect().LesserOrEqual(DateTime.MaxValue).Result.Should().BeTrue();

    Guid.Empty.Expect().LesserOrEqual(Guid.Empty).Result.Should().BeTrue();
    Guid.Empty.Expect().LesserOrEqual(Guid.NewGuid()).Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableExpectations.InRange{T}(IExpectation{T}, T, T)"/> method.</para>
  /// </summary>
  [Fact]
  public void InRange_Method()
  {
    AssertionExtensions.Should(() => IComparableExpectations.InRange<int>(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => IComparableExpectations.InRange<int>(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    0.Expect().InRange(0, 0).Result.Should().BeTrue();
    0.Expect().InRange(int.MinValue, 0).Result.Should().BeTrue();
    0.Expect().InRange(int.MinValue, int.MaxValue).Result.Should().BeTrue();
    0.Expect().InRange(int.MaxValue, 0).Result.Should().BeFalse();
    0.Expect().InRange(int.MaxValue, int.MinValue).Result.Should().BeFalse();

    DateTime.Today.Expect().InRange(DateTime.Today, DateTime.Today).Result.Should().BeTrue();
    DateTime.Today.Expect().InRange(DateTime.MinValue, DateTime.Today).Result.Should().BeTrue();
    DateTime.Today.Expect().InRange(DateTime.MinValue, DateTime.MaxValue).Result.Should().BeTrue();
    DateTime.Today.Expect().InRange(DateTime.MaxValue, DateTime.Today).Result.Should().BeFalse();
    DateTime.Today.Expect().InRange(DateTime.MaxValue, DateTime.MinValue).Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableExpectations.OutOfRange{T}(IExpectation{T}, T, T)"/> method.</para>
  /// </summary>
  [Fact]
  public void OutOfRange_Method()
  {
    AssertionExtensions.Should(() => IComparableExpectations.OutOfRange<int>(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    0.Expect().OutOfRange(0, 0).Result.Should().BeFalse();
    0.Expect().OutOfRange(int.MinValue, 0).Result.Should().BeFalse();
    0.Expect().OutOfRange(int.MinValue, int.MaxValue).Result.Should().BeFalse();
    0.Expect().OutOfRange(int.MaxValue, 0).Result.Should().BeTrue();
    0.Expect().OutOfRange(int.MaxValue, int.MinValue).Result.Should().BeTrue();
    0.Expect().OutOfRange(1, int.MaxValue).Result.Should().BeTrue();
    0.Expect().OutOfRange(int.MinValue, -1).Result.Should().BeTrue();

    DateTime.Today.Expect().OutOfRange(DateTime.Today, DateTime.Today).Result.Should().BeFalse();
    DateTime.Today.Expect().OutOfRange(DateTime.MinValue, DateTime.Today).Result.Should().BeFalse();
    DateTime.Today.Expect().OutOfRange(DateTime.MinValue, DateTime.MaxValue).Result.Should().BeFalse();
    DateTime.Today.Expect().OutOfRange(DateTime.MaxValue, DateTime.Today).Result.Should().BeTrue();
    DateTime.Today.Expect().OutOfRange(DateTime.MaxValue, DateTime.MinValue).Result.Should().BeTrue();
    DateTime.Today.Expect().OutOfRange(DateTime.Today.AddDays(1), DateTime.MaxValue).Result.Should().BeTrue();
    DateTime.Today.Expect().OutOfRange(DateTime.MinValue, DateTime.Today.AddDays(-1)).Result.Should().BeTrue();
  }
}