﻿using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TimeSpanAssertions"/>.</para>
/// </summary>
public sealed class TimeSpanAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.Days(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Days_Method()
  {
    void Validate(TimeSpan timespan)
    {
      AssertionExtensions.Should(() => Assert.To.Days(timespan, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.Days(timespan, timespan.Days).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanAssertions.Days(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero}.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.Hours(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Hours_Method()
  {
    void Validate(TimeSpan timespan)
    {
      AssertionExtensions.Should(() => Assert.To.Hours(timespan, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.Hours(timespan, timespan.Hours).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanAssertions.Hours(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.Minutes(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Minutes_Method()
  {
    void Validate(TimeSpan timespan)
    {
      AssertionExtensions.Should(() => Assert.To.Minutes(timespan, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.Minutes(timespan, timespan.Minutes).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanAssertions.Minutes(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.Seconds(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Seconds_Method()
  {
    void Validate(TimeSpan timespan)
    {
      AssertionExtensions.Should(() => Assert.To.Seconds(timespan, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.Seconds(timespan, timespan.Seconds).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanAssertions.Seconds(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.Milliseconds(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Milliseconds_Method()
  {
    void Validate(TimeSpan timespan)
    {
      AssertionExtensions.Should(() => Assert.To.Milliseconds(timespan, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.Milliseconds(timespan, timespan.Milliseconds).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanAssertions.Milliseconds(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.TotalDays(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalDays_Method()
  {
    void Validate(TimeSpan timespan)
    {
      AssertionExtensions.Should(() => Assert.To.TotalDays(timespan, -1, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.TotalDays(timespan, (int) timespan.TotalDays).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanAssertions.TotalDays(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.TotalHours(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalHours_Method()
  {
    void Validate(TimeSpan timespan)
    {
      AssertionExtensions.Should(() => Assert.To.TotalHours(timespan, -1, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.TotalHours(timespan, (int) timespan.TotalHours).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanAssertions.TotalHours(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.TotalMinutes(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalMinutes_Method()
  {
    void Validate(TimeSpan timespan)
    {
      AssertionExtensions.Should(() => Assert.To.TotalMinutes(timespan, -1, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.TotalMinutes(timespan, (int) timespan.TotalMinutes).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanAssertions.TotalMinutes(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.TotalSeconds(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalSeconds_Method()
  {
    void Validate(TimeSpan timespan)
    {
      AssertionExtensions.Should(() => Assert.To.TotalSeconds(timespan, -1, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.TotalSeconds(timespan, (int) timespan.TotalSeconds).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanAssertions.TotalSeconds(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.TotalMilliseconds(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalMilliseconds_Method()
  {
    void Validate(TimeSpan timespan)
    {
      AssertionExtensions.Should(() => Assert.To.TotalMilliseconds(timespan, -1, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.TotalMilliseconds(timespan, (int) timespan.TotalMilliseconds).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanAssertions.TotalMilliseconds(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue, TimeSpan.Zero }.ForEach(Validate);
    }
  }
}