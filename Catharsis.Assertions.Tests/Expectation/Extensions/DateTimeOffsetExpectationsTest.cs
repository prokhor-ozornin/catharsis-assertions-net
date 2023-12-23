using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetExpectations.Past(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(Validate);
    }

    return;

    static void Validate(DateTimeOffset date)
    {
      date.AddSeconds(-1).Expect().Past().Result.Should().BeTrue();
      date.Expect().Past().Result.Should().BeTrue();
      date.AddSeconds(1).Expect().Past().Result.Should().BeFalse();
    }
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

      new[] { DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(Validate);
    }

    return;

    static void Validate(DateTimeOffset date)
    {
      date.AddSeconds(1).Expect().Future().Result.Should().BeTrue();
      date.AddSeconds(-1).Expect().Future().Result.Should().BeFalse();
      date.Expect().Future().Result.Should().BeFalse();
    }
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

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(Validate);
    }

    return;

    static void Validate(DateTimeOffset date)
    {
      date.Expect().DayOfYear(int.MinValue).Result.Should().BeFalse();
      date.Expect().DayOfYear(date.DayOfYear).Result.Should().BeTrue();
    }
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

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(Validate);
    }

    return;

    static void Validate(DateTimeOffset date)
    {
      date.Expect().Year(int.MinValue).Result.Should().BeFalse();
      date.Expect().Year(date.Year).Result.Should().BeTrue();
    }
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

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(Validate);
    }

    return;

    static void Validate(DateTimeOffset date)
    {
      date.Expect().Month(int.MinValue).Result.Should().BeFalse();
      date.Expect().Month(date.Month).Result.Should().BeTrue();
    }
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

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(Validate);
    }

    return;

    static void Validate(DateTimeOffset date)
    {
      date.Expect().DayOfYear(int.MinValue).Result.Should().BeFalse();
      date.Expect().DayOfYear(date.DayOfYear).Result.Should().BeTrue();
    }
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

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(Validate);
    }

    return;

    static void Validate(DateTimeOffset date)
    {
      date.Expect().Hour(int.MinValue).Result.Should().BeFalse();
      date.Expect().Hour(date.Hour).Result.Should().BeTrue();
    }
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

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(Validate);
    }

    return;

    static void Validate(DateTimeOffset date)
    {
      date.Expect().Minute(int.MinValue).Result.Should().BeFalse();
      date.Expect().Minute(date.Minute).Result.Should().BeTrue();
    }
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

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(Validate);
    }

    return;

    static void Validate(DateTimeOffset date)
    {
      date.Expect().Second(int.MinValue).Result.Should().BeFalse();
      date.Expect().Second(date.Second).Result.Should().BeTrue();
    }
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

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(Validate);
    }
    
    return;

    static void Validate(DateTimeOffset date)
    {
      date.Expect().Millisecond(int.MinValue).Result.Should().BeFalse();
      date.Expect().Millisecond(date.Millisecond).Result.Should().BeTrue();
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.DayOfWeek(IExpectation{DateTimeOffset}, DayOfWeek)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfWeek_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetExpectations.DayOfWeek(null, DayOfWeek.Monday)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    DateTimeOffset.MinValue.With(date =>
    {
      date.Expect().DayOfWeek(date.DayOfWeek).Result.Should().BeTrue();
      date.Expect().DayOfWeek(date.DayOfWeek + 1).Result.Should().BeFalse();
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetExpectations.Offset(IExpectation{DateTimeOffset}, TimeSpan)"/> method.</para>
  /// </summary>
  [Fact]
  public void Offset_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetExpectations.Offset(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(Validate);
    }

    return;

    static void Validate(DateTimeOffset date)
    {
      date.Expect().Offset(TimeSpan.MinValue).Result.Should().BeFalse();
      date.Expect().Offset(date.Offset).Result.Should().BeTrue();
    }
  }
}