using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DateTimeOffsetAssertions"/>.</para>
/// </summary>
/// <seealso cref="DateTimeOffsetAssertions"/>
public sealed class DateTimeOffsetAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Past(IAssertion, DateTimeOffset, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Past_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetAssertions.Past(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(date =>
      {
        Test(true, date);
        Test(true, date.AddSeconds(-1));
        Test(false, date.AddSeconds(1));
      });
    }

    return;

    static void Test(bool result, DateTimeOffset date)
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
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Future(IAssertion, DateTimeOffset, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Future_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetAssertions.Future(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(date =>
      {
        Test(true, date.AddSeconds(1));
        Test(false, date);
        Test(false, date.AddSeconds(-1));
      });
    }

    return;

    static void Test(bool result, DateTimeOffset date)
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
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.DayOfYear(IAssertion, DateTimeOffset, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfYear_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetAssertions.DayOfYear(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now }.ForEach(date =>
      {
        Test(true, date, date.DayOfYear);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTimeOffset date, int day)
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
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Year(IAssertion, DateTimeOffset, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Year_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetAssertions.Year(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now }.ForEach(date =>
      {
        Test(true, date, date.Year);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTimeOffset date, int year)
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
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Month(IAssertion, DateTimeOffset, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Month_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetAssertions.Month(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now }.ForEach(date =>
      {
        Test(true, date, date.Month);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTimeOffset date, int month)
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
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Day(IAssertion, DateTimeOffset, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Day_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetAssertions.Day(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now }.ForEach(date =>
      {
        Test(true, date, date.Day);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTimeOffset date, int day)
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
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Hour(IAssertion, DateTimeOffset, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Hour_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetAssertions.Hour(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now }.ForEach(date =>
      {
        Test(true, date, date.Hour);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTimeOffset date, int hour)
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
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Minute(IAssertion, DateTimeOffset, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Minute_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetAssertions.Minute(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now }.ForEach(date =>
      {
        Test(true, date, date.Minute);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTimeOffset date, int minute)
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
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Second(IAssertion, DateTimeOffset, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Second_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetAssertions.Second(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now }.ForEach(date =>
      {
        Test(true, date, date.Second);
        Test(false, date, int.MinValue);
      });
    }
    
    return;

    static void Test(bool result, DateTimeOffset date, int second)
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
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Millisecond(IAssertion, DateTimeOffset, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Millisecond_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetAssertions.Millisecond(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now }.ForEach(date =>
      {
        Test(true, date, date.Millisecond);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateTimeOffset date, int millisecond)
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
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.DayOfWeek(IAssertion, DateTimeOffset, DayOfWeek, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfWeek_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetAssertions.DayOfWeek(null, default, DayOfWeek.Monday)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now }.ForEach(date =>
      {
        Test(true, date, date.DayOfWeek);
        Test(false, date, date.DayOfWeek + 1);
      });
    }

    return;

    static void Test(bool result, DateTimeOffset date, DayOfWeek day)
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
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Offset(IAssertion, DateTimeOffset, TimeSpan, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Offset_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetAssertions.Offset(null, default, TimeSpan.Zero)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now }.ForEach(date =>
      {
        Test(true, date, date.Offset);
        Test(false, date, date.Offset.Add(TimeSpan.FromMilliseconds(1)));
      });
    }

    return;

    static void Test(bool result, DateTimeOffset date, TimeSpan offset)
    {
      if (result)
      {
        Assert.To.Offset(date, offset).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Offset(date, offset, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}