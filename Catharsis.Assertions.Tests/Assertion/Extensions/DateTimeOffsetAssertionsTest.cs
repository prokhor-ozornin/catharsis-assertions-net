using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DateTimeOffsetAssertions"/>.</para>
/// </summary>
public sealed class DateTimeOffsetAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Past(IAssertion, DateTimeOffset, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Past_Method()
  {
    void Validate(DateTimeOffset date)
    {
      Assert.To.Past(date.AddSeconds(-1)).Should().NotBeNull().And.BeSameAs(Assert.To);
      Assert.To.Past(date).Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.Past(date.AddSeconds(1), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetAssertions.Past(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Future(IAssertion, DateTimeOffset, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Future_Method()
  {
    void Validate(DateTimeOffset date)
    {
      Assert.To.Future(date.AddSeconds(1)).Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.Future(date.AddSeconds(-1), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      AssertionExtensions.Should(() => Assert.To.Future(date, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetAssertions.Future(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.DayOfYear(IAssertion, DateTimeOffset, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfYear_Method()
  {
    void Validate(DateTimeOffset date)
    {
      AssertionExtensions.Should(() => Assert.To.DayOfYear(date, int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.DayOfYear(date, date.DayOfYear).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetAssertions.DayOfYear(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Year(IAssertion, DateTimeOffset, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Year_Method()
  {
    void Validate(DateTimeOffset date)
    {
      AssertionExtensions.Should(() => Assert.To.Year(date, int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.Year(date, date.Year).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetAssertions.Year(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Month(IAssertion, DateTimeOffset, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Month_Method()
  {
    void Validate(DateTimeOffset date)
    {
      AssertionExtensions.Should(() => Assert.To.Month(date, int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.Month(date, date.Month).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetAssertions.Month(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Day(IAssertion, DateTimeOffset, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Day_Method()
  {
    void Validate(DateTimeOffset date)
    {
      AssertionExtensions.Should(() => Assert.To.Day(date, int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.Day(date, date.Day).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetAssertions.Day(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Hour(IAssertion, DateTimeOffset, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Hour_Method()
  {
    void Validate(DateTimeOffset date)
    {
      AssertionExtensions.Should(() => Assert.To.Hour(date, int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.Hour(date, date.Hour).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetAssertions.Hour(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Minute(IAssertion, DateTimeOffset, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Minute_Method()
  {
    void Validate(DateTimeOffset date)
    {
      AssertionExtensions.Should(() => Assert.To.Minute(date, int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.Minute(date, date.Minute).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetAssertions.Minute(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Second(IAssertion, DateTimeOffset, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Second_Method()
  {
    void Validate(DateTimeOffset date)
    {
      AssertionExtensions.Should(() => Assert.To.Second(date, int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.Second(date, date.Second).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetAssertions.Second(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Millisecond(IAssertion, DateTimeOffset, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Millisecond_Method()
  {
    void Validate(DateTimeOffset date)
    {
      AssertionExtensions.Should(() => Assert.To.Millisecond(date, int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.Millisecond(date, date.Millisecond).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetAssertions.Millisecond(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.DayOfWeek(IAssertion, DateTimeOffset, DayOfWeek, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfWeek_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetAssertions.DayOfWeek(null, default, DayOfWeek.Monday)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    DateTimeOffset.MinValue.With(date =>
    {
      Assert.To.DayOfWeek(date, date.DayOfWeek).Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.DayOfWeek(date, date.DayOfWeek + 1, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Offset(IAssertion, DateTimeOffset, TimeSpan, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Offset_Method()
  {
    void Validate(DateTimeOffset date)
    {
      AssertionExtensions.Should(() => Assert.To.Offset(date, TimeSpan.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.Offset(date, date.Offset).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeOffsetAssertions.Offset(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTimeOffset.Now, DateTimeOffset.UtcNow }.ForEach(Validate);
    }
  }
}