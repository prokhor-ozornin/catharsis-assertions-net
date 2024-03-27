using System.Text.RegularExpressions;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="RegexAssertions"/>.</para>
/// </summary>
public sealed class RegexAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="RegexAssertions.Match(IAssertion, Regex, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Match_Method()
  {
    AssertionExtensions.Should(() => RegexAssertions.Match(null, string.Empty.ToRegex(), string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Match(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("regex");
    AssertionExtensions.Should(() => Assert.To.Match(string.Empty.ToRegex(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");

    Assert.To.Match(string.Empty.ToRegex(), string.Empty).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Match("anything".ToRegex(), string.Empty, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Match("[0-9]".ToRegex(), Attributes.Random().Digits(byte.MaxValue)).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Match("[0-9]".ToRegex(), Attributes.Random().Letters(byte.MaxValue), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }
}