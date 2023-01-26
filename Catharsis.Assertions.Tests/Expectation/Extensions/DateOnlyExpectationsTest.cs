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
  ///   <para>Performs testing of <see cref="DateOnlyExpectations.Day(IExpectation{DateOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Day_Method()
  {
    void Validate(DateOnly date)
    {
      var expectation = date.Expect();
      expectation.Day(0).Result.Should().BeFalse();
      expectation.Day(date.Day).Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateOnlyExpectations.Day(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      foreach (var date in new[] {DateOnly.MinValue, DateOnly.MaxValue, DateTime.Now.ToDateOnly(), DateTime.UtcNow.ToDateOnly()})
      {
        Validate(date);
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateOnlyExpectations.Month(IExpectation{DateOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Month_Method()
  {
    AssertionExtensions.Should(() => DateOnlyExpectations.Month(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateOnlyExpectations.Year(IExpectation{DateOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Year_Method()
  {
    AssertionExtensions.Should(() => DateOnlyExpectations.Year(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateOnlyExpectations.DayOfYear(IExpectation{DateOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfYear_Method()
  {
    AssertionExtensions.Should(() => DateOnlyExpectations.DayOfYear(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }
}