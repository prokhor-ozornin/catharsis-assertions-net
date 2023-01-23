using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests.Expectation.Extensions;

/// <summary>
///   <para>Tests set for class <see cref="DateTimeExpectations"/>.</para>
/// </summary>
public sealed class DateTimeExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Past(IExpectation{DateTime})"/> method.</para>
  /// </summary>
  [Fact]
  public void Past_Method()
  {
    AssertionExtensions.Should(() => DateTimeExpectations.Past(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Future(IExpectation{DateTime})"/> method.</para>
  /// </summary>
  [Fact]
  public void Future_Method()
  {
    AssertionExtensions.Should(() => DateTimeExpectations.Future(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.DayOfYear(IExpectation{DateTime}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfYear_Method()
  {
    AssertionExtensions.Should(() => DateTimeExpectations.DayOfYear(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Year(IExpectation{DateTime}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Year_Method()
  {
    AssertionExtensions.Should(() => DateTimeExpectations.Year(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Month(IExpectation{DateTime}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Month_Method()
  {
    AssertionExtensions.Should(() => DateTimeExpectations.Month(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Day(IExpectation{DateTime}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Day_Method()
  {
    AssertionExtensions.Should(() => DateTimeExpectations.Day(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Hour(IExpectation{DateTime}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Hour_Method()
  {
    AssertionExtensions.Should(() => DateTimeExpectations.Hour(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Minute(IExpectation{DateTime}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Minute_Method()
  {
    AssertionExtensions.Should(() => DateTimeExpectations.Minute(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Second(IExpectation{DateTime}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Second_Method()
  {
    AssertionExtensions.Should(() => DateTimeExpectations.Second(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Millisecond(IExpectation{DateTime}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Millisecond_Method()
  {
    AssertionExtensions.Should(() => DateTimeExpectations.Millisecond(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.DayOfWeek(IExpectation{DateTime}, DayOfWeek)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfWeek_Method()
  {
    AssertionExtensions.Should(() => DateTimeExpectations.DayOfWeek(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.LocalTime(IExpectation{DateTime})"/> method.</para>
  /// </summary>
  [Fact]
  public void LocalTime_Method()
  {
    AssertionExtensions.Should(() => DateTimeExpectations.LocalTime(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.UtcTime(IExpectation{DateTime})"/> method.</para>
  /// </summary>
  [Fact]
  public void UtcTime_Method()
  {
    AssertionExtensions.Should(() => DateTimeExpectations.UtcTime(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }
}