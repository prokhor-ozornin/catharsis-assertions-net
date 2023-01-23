using FluentAssertions;
using Xunit;

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
    AssertionExtensions.Should(() => DateTimeOffsetAssertions.Past(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Future(IAssertion, DateTimeOffset, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Future_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetAssertions.Future(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.DayOfYear(IAssertion, DateTimeOffset, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfYear_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetAssertions.DayOfYear(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Year(IAssertion, DateTimeOffset, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Year_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetAssertions.Year(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Month(IAssertion, DateTimeOffset, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Month_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetAssertions.Month(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Day(IAssertion, DateTimeOffset, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Day_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetAssertions.Day(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Hour(IAssertion, DateTimeOffset, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Hour_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetAssertions.Hour(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Minute(IAssertion, DateTimeOffset, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Minute_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetAssertions.Minute(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Second(IAssertion, DateTimeOffset, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Second_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetAssertions.Second(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Millisecond(IAssertion, DateTimeOffset, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Millisecond_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetAssertions.Millisecond(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.DayOfWeek(IAssertion, DateTimeOffset, DayOfWeek, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfWeek_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetAssertions.DayOfWeek(null, default, DayOfWeek.Monday)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeOffsetAssertions.Offset(IAssertion, DateTimeOffset, TimeSpan, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Offset_Method()
  {
    AssertionExtensions.Should(() => DateTimeOffsetAssertions.Offset(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }
}