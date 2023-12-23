using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DateOnlyExpectations"/>.</para>
/// </summary>
public sealed class DateOnlyExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DateOnlyExpectations.DayOfYear(IExpectation{DateOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfYear_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateOnlyExpectations.DayOfYear(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateOnly.MinValue, DateOnly.MaxValue, DateTime.Now.ToDateOnly(), DateTime.UtcNow.ToDateOnly() }.ForEach(Validate);
    }

    return;

    static void Validate(DateOnly date)
    {
      date.Expect().DayOfYear(int.MinValue).Result.Should().BeFalse();
      date.Expect().DayOfYear(date.DayOfYear).Result.Should().BeTrue();
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateOnlyExpectations.Year(IExpectation{DateOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Year_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateOnlyExpectations.Year(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateOnly.MinValue, DateOnly.MaxValue, DateTime.Now.ToDateOnly(), DateTime.UtcNow.ToDateOnly() }.ForEach(Validate);
    }

    return;

    static void Validate(DateOnly date)
    {
      date.Expect().Year(int.MinValue).Result.Should().BeFalse();
      date.Expect().Year(date.Year).Result.Should().BeTrue();
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateOnlyExpectations.Month(IExpectation{DateOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Month_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateOnlyExpectations.Month(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateOnly.MinValue, DateOnly.MaxValue, DateTime.Now.ToDateOnly(), DateTime.UtcNow.ToDateOnly() }.ForEach(Validate);
    }

    return;

    static void Validate(DateOnly date)
    {
      date.Expect().Month(int.MinValue).Result.Should().BeFalse();
      date.Expect().Month(date.Month).Result.Should().BeTrue();
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateOnlyExpectations.Day(IExpectation{DateOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Day_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateOnlyExpectations.Day(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] {DateOnly.MinValue, DateOnly.MaxValue, DateTime.Now.ToDateOnly(), DateTime.UtcNow.ToDateOnly()}.ForEach(Validate);
    }

    return;

    static void Validate(DateOnly date)
    {
      date.Expect().Day(int.MinValue).Result.Should().BeFalse();
      date.Expect().Day(date.Day).Result.Should().BeTrue();
    }
  }
}