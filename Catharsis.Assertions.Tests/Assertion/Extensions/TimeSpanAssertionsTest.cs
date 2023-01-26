using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TimeSpanAssertions"/>.</para>
/// </summary>
public sealed class TimeSpanAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.Days(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Days_Method()
  {
    AssertionExtensions.Should(() => TimeSpanAssertions.Days(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.Hours(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Hours_Method()
  {
    AssertionExtensions.Should(() => TimeSpanAssertions.Hours(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.Minutes(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Minutes_Method()
  {
    AssertionExtensions.Should(() => TimeSpanAssertions.Minutes(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.Seconds(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Seconds_Method()
  {
    AssertionExtensions.Should(() => TimeSpanAssertions.Seconds(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanAssertions.Milliseconds(IAssertion, TimeSpan, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Milliseconds_Method()
  {
    AssertionExtensions.Should(() => TimeSpanAssertions.Milliseconds(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }
}