using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DateTimeOffsetExpectations"/>.</para>
/// </summary>
public sealed class DateTimeOffsetExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.Past(IExpectation{DateTimeOffset})"/> method.</para>
  /// </summary>
  [Fact]
  public void Past_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetExpectations.Past(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.Future(IExpectation{DateTimeOffset})"/> method.</para>
  /// </summary>
  [Fact]
  public void Future_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetExpectations.Future(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.DayOfYear(IExpectation{DateTimeOffset}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfYear_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetExpectations.DayOfYear(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.Year(IExpectation{DateTimeOffset}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Year_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetExpectations.Year(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.Month(IExpectation{DateTimeOffset}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Month_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetExpectations.Month(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.DayOfYear(IExpectation{DateTimeOffset}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Day_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetExpectations.Day(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.Hour(IExpectation{DateTimeOffset}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Hour_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetExpectations.Hour(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.Minute(IExpectation{DateTimeOffset}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Minute_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetExpectations.Minute(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.Second(IExpectation{DateTimeOffset}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Second_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetExpectations.Second(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.Millisecond(IExpectation{DateTimeOffset}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Millisecond_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetExpectations.Millisecond(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.DayOfWeek(IExpectation{DateTimeOffset}, DayOfWeek)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfWeek_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetExpectations.DayOfWeek(null, DayOfWeek.Monday)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.Offset(IExpectation{DateTimeOffset}, TimeSpan)"/> method.</para>
  /// </summary>
  [Fact]
  public void Offset_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetExpectations.Offset(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }
}