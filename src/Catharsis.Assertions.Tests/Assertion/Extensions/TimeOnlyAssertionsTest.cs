using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TimeOnlyAssertions"/>.</para>
/// </summary>
public sealed class TimeOnlyAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TimeOnlyAssertions.Hour(IAssertion, TimeOnly, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Hour_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeOnlyAssertions.Hour(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeOnly.MinValue, TimeOnly.MaxValue, DateTime.Now.ToTimeOnly() }.ForEach(time =>
      {
        Validate(true, time, time.Hour);
        Validate(false, time, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, TimeOnly time, int hour)
    {
      if (result)
      {
        Assert.To.Hour(time, hour).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Hour(time, hour, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeOnlyAssertions.Minute(IAssertion, TimeOnly, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Minute_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeOnlyAssertions.Minute(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeOnly.MinValue, TimeOnly.MaxValue, DateTime.Now.ToTimeOnly() }.ForEach(time =>
      {
        Validate(true, time, time.Minute);
        Validate(false, time, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, TimeOnly time, int minute)
    {
      if (result)
      {
        Assert.To.Minute(time, minute).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Minute(time, minute, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeOnlyAssertions.Second(IAssertion, TimeOnly, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Second_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeOnlyAssertions.Second(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeOnly.MinValue, TimeOnly.MaxValue, DateTime.Now.ToTimeOnly() }.ForEach(time =>
      {
        Validate(true, time, time.Second);
        Validate(false, time, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, TimeOnly time, int second)
    {
      if (result)
      {
        Assert.To.Second(time, second).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Second(time, second, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeOnlyAssertions.Millisecond(IAssertion, TimeOnly, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Millisecond_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeOnlyAssertions.Millisecond(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeOnly.MinValue, TimeOnly.MaxValue, DateTime.Now.ToTimeOnly() }.ForEach(time =>
      {
        Validate(true, time, time.Millisecond);
        Validate(false, time, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, TimeOnly time, int millisecond)
    {
      if (result)
      {
        Assert.To.Millisecond(time, millisecond).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Millisecond(time, millisecond, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}