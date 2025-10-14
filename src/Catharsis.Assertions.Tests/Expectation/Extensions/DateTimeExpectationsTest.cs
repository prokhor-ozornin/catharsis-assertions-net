using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DateTimeExpectations"/>.</para>
/// </summary>
/// <seealso cref="DateTimeExpectations"/>
public sealed class DateTimeExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Past(IExpectation{DateTime})"/> method.</para>
  /// </summary>
  [Fact]
  public void Past_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeExpectations.Past(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTime.Now, DateTime.UtcNow }.ForEach(date =>
      {
        Test(true, date);
        Test(true, date.AddSeconds(-1));
        Test(false, date.AddSeconds(1));
      });
    }

    return;

    static void Test(bool result, DateTime date) => date.Expect().Past().Should().BeOfType<Expectation<DateTime>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Future(IExpectation{DateTime})"/> method.</para>
  /// </summary>
  [Fact]
  public void Future_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeExpectations.Future(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTime.Now, DateTime.UtcNow }.ForEach(date =>
      {
        Test(true, date.AddSeconds(1));
        Test(false, date);
        Test(false, date.AddSeconds(-1));
      });
    }

    return;

    static void Test(bool result, DateTime date) => date.Expect().Future().Should().BeOfType<Expectation<DateTime>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.DayOfYear(IExpectation{DateTime}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfYear_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeExpectations.DayOfYear(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.Today }.ForEach(date =>
      {
        Test(true, date, date.DayOfYear);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTime date, int day) => date.Expect().DayOfYear(day).Should().BeOfType<Expectation<DateTime>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Year(IExpectation{DateTime}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Year_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeExpectations.Year(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.Today }.ForEach(date =>
      {
        Test(true, date, date.Year);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTime date, int year) => date.Expect().Year(year).Should().BeOfType<Expectation<DateTime>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Month(IExpectation{DateTime}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Month_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeExpectations.Month(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.Today }.ForEach(date =>
      {
        Test(true, date, date.Month);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTime date, int month) => date.Expect().Month(month).Should().BeOfType<Expectation<DateTime>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Day(IExpectation{DateTime}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Day_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeExpectations.Month(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.Today }.ForEach(date =>
      {
        Test(true, date, date.Day);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTime date, int day) => date.Expect().Day(day).Should().BeOfType<Expectation<DateTime>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Hour(IExpectation{DateTime}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Hour_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeExpectations.Hour(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.Today }.ForEach(date =>
      {
        Test(true, date, date.Hour);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTime date, int hour) => date.Expect().Hour(hour).Should().BeOfType<Expectation<DateTime>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Minute(IExpectation{DateTime}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Minute_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeExpectations.Minute(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.Today }.ForEach(date =>
      {
        Test(true, date, date.Minute);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTime date, int minute) => date.Expect().Minute(minute).Should().BeOfType<Expectation<DateTime>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Second(IExpectation{DateTime}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Second_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeExpectations.Second(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.Today }.ForEach(date =>
      {
        Test(true, date, date.Second);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTime date, int second) => date.Expect().Second(second).Should().BeOfType<Expectation<DateTime>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Millisecond(IExpectation{DateTime}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Millisecond_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeExpectations.Millisecond(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.Today }.ForEach(date =>
      {
        Test(true, date, date.Millisecond);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTime date, int millisecond) => date.Expect().Millisecond(millisecond).Should().BeOfType<Expectation<DateTime>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.DayOfWeek(IExpectation{DateTime}, DayOfWeek)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfWeek_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeExpectations.DayOfWeek(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.Today }.ForEach(date =>
      {
        Test(true, date, date.DayOfWeek);
        Test(false, date, date.DayOfWeek + 1);
      });
    }

    return;

    static void Test(bool result, DateTime date, DayOfWeek day) => date.Expect().DayOfWeek(day).Should().BeOfType<Expectation<DateTime>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.LocalTime(IExpectation{DateTime})"/> method.</para>
  /// </summary>
  [Fact]
  public void LocalTime_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeExpectations.LocalTime(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      Test(true, DateTime.Now);
      Test(true, DateTime.Today);
      Test(false, DateTime.MinValue);
      Test(false, DateTime.MaxValue);
    }

    return;

    static void Test(bool result, DateTime date) => date.Expect().LocalTime().Should().BeOfType<Expectation<DateTime>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.UtcTime(IExpectation{DateTime})"/> method.</para>
  /// </summary>
  [Fact]
  public void UtcTime_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeExpectations.UtcTime(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      Test(true, DateTime.UtcNow);
      Test(false, DateTime.MinValue);
      Test(false, DateTime.MaxValue);
      Test(false, DateTime.Now);
      Test(false, DateTime.Today);
    }

    return;

    static void Test(bool result, DateTime date) => date.Expect().UtcTime().Should().BeOfType<Expectation<DateTime>>().Which.Result.Should().Be(result);
  }
}