using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TimeOnlyExpectations"/>.</para>
/// </summary>
public sealed class TimeOnlyExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TimeOnlyExpectations.Hour(IExpectation{TimeOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Hour_Method()
  {
    AssertionExtensions.Should(() => TimeOnlyExpectations.Hour(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeOnlyExpectations.Minute(IExpectation{TimeOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Minute_Method()
  {
    AssertionExtensions.Should(() => TimeOnlyExpectations.Minute(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeOnlyExpectations.Second(IExpectation{TimeOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Second_Method()
  {
    AssertionExtensions.Should(() => TimeOnlyExpectations.Second(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeOnlyExpectations.Millisecond(IExpectation{TimeOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Millisecond_Method()
  {
    AssertionExtensions.Should(() => TimeOnlyExpectations.Millisecond(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }
}