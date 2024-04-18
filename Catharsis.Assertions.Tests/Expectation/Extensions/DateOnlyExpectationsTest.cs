using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DateOnlyExpectations"/>.</para>
/// </summary>
public sealed class DateOnlyExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DateOnlyExpectations.DayOfYear(IExpectation{DateOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfYear_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateOnlyExpectations.DayOfYear(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateOnly.MinValue, DateOnly.MaxValue, DateTime.Now.ToDateOnly() }.ForEach(date =>
      {
        Validate(true, date, date.DayOfYear);
        Validate(false, date, default);
      });
    }

    return;

    static void Validate(bool result, DateOnly date, int day) => date.Expect().DayOfYear(day).Should().BeOfType<Expectation<DateOnly>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateOnlyExpectations.Year(IExpectation{DateOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Year_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateOnlyExpectations.Year(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateOnly.MinValue, DateOnly.MaxValue, DateTime.Now.ToDateOnly() }.ForEach(date =>
      {
        Validate(true, date, date.Year);
        Validate(false, date, default);
      });
    }

    return;

    static void Validate(bool result, DateOnly date, int year) => date.Expect().Year(year).Should().BeOfType<Expectation<DateOnly>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateOnlyExpectations.Month(IExpectation{DateOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Month_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateOnlyExpectations.Month(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateOnly.MinValue, DateOnly.MaxValue, DateTime.Now.ToDateOnly() }.ForEach(date =>
      {
        Validate(true, date, date.Month);
        Validate(false, date, default);
      });
    }

    return;

    static void Validate(bool result, DateOnly date, int month) => date.Expect().Month(month).Should().BeOfType<Expectation<DateOnly>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateOnlyExpectations.Day(IExpectation{DateOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Day_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateOnlyExpectations.Day(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] {DateOnly.MinValue, DateOnly.MaxValue, DateTime.Now.ToDateOnly() }.ForEach(date =>
      {
        Validate(true, date, date.Day);
        Validate(false, date, default);
      });
    }

    return;

    static void Validate(bool result, DateOnly date, int day) => date.Expect().Day(day).Should().BeOfType<Expectation<DateOnly>>().Which.Result.Should().Be(result);
  }
}