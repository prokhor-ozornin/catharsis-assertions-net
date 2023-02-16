using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DateOnlyAssertions"/>.</para>
/// </summary>
public sealed class DateOnlyAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DateOnlyAssertions.DayOfYear(IAssertion, DateOnly, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfYear_Method()
  {
    void Validate(DateOnly date)
    {
      AssertionExtensions.Should(() => Assert.To.DayOfYear(date, int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.DayOfYear(date, date.DayOfYear).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateOnlyAssertions.DayOfYear(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateOnly.MinValue, DateOnly.MaxValue, DateTime.Now.ToDateOnly(), DateTime.UtcNow.ToDateOnly() }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateOnlyAssertions.Year(IAssertion, DateOnly, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Year_Method()
  {
    void Validate(DateOnly date)
    {
      AssertionExtensions.Should(() => Assert.To.Year(date, int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.Year(date, date.Year).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateOnlyAssertions.Year(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateOnly.MinValue, DateOnly.MaxValue, DateTime.Now.ToDateOnly(), DateTime.UtcNow.ToDateOnly() }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateOnlyAssertions.Month(IAssertion, DateOnly, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Month_Method()
  {
    void Validate(DateOnly date)
    {
      AssertionExtensions.Should(() => Assert.To.Month(date, int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.Month(date, date.Month).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateOnlyAssertions.Month(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] { DateOnly.MinValue, DateOnly.MaxValue, DateTime.Now.ToDateOnly(), DateTime.UtcNow.ToDateOnly() }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateOnlyAssertions.Day(IAssertion, DateOnly, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Day_Method()
  {
    void Validate(DateOnly date)
    {
      AssertionExtensions.Should(() => Assert.To.Day(date, int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.Day(date, date.Day).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateOnlyAssertions.Day(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      new[] {DateOnly.MinValue, DateOnly.MaxValue, DateTime.Now.ToDateOnly(), DateTime.UtcNow.ToDateOnly()}.ForEach(Validate);
    }
  }
}