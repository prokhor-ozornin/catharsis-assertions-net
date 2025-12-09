using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DateTimeOffsetExpectations"/>.</para>
/// </summary>
/// <seealso cref="DateTimeOffsetExpectations"/>
public sealed class DateTimeOffsetExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.Past(IExpectation{DateTimeOffset})"/> method.</para>
  /// </summary>
  [Fact]
  public void Past_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetExpectations.Past(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(date =>
      {
        Test(true, date);
        Test(true, date.AddSeconds(-1));
        Test(false, date.AddSeconds(1));
      });
    }

    return;

    static void Test(bool result, DateTimeOffset date) => date.Expect().Past().Should().BeOfType<Expectation<DateTimeOffset>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.Future(IExpectation{DateTimeOffset})"/> method.</para>
  /// </summary>
  [Fact]
  public void Future_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetExpectations.Future(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(date =>
      {
        Test(true, date.AddSeconds(1));
        Test(false, date);
        Test(false, date.AddSeconds(-1));
      });
    }

    return;

    static void Test(bool result, DateTimeOffset date) => date.Expect().Future().Should().BeOfType<Expectation<DateTimeOffset>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.DayOfYear(IExpectation{DateTimeOffset}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfYear_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetExpectations.DayOfYear(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now }.ForEach(date =>
      {
        Test(true, date, date.DayOfYear);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTimeOffset date, int day) => date.Expect().DayOfYear(day).Should().BeOfType<Expectation<DateTimeOffset>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.Year(IExpectation{DateTimeOffset}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Year_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetExpectations.Year(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now }.ForEach(date =>
      {
        Test(true, date, date.Year);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTimeOffset date, int year) => date.Expect().Year(year).Should().BeOfType<Expectation<DateTimeOffset>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.Month(IExpectation{DateTimeOffset}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Month_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetExpectations.Month(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now }.ForEach(date =>
      {
        Test(true, date, date.Month);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTimeOffset date, int month) => date.Expect().Month(month).Should().BeOfType<Expectation<DateTimeOffset>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.DayOfYear(IExpectation{DateTimeOffset}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Day_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetExpectations.Day(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now }.ForEach(date =>
      {
        Test(true, date, date.Day);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTimeOffset date, int day) => date.Expect().Day(day).Should().BeOfType<Expectation<DateTimeOffset>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.Hour(IExpectation{DateTimeOffset}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Hour_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetExpectations.Hour(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now }.ForEach(date =>
      {
        Test(true, date, date.Hour);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTimeOffset date, int hour) => date.Expect().Hour(hour).Should().BeOfType<Expectation<DateTimeOffset>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.Minute(IExpectation{DateTimeOffset}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Minute_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetExpectations.Minute(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now }.ForEach(date =>
      {
        Test(true, date, date.Minute);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTimeOffset date, int minute) => date.Expect().Minute(minute).Should().BeOfType<Expectation<DateTimeOffset>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.Second(IExpectation{DateTimeOffset}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Second_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetExpectations.Second(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now }.ForEach(date =>
      {
        Test(true, date, date.Second);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTimeOffset date, int second) => date.Expect().Second(second).Should().BeOfType<Expectation<DateTimeOffset>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.Millisecond(IExpectation{DateTimeOffset}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Millisecond_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetExpectations.Millisecond(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now }.ForEach(date =>
      {
        Test(true, date, date.Millisecond);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTimeOffset date, int millisecond) => date.Expect().Millisecond(millisecond).Should().BeOfType<Expectation<DateTimeOffset>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.DayOfWeek(IExpectation{DateTimeOffset}, DayOfWeek)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfWeek_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetExpectations.DayOfWeek(null, DayOfWeek.Monday)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now }.ForEach(date =>
      {
        Test(true, date, date.DayOfWeek);
        Test(false, date, date.DayOfWeek + 1);
      });
    }

    return;

    static void Test(bool result, DateTimeOffset date, DayOfWeek day) => date.Expect().DayOfWeek(day).Should().BeOfType<Expectation<DateTimeOffset>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.Offset(IExpectation{DateTimeOffset}, TimeSpan)"/> method.</para>
  /// </summary>
  [Fact]
  public void Offset_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetExpectations.Offset(null, TimeSpan.Zero)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now }.ForEach(date =>
      {
        Test(true, date, date.Offset);
        Test(false, date, date.Offset.Add(TimeSpan.FromMilliseconds(1)));
      });
    }

    return;

    static void Test(bool result, DateTimeOffset date, TimeSpan offset) => date.Expect().Offset(offset).Should().BeOfType<Expectation<DateTimeOffset>>().Which.Result.Should().Be(result);
  }
}