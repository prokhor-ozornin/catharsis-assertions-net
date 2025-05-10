using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TimeSpanExpectations"/>.</para>
/// </summary>
public sealed class TimeSpanExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.Days(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Days_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.Days(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue }.ForEach(timespan =>
      {
        Test(true, timespan, timespan.Days);
        Test(false, timespan, 0);
      });
    }
    
    return;

    static void Test(bool result, TimeSpan timespan, int days) => timespan.Expect().Days(days).Should().BeOfType<Expectation<TimeSpan>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.Hours(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Hours_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.Hours(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue }.ForEach(timespan =>
      {
        Test(true, timespan, timespan.Hours);
        Test(false, timespan, 0);
      });
    }
    
    return;

    static void Test(bool result, TimeSpan timespan, int hours) => timespan.Expect().Hours(hours).Should().BeOfType<Expectation<TimeSpan>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.Minutes(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Minutes_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.Minutes(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue }.ForEach(timespan =>
      {
        Test(true, timespan, timespan.Minutes);
        Test(false, timespan, 0);
      });
    }

    return;

    static void Test(bool result, TimeSpan timespan, int minutes) => timespan.Expect().Minutes(minutes).Should().BeOfType<Expectation<TimeSpan>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.Seconds(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Seconds_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.Seconds(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue }.ForEach(timespan =>
      {
        Test(true, timespan, timespan.Seconds);
        Test(false, timespan, 0);
      });
    }

    return;

    static void Test(bool result, TimeSpan timespan, int seconds) => timespan.Expect().Seconds(seconds).Should().BeOfType<Expectation<TimeSpan>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.Milliseconds(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Milliseconds_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.Milliseconds(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue }.ForEach(timespan =>
      {
        Test(true, timespan, timespan.Milliseconds);
        Test(false, timespan, 0);
      });
    }

    return;

    static void Test(bool result, TimeSpan timespan, int milliseconds) => timespan.Expect().Milliseconds(milliseconds).Should().BeOfType<Expectation<TimeSpan>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.TotalDays(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalDays_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.TotalDays(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue }.ForEach(timespan =>
      {
        Test(true, timespan, (int) timespan.TotalDays);
        Test(false, timespan, 0);
      });
    }

    return;

    static void Test(bool result, TimeSpan timespan, int days) => timespan.Expect().TotalDays(days).Should().BeOfType<Expectation<TimeSpan>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.TotalHours(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalHours_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.TotalHours(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue }.ForEach(timespan =>
      {
        Test(true, timespan, (int) timespan.TotalHours);
        Test(false, timespan, 0);
      });
    }

    return;

    static void Test(bool result, TimeSpan timespan, int hours) => timespan.Expect().TotalHours(hours).Should().BeOfType<Expectation<TimeSpan>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.TotalMinutes(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalMinutes_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.TotalMinutes(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue }.ForEach(timespan =>
      {
        Test(true, timespan, (int) timespan.TotalMinutes);
        Test(false, timespan, 0);
      });
    }

    return;

    static void Test(bool result, TimeSpan timespan, int minutes) => timespan.Expect().TotalMinutes(minutes).Should().BeOfType<Expectation<TimeSpan>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.TotalSeconds(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalSeconds_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.TotalSeconds(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue }.ForEach(timespan =>
      {
        Test(true, timespan, (int) timespan.TotalSeconds);
        Test(false, timespan, 0);
      });
    }

    return;

    static void Test(bool result, TimeSpan timespan, int seconds) => timespan.Expect().TotalSeconds(seconds).Should().BeOfType<Expectation<TimeSpan>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.TotalMilliseconds(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalMilliseconds_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.TotalMilliseconds(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue }.ForEach(timespan =>
      {
        Test(true, timespan, (int) timespan.TotalMilliseconds);
        Test(false, timespan, 0);
      });
    }

    return;

    static void Test(bool result, TimeSpan timespan, int milliseconds) => timespan.Expect().TotalMilliseconds(milliseconds).Should().BeOfType<Expectation<TimeSpan>>().Which.Result.Should().Be(result);
  }
}