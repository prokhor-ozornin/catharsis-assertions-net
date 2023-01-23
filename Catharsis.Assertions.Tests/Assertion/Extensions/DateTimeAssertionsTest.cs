using FluentAssertions;
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
    AssertionExtensions.Should(() => DateTimeAssertions.Past(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.Future(IAssertion, DateTime, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Future_Method()
  {
    AssertionExtensions.Should(() => DateTimeAssertions.Future(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.DayOfYear(IAssertion, DateTime, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfYear_Method()
  {
    AssertionExtensions.Should(() => DateTimeAssertions.DayOfYear(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.Year(IAssertion, DateTime, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Year_Method()
  {
    AssertionExtensions.Should(() => DateTimeAssertions.Year(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.Month(IAssertion, DateTime, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Month_Method()
  {
    AssertionExtensions.Should(() => DateTimeAssertions.Month(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.Day(IAssertion, DateTime, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Day_Method()
  {
    AssertionExtensions.Should(() => DateTimeAssertions.Day(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.Hour(IAssertion, DateTime, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Hour_Method()
  {
    AssertionExtensions.Should(() => DateTimeAssertions.Hour(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    
    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.Minute(IAssertion, DateTime, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Minute_Method()
  {
    AssertionExtensions.Should(() => DateTimeAssertions.Minute(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.Second(IAssertion, DateTime, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Second_Method()
  {
    AssertionExtensions.Should(() => DateTimeAssertions.Second(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.Millisecond(IAssertion, DateTime, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Millisecond_Method()
  {
    AssertionExtensions.Should(() => DateTimeAssertions.Millisecond(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.DayOfWeek(IAssertion, DateTime, DayOfWeek, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfWeek_Method()
  {
    AssertionExtensions.Should(() => DateTimeAssertions.DayOfWeek(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.LocalTime(IAssertion, DateTime, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void LocalTime_Method()
  {
    AssertionExtensions.Should(() => DateTimeAssertions.LocalTime(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeAssertions.UtcTime(IAssertion, DateTime, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void UtcTime_Method()
  {
    AssertionExtensions.Should(() => DateTimeAssertions.UtcTime(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }
}