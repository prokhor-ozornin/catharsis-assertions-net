using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TimeSpanAssertions"/>.</para>
/// </summary>
public sealed class TimeSpanAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.Days(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Days_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanAssertions.Days(null, TimeSpan.Zero, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue }.ForEach(timespan =>
      {
        Validate(true, timespan, timespan.Days);
        Validate(false, timespan, 0);
      });
    }

    return;

    static void Validate(bool result, TimeSpan timespan, int days)
    {
      if (result)
      {
        Assert.To.Days(timespan, days).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Days(timespan, days, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.Hours(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Hours_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanAssertions.Hours(null, TimeSpan.Zero, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue }.ForEach(timespan =>
      {
        Validate(true, timespan, timespan.Hours);
        Validate(false, timespan, 0);
      });
    }

    return;

    static void Validate(bool result, TimeSpan timespan, int hours)
    {
      if (result)
      {
        Assert.To.Hours(timespan, hours).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Hours(timespan, hours, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.Minutes(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Minutes_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanAssertions.Minutes(null, TimeSpan.Zero, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue }.ForEach(timespan =>
      {
        Validate(true, timespan, timespan.Minutes);
        Validate(false, timespan, 0);
      });
    }

    return;

    static void Validate(bool result, TimeSpan timespan, int minutes)
    {
      if (result)
      {
        Assert.To.Minutes(timespan, minutes).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Minutes(timespan, minutes, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.Seconds(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Seconds_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanAssertions.Seconds(null, TimeSpan.Zero, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue }.ForEach(timespan =>
      {
        Validate(true, timespan, timespan.Seconds);
        Validate(false, timespan, 0);
      });
    }

    return;

    static void Validate(bool result, TimeSpan timespan, int seconds)
    {
      if (result)
      {
        Assert.To.Seconds(timespan, seconds).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Seconds(timespan, seconds, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.Milliseconds(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Milliseconds_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanAssertions.Milliseconds(null, TimeSpan.Zero, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue }.ForEach(timespan =>
      {
        Validate(true, timespan, timespan.Milliseconds);
        Validate(false, timespan, 0);
      });
    }

    return;

    static void Validate(bool result, TimeSpan timespan, int milliseconds)
    {
      if (result)
      {
        Assert.To.Milliseconds(timespan, milliseconds).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Milliseconds(timespan, milliseconds, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.TotalDays(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalDays_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanAssertions.TotalDays(null, TimeSpan.Zero, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue }.ForEach(timespan =>
      {
        Validate(true, timespan, (int) timespan.TotalDays);
        Validate(false, timespan, 0);
      });
    }

    return;

    static void Validate(bool result, TimeSpan timespan, int days)
    {
      if (result)
      {
        Assert.To.TotalDays(timespan, days).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.TotalDays(timespan, days, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.TotalHours(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalHours_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanAssertions.TotalHours(null, TimeSpan.Zero, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue }.ForEach(timespan =>
      {
        Validate(true, timespan, (int) timespan.TotalHours);
        Validate(false, timespan, 0);
      });
    }

    return;

    static void Validate(bool result, TimeSpan timespan, int hours)
    {
      if (result)
      {
        Assert.To.TotalHours(timespan, hours).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.TotalHours(timespan, hours, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.TotalMinutes(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalMinutes_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanAssertions.TotalMinutes(null, TimeSpan.Zero, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue }.ForEach(timespan =>
      {
        Validate(true, timespan, (int) timespan.TotalMinutes);
        Validate(false, timespan, 0);
      });
    }

    return;

    static void Validate(bool result, TimeSpan timespan, int minutes)
    {
      if (result)
      {
        Assert.To.TotalMinutes(timespan, minutes).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.TotalMinutes(timespan, minutes, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.TotalSeconds(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalSeconds_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanAssertions.TotalSeconds(null, TimeSpan.Zero, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue }.ForEach(timespan =>
      {
        Validate(true, timespan, (int) timespan.TotalSeconds);
        Validate(false, timespan, 0);
      });
    }

    return;

    static void Validate(bool result, TimeSpan timespan, int seconds)
    {
      if (result)
      {
        Assert.To.TotalSeconds(timespan, seconds).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.TotalSeconds(timespan, seconds, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.TotalMilliseconds(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void TotalMilliseconds_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeSpanAssertions.TotalMilliseconds(null, TimeSpan.Zero, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeSpan.MinValue, TimeSpan.MaxValue }.ForEach(timespan =>
      {
        Validate(true, timespan, (int) timespan.TotalMilliseconds);
        Validate(false, timespan, 0);
      });
    }

    return;

    static void Validate(bool result, TimeSpan timespan, int milliseconds)
    {
      if (result)
      {
        Assert.To.TotalMilliseconds(timespan, milliseconds).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.TotalMilliseconds(timespan, milliseconds, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}