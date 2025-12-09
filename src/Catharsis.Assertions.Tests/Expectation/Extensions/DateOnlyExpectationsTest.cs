using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DateOnlyExpectations"/>.</para>
/// </summary>
/// <seealso cref="DateOnlyExpectations"/>
public sealed class DateOnlyExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DateOnlyExpectations.DayOfYear(IExpectation{DateOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfYear_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateOnlyExpectations.DayOfYear(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateOnly.MinValue, DateOnly.MaxValue, DateTime.Now.ToDateOnly() }.ForEach(date =>
      {
        Test(true, date, date.DayOfYear);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateOnly date, int day) => date.Expect().DayOfYear(day).Should().BeOfType<Expectation<DateOnly>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateOnlyExpectations.Year(IExpectation{DateOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Year_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateOnlyExpectations.Year(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateOnly.MinValue, DateOnly.MaxValue, DateTime.Now.ToDateOnly() }.ForEach(date =>
      {
        Test(true, date, date.Year);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateOnly date, int year) => date.Expect().Year(year).Should().BeOfType<Expectation<DateOnly>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateOnlyExpectations.Month(IExpectation{DateOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Month_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateOnlyExpectations.Month(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateOnly.MinValue, DateOnly.MaxValue, DateTime.Now.ToDateOnly() }.ForEach(date =>
      {
        Test(true, date, date.Month);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateOnly date, int month) => date.Expect().Month(month).Should().BeOfType<Expectation<DateOnly>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateOnlyExpectations.Day(IExpectation{DateOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Day_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateOnlyExpectations.Day(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] {DateOnly.MinValue, DateOnly.MaxValue, DateTime.Now.ToDateOnly() }.ForEach(date =>
      {
        Test(true, date, date.Day);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateOnly date, int day) => date.Expect().Day(day).Should().BeOfType<Expectation<DateOnly>>().Which.Result.Should().Be(result);
  }
}