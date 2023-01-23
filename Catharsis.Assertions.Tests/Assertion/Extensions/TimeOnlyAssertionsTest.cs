using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TimeOnlyAssertions"/>.</para>
/// </summary>
public sealed class TimeOnlyAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TimeOnlyAssertions.Hour(IAssertion, TimeOnly, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Hour_Method()
  {
    AssertionExtensions.Should(() => TimeOnlyAssertions.Hour(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeOnlyAssertions.Minute(IAssertion, TimeOnly, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Minute_Method()
  {
    AssertionExtensions.Should(() => TimeOnlyAssertions.Minute(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeOnlyAssertions.Second(IAssertion, TimeOnly, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Second_Method()
  {
    AssertionExtensions.Should(() => TimeOnlyAssertions.Second(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeOnlyAssertions.Millisecond(IAssertion, TimeOnly, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Millisecond_Method()
  {
    AssertionExtensions.Should(() => TimeOnlyAssertions.Millisecond(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }
}