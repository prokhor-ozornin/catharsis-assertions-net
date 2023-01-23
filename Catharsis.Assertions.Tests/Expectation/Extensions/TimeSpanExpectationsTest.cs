using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests.Expectation.Extensions;

/// <summary>
///   <para>Tests set for class <see cref="TimeSpanExpectations"/>.</para>
/// </summary>
public sealed class TimeSpanExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.Days(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Days_Method()
  {
    AssertionExtensions.Should(() => TimeSpanExpectations.Days(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.Hours(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Hours_Method()
  {
    AssertionExtensions.Should(() => TimeSpanExpectations.Hours(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.Minutes(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Minutes_Method()
  {
    AssertionExtensions.Should(() => TimeSpanExpectations.Minutes(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.Seconds(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Seconds_Method()
  {
    AssertionExtensions.Should(() => TimeSpanExpectations.Seconds(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeSpanExpectations.Milliseconds(IExpectation{TimeSpan}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Milliseconds_Method()
  {
    AssertionExtensions.Should(() => TimeSpanExpectations.Milliseconds(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }
}