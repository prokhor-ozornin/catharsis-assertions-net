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
      AssertionExtensions.Should(() => TimeOnlyAssertions.Hour(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeOnly.MinValue, TimeOnly.MaxValue, DateTime.Now.ToTimeOnly(), DateTime.UtcNow.ToTimeOnly() }.ForEach(Validate);
    }

    return;

    static void Validate(TimeOnly time)
    {
      AssertionExtensions.Should(() => Assert.To.Hour(time, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.Hour(time, time.Hour).Should().NotBeNull().And.BeSameAs(Assert.To);
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
      AssertionExtensions.Should(() => TimeOnlyAssertions.Minute(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeOnly.MinValue, TimeOnly.MaxValue, DateTime.Now.ToTimeOnly(), DateTime.UtcNow.ToTimeOnly() }.ForEach(Validate);
    }

    return;

    static void Validate(TimeOnly time)
    {
      AssertionExtensions.Should(() => Assert.To.Minute(time, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.Minute(time, time.Minute).Should().NotBeNull().And.BeSameAs(Assert.To);
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
      AssertionExtensions.Should(() => TimeOnlyAssertions.Second(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeOnly.MinValue, TimeOnly.MaxValue, DateTime.Now.ToTimeOnly(), DateTime.UtcNow.ToTimeOnly() }.ForEach(Validate);
    }

    return;

    static void Validate(TimeOnly time)
    {
      AssertionExtensions.Should(() => Assert.To.Second(time, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.Second(time, time.Second).Should().NotBeNull().And.BeSameAs(Assert.To);
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
      AssertionExtensions.Should(() => TimeOnlyAssertions.Millisecond(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { TimeOnly.MinValue, TimeOnly.MaxValue, DateTime.Now.ToTimeOnly(), DateTime.UtcNow.ToTimeOnly() }.ForEach(Validate);
    }

    return;

    static void Validate(TimeOnly time)
    {
      AssertionExtensions.Should(() => Assert.To.Millisecond(time, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.Millisecond(time, time.Millisecond).Should().NotBeNull().And.BeSameAs(Assert.To);
    }
  }
}