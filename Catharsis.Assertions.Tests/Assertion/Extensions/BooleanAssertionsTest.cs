using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="BooleanAssertions"/>.</para>
/// </summary>
public sealed class BooleanAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="BooleanAssertions.True(IAssertion, bool?, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void True_Method()
  {
    AssertionExtensions.Should(() => BooleanAssertions.True(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="BooleanAssertions.False(IAssertion, bool?, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void False_Method()
  {
    AssertionExtensions.Should(() => BooleanAssertions.False(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }
}