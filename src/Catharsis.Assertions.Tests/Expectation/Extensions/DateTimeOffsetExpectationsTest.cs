using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DateTimeOffsetExpectations"/>.</para>
/// </summary>
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
        Validate(true, date);
        Validate(true, date.AddSeconds(-1));
        Validate(false, date.AddSeconds(1));
      });
    }

    return;

    static void Validate(bool result, DateTimeOffset date) => date.Expect().Past().Should().BeOfType<Expectation<DateTimeOffset>>().Which.Result.Should().Be(result);
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
        Validate(true, date.AddSeconds(1));
        Validate(false, date);
        Validate(false, date.AddSeconds(-1));
      });
    }

    return;

    static void Validate(bool result, DateTimeOffset date) => date.Expect().Future().Should().BeOfType<Expectation<DateTimeOffset>>().Which.Result.Should().Be(result);
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
        Validate(true, date, date.DayOfYear);
        Validate(false, date, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, DateTimeOffset date, int day) => date.Expect().DayOfYear(day).Should().BeOfType<Expectation<DateTimeOffset>>().Which.Result.Should().Be(result);
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
        Validate(true, date, date.Year);
        Validate(false, date, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, DateTimeOffset date, int year) => date.Expect().Year(year).Should().BeOfType<Expectation<DateTimeOffset>>().Which.Result.Should().Be(result);
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
        Validate(true, date, date.Month);
        Validate(false, date, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, DateTimeOffset date, int month) => date.Expect().Month(month).Should().BeOfType<Expectation<DateTimeOffset>>().Which.Result.Should().Be(result);
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
        Validate(true, date, date.Day);
        Validate(false, date, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, DateTimeOffset date, int day) => date.Expect().Day(day).Should().BeOfType<Expectation<DateTimeOffset>>().Which.Result.Should().Be(result);
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
        Validate(true, date, date.Hour);
        Validate(false, date, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, DateTimeOffset date, int hour) => date.Expect().Hour(hour).Should().BeOfType<Expectation<DateTimeOffset>>().Which.Result.Should().Be(result);
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
        Validate(true, date, date.Minute);
        Validate(false, date, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, DateTimeOffset date, int minute) => date.Expect().Minute(minute).Should().BeOfType<Expectation<DateTimeOffset>>().Which.Result.Should().Be(result);
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
        Validate(true, date, date.Second);
        Validate(false, date, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, DateTimeOffset date, int second) => date.Expect().Second(second).Should().BeOfType<Expectation<DateTimeOffset>>().Which.Result.Should().Be(result);
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
        Validate(true, date, date.Millisecond);
        Validate(false, date, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, DateTimeOffset date, int millisecond) => date.Expect().Millisecond(millisecond).Should().BeOfType<Expectation<DateTimeOffset>>().Which.Result.Should().Be(result);
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
        Validate(true, date, date.DayOfWeek);
        Validate(false, date, date.DayOfWeek + 1);
      });
    }

    return;

    static void Validate(bool result, DateTimeOffset date, DayOfWeek day) => date.Expect().DayOfWeek(day).Should().BeOfType<Expectation<DateTimeOffset>>().Which.Result.Should().Be(result);
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
        Validate(true, date, date.Offset);
        Validate(false, date, date.Offset.Add(TimeSpan.FromMilliseconds(1)));
      });
    }

    return;

    static void Validate(bool result, DateTimeOffset date, TimeSpan offset) => date.Expect().Offset(offset).Should().BeOfType<Expectation<DateTimeOffset>>().Which.Result.Should().Be(result);
  }
}