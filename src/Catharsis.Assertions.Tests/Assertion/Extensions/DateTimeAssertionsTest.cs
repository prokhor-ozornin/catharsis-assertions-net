using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DateTimeAssertions"/>.</para>
/// </summary>
public sealed class DateTimeAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.Past(IAssertion, DateTime, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Past_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeAssertions.Past(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTime.Now, DateTime.UtcNow }.ForEach(date =>
      {
        Test(true, date);
        Test(true, date.AddSeconds(-1));
        Test(false, date.AddSeconds(1));
      });
    }

    return;

    static void Test(bool result, DateTime date)
    {
      if (result)
      {
        Assert.To.Past(date).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Past(date, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.Future(IAssertion, DateTime, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Future_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeAssertions.Future(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTime.Now, DateTime.UtcNow }.ForEach(date =>
      {
        Test(true, date.AddSeconds(1));
        Test(false, date);
        Test(false, date.AddSeconds(-1));
      });
    }

    return;

    static void Test(bool result, DateTime date)
    {
      if (result)
      {
        Assert.To.Future(date).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Future(date, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.DayOfYear(IAssertion, DateTime, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfYear_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeAssertions.DayOfYear(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.Today }.ForEach(date =>
      {
        Test(true, date, date.DayOfYear);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTime date, int day)
    {
      if (result)
      {
        Assert.To.DayOfYear(date, day).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.DayOfYear(date, day, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.Year(IAssertion, DateTime, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Year_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeAssertions.Year(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.Today }.ForEach(date =>
      {
        Test(true, date, date.Year);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTime date, int year)
    {
      if (result)
      {
        Assert.To.Year(date, year).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Year(date, year, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.Month(IAssertion, DateTime, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Month_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeAssertions.Month(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.Today }.ForEach(date =>
      {
        Test(true, date, date.Month);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTime date, int month)
    {
      if (result)
      {
        Assert.To.Month(date, month).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Month(date, month, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.Day(IAssertion, DateTime, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Day_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeAssertions.Day(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.Today }.ForEach(date =>
      {
        Test(true, date, date.Day);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTime date, int day)
    {
      if (result)
      {
        Assert.To.Day(date, day).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Day(date, day, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.Hour(IAssertion, DateTime, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Hour_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeAssertions.Hour(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.Today }.ForEach(date =>
      {
        Test(true, date, date.Hour);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTime date, int hour)
    {
      if (result)
      {
        Assert.To.Hour(date, hour).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Hour(date, hour, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.Minute(IAssertion, DateTime, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Minute_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeAssertions.Minute(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.Today }.ForEach(date =>
      {
        Test(true, date, date.Minute);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTime date, int minute)
    {
      if (result)
      {
        Assert.To.Minute(date, minute).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Minute(date, minute, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.Second(IAssertion, DateTime, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Second_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeAssertions.Second(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.Today }.ForEach(date =>
      {
        Test(true, date, date.Second);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTime date, int second)
    {
      if (result)
      {
        Assert.To.Second(date, second).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Second(date, second, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.Millisecond(IAssertion, DateTime, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Millisecond_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeAssertions.Millisecond(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.Today }.ForEach(date =>
      {
        Test(true, date, date.Millisecond);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTime date, int millisecond)
    {
      if (result)
      {
        Assert.To.Millisecond(date, millisecond).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Millisecond(date, millisecond, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.DayOfWeek(IAssertion, DateTime, DayOfWeek, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfWeek_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeAssertions.DayOfWeek(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.Today }.ForEach(date =>
      {
        Test(true, date, date.DayOfWeek);
        Test(false, date, date.DayOfWeek + 1);
      });
    }

    return;

    static void Test(bool result, DateTime date, DayOfWeek day)
    {
      if (result)
      {
        Assert.To.DayOfWeek(date, day).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.DayOfWeek(date, day, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.LocalTime(IAssertion, DateTime, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void LocalTime_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeAssertions.LocalTime(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      Test(true, DateTime.Now);
      Test(true, DateTime.Today);
      Test(false, DateTime.MinValue);
      Test(false, DateTime.MaxValue);
    }

    return;

    static void Test(bool result, DateTime date)
    {
      if (result)
      {
        Assert.To.LocalTime(date).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.LocalTime(date, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.UtcTime(IAssertion, DateTime, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void UtcTime_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeAssertions.UtcTime(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      Test(true, DateTime.UtcNow);
      Test(false, DateTime.MinValue);
      Test(false, DateTime.MaxValue);
      Test(false, DateTime.Now);
      Test(false, DateTime.Today);
    }

    return;

    static void Test(bool result, DateTime date)
    {
      if (result)
      {
        Assert.To.UtcTime(date).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.UtcTime(date, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}