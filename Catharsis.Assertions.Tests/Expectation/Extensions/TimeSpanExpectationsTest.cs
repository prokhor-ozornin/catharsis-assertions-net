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
    void Validate(TimeSpan timespan)
    {
      timespan.Expect().Days(int.MinValue).Result.Should().BeFalse();
      timespan.Expect().Days(timespan.Days).Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.Days(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.Hours(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Hours_Method()
  {
    void Validate(TimeSpan timespan)
    {
      timespan.Expect().Hours(int.MinValue).Result.Should().BeFalse();
      timespan.Expect().Hours(timespan.Hours).Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.Hours(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.Minutes(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Minutes_Method()
  {
    void Validate(TimeSpan timespan)
    {
      timespan.Expect().Minutes(int.MinValue).Result.Should().BeFalse();
      timespan.Expect().Minutes(timespan.Minutes).Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.Minutes(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.Seconds(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Seconds_Method()
  {
    void Validate(TimeSpan timespan)
    {
      timespan.Expect().Seconds(int.MinValue).Result.Should().BeFalse();
      timespan.Expect().Seconds(timespan.Seconds).Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.Seconds(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.Milliseconds(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Milliseconds_Method()
  {
    void Validate(TimeSpan timespan)
    {
      timespan.Expect().Milliseconds(int.MinValue).Result.Should().BeFalse();
      timespan.Expect().Milliseconds(timespan.Milliseconds).Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.Milliseconds(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.TotalDays(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalDays_Method()
  {
    void Validate(TimeSpan timespan)
    {
      timespan.Expect().TotalDays(-1).Result.Should().BeFalse();
      timespan.Expect().TotalDays((int) timespan.TotalDays).Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.TotalDays(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.TotalHours(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalHours_Method()
  {
    void Validate(TimeSpan timespan)
    {
      timespan.Expect().TotalHours(-1).Result.Should().BeFalse();
      timespan.Expect().TotalHours((int) timespan.TotalHours).Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.TotalHours(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] {TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero}.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.TotalMinutes(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalMinutes_Method()
  {
    void Validate(TimeSpan timespan)
    {
      timespan.Expect().TotalMinutes(-1).Result.Should().BeFalse();
      timespan.Expect().TotalMinutes((int) timespan.TotalMinutes).Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.TotalMinutes(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.TotalSeconds(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalSeconds_Method()
  {
    void Validate(TimeSpan timespan)
    {
      timespan.Expect().TotalSeconds(-1).Result.Should().BeFalse();
      timespan.Expect().TotalSeconds((int) timespan.TotalSeconds).Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.TotalSeconds(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.TotalMilliseconds(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalMilliseconds_Method()
  {
    void Validate(TimeSpan timespan)
    {
      timespan.Expect().TotalMilliseconds(-1).Result.Should().BeFalse();
      timespan.Expect().TotalMilliseconds((int) timespan.TotalMilliseconds).Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanExpectations.TotalMilliseconds(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(Validate);
    }
  }
}