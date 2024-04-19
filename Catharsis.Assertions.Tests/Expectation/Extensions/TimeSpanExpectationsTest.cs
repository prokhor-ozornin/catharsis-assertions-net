using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TimeSpanExpectations"/>.</para>
/// </summary>
public sealed class TimeSpanExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.Days(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Days_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.Days(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(timespan =>
      {
        Validate(true, timespan, timespan.Days);
        Validate(false, timespan, int.MinValue);
      });
    }
    
    return;

    static void Validate(bool result, TimeSpan timespan, int days) => timespan.Expect().Days(days).Should().BeOfType<Expectation<TimeSpan>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.Hours(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Hours_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.Hours(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(timespan =>
      {
        Validate(true, timespan, timespan.Hours);
        Validate(false, timespan, int.MinValue);
      });
    }
    
    return;

    static void Validate(bool result, TimeSpan timespan, int hours) => timespan.Expect().Hours(hours).Should().BeOfType<Expectation<TimeSpan>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.Minutes(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Minutes_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.Minutes(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(timespan =>
      {
        Validate(true, timespan, timespan.Minutes);
        Validate(false, timespan, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, TimeSpan timespan, int minutes) => timespan.Expect().Minutes(minutes).Should().BeOfType<Expectation<TimeSpan>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.Seconds(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Seconds_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.Seconds(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(timespan =>
      {
        Validate(true, timespan, timespan.Seconds);
        Validate(false, timespan, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, TimeSpan timespan, int seconds) => timespan.Expect().Seconds(seconds).Should().BeOfType<Expectation<TimeSpan>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.Milliseconds(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Milliseconds_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.Milliseconds(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(timespan =>
      {
        Validate(true, timespan, timespan.Milliseconds);
        Validate(false, timespan, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, TimeSpan timespan, int milliseconds) => timespan.Expect().Milliseconds(milliseconds).Should().BeOfType<Expectation<TimeSpan>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.TotalDays(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalDays_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.TotalDays(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(timespan =>
      {
        Validate(true, timespan, (int) timespan.TotalDays);
        Validate(false, timespan, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, TimeSpan timespan, int days) => timespan.Expect().TotalDays(days).Should().BeOfType<Expectation<TimeSpan>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.TotalHours(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalHours_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.TotalHours(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(timespan =>
      {
        Validate(true, timespan, (int) timespan.TotalHours);
        Validate(false, timespan, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, TimeSpan timespan, int hours) => timespan.Expect().TotalHours(hours).Should().BeOfType<Expectation<TimeSpan>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.TotalMinutes(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalMinutes_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.TotalMinutes(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(timespan =>
      {
        Validate(true, timespan, (int) timespan.TotalMinutes);
        Validate(false, timespan, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, TimeSpan timespan, int minutes) => timespan.Expect().TotalMinutes(minutes).Should().BeOfType<Expectation<TimeSpan>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.TotalSeconds(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalSeconds_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.TotalSeconds(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(timespan =>
      {
        Validate(true, timespan, (int) timespan.TotalSeconds);
        Validate(false, timespan, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, TimeSpan timespan, int seconds) => timespan.Expect().TotalSeconds(seconds).Should().BeOfType<Expectation<TimeSpan>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.TotalMilliseconds(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalMilliseconds_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.TotalMilliseconds(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(timespan =>
      {
        Validate(true, timespan, (int) timespan.TotalMilliseconds);
        Validate(false, timespan, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, TimeSpan timespan, int milliseconds) => timespan.Expect().TotalMilliseconds(milliseconds).Should().BeOfType<Expectation<TimeSpan>>().Which.Result.Should().Be(result);
  }
}