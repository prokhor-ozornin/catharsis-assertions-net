using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DateTimeAssertions"/>.</para>
/// </summary>
public sealed class DateTimeAssertionsTest : UnitTest
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

      new[] { DateTime.Now, DateTime.UtcNow }.ForEach(Validate);
    }

    return;

    static void Validate(DateTime date)
    {
      Assert.To.Past(date.AddSeconds(-1)).Should().NotBeNull().And.BeSameAs(Assert.To);
      Assert.To.Past(date).Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.Past(date.AddSeconds(1), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
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

      new[] { DateTime.Now, DateTime.UtcNow }.ForEach(Validate);
    }

    return;

    static void Validate(DateTime date)
    {
      Assert.To.Future(date.AddSeconds(1)).Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.Future(date.AddSeconds(-1), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      AssertionExtensions.Should(() => Assert.To.Future(date, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
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
      AssertionExtensions.Should(() => DateTimeAssertions.DayOfYear(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.UtcNow }.ForEach(Validate);
    }

    return;

    static void Validate(DateTime date)
    {
      AssertionExtensions.Should(() => Assert.To.DayOfYear(date, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.DayOfYear(date, date.DayOfYear).Should().NotBeNull().And.BeSameAs(Assert.To);
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
      AssertionExtensions.Should(() => DateTimeAssertions.Year(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.UtcNow }.ForEach(Validate);
    }

    return;

    static void Validate(DateTime date)
    {
      AssertionExtensions.Should(() => Assert.To.Year(date, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.Year(date, date.Year).Should().NotBeNull().And.BeSameAs(Assert.To);
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
      AssertionExtensions.Should(() => DateTimeAssertions.Month(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.UtcNow }.ForEach(Validate);
    }

    return;

    static void Validate(DateTime date)
    {
      AssertionExtensions.Should(() => Assert.To.Month(date, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.Month(date, date.Month).Should().NotBeNull().And.BeSameAs(Assert.To);
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
      AssertionExtensions.Should(() => DateTimeAssertions.Day(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.UtcNow }.ForEach(Validate);
    }

    return;

    static void Validate(DateTime date)
    {
      AssertionExtensions.Should(() => Assert.To.Day(date, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.Day(date, date.Day).Should().NotBeNull().And.BeSameAs(Assert.To);
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
      AssertionExtensions.Should(() => DateTimeAssertions.Hour(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.UtcNow }.ForEach(Validate);
    }

    return;

    static void Validate(DateTime date)
    {
      AssertionExtensions.Should(() => Assert.To.Hour(date, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.Hour(date, date.Hour).Should().NotBeNull().And.BeSameAs(Assert.To);
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
      AssertionExtensions.Should(() => DateTimeAssertions.Minute(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.UtcNow }.ForEach(Validate);
    }

    return;

    static void Validate(DateTime date)
    {
      AssertionExtensions.Should(() => Assert.To.Minute(date, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.Minute(date, date.Minute).Should().NotBeNull().And.BeSameAs(Assert.To);
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
      AssertionExtensions.Should(() => DateTimeAssertions.Second(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.UtcNow }.ForEach(Validate);
    }

    return;

    static void Validate(DateTime date)
    {
      AssertionExtensions.Should(() => Assert.To.Second(date, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.Second(date, date.Second).Should().NotBeNull().And.BeSameAs(Assert.To);
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
      AssertionExtensions.Should(() => DateTimeAssertions.Millisecond(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.UtcNow }.ForEach(Validate);
    }

    return;

    static void Validate(DateTime date)
    {
      AssertionExtensions.Should(() => Assert.To.Millisecond(date, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.Millisecond(date, date.Millisecond).Should().NotBeNull().And.BeSameAs(Assert.To);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.DayOfWeek(IAssertion, DateTime, DayOfWeek, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfWeek_Method()
  {
    AssertionExtensions.Should(() => DateTimeAssertions.DayOfWeek(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    DateTime.MinValue.With(date =>
    {
      Assert.To.DayOfWeek(date, date.DayOfWeek).Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.DayOfWeek(date, date.DayOfWeek + 1, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.LocalTime(IAssertion, DateTime, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void LocalTime_Method()
  {
    AssertionExtensions.Should(() => DateTimeAssertions.LocalTime(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    AssertionExtensions.Should(() => Assert.To.LocalTime(DateTime.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.LocalTime(DateTime.MaxValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.LocalTime(DateTime.UtcNow, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");

    Assert.To.LocalTime(DateTime.Now).Should().NotBeNull().And.BeSameAs(Assert.To);
 }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.UtcTime(IAssertion, DateTime, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void UtcTime_Method()
  {
    AssertionExtensions.Should(() => DateTimeAssertions.UtcTime(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    AssertionExtensions.Should(() => Assert.To.UtcTime(DateTime.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.UtcTime(DateTime.MaxValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.UtcTime(DateTime.Now, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");

    Assert.To.UtcTime(DateTime.UtcNow).Should().NotBeNull().And.BeSameAs(Assert.To);
  }
}