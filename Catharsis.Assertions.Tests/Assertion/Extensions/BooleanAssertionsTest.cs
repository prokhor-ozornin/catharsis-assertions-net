using Catharsis.Commons;
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

    AssertionExtensions.Should(() => Assert.To.True(null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.True(false, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.True(true, "error").Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="BooleanAssertions.False(IAssertion, bool?, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void False_Method()
  {
    AssertionExtensions.Should(() => BooleanAssertions.False(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    Assert.To.False(null).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    Assert.To.False(false).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.False(true, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }
}