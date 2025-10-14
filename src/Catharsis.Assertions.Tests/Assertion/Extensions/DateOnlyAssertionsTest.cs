using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DateOnlyAssertions"/>.</para>
/// </summary>
/// <seealso cref="DateOnlyAssertions"/>
public sealed class DateOnlyAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DateOnlyAssertions.DayOfYear(IAssertion, DateOnly, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfYear_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateOnlyAssertions.DayOfYear(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateOnly.MinValue, DateOnly.MaxValue, DateTime.Now.ToDateOnly() }.ForEach(date =>
      {
        Test(true, date, date.DayOfYear);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateOnly date, int day)
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
  ///   <para>Performs testing of <see cref="DateOnlyAssertions.Year(IAssertion, DateOnly, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Year_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateOnlyAssertions.Year(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateOnly.MinValue, DateOnly.MaxValue, DateTime.Now.ToDateOnly() }.ForEach(date =>
      {
        Test(true, date, date.Year);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateOnly date, int day)
    {
      if (result)
      {
        Assert.To.Year(date, day).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Year(date, day, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateOnlyAssertions.Month(IAssertion, DateOnly, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Month_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateOnlyAssertions.Month(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateOnly.MinValue, DateOnly.MaxValue, DateTime.Now.ToDateOnly() }.ForEach(date =>
      {
        Test(true, date, date.Month);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateOnly date, int day)
    {
      if (result)
      {
        Assert.To.Month(date, day).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Month(date, day, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateOnlyAssertions.Day(IAssertion, DateOnly, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Day_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateOnlyAssertions.Day(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] {DateOnly.MinValue, DateOnly.MaxValue, DateTime.Now.ToDateOnly() }.ForEach(date =>
      {
        Test(true, date, date.Day);
        Test(false, date, int.MinValue);
      });
    }

    return;

    static void Test(bool result, DateOnly date, int day)
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
}