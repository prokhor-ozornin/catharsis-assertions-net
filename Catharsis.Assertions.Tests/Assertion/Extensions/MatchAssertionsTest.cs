using System.Text.RegularExpressions;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="MatchAssertions"/>.</para>
/// </summary>
public sealed class MatchAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="MatchAssertions.Successful(IAssertion, Match, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Successful_Method()
  {
    AssertionExtensions.Should(() => MatchAssertions.Successful(null, Match.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => MatchAssertions.Successful(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("match");

    AssertionExtensions.Should(() => Assert.To.Successful(Match.Empty, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Successful(string.Empty.ToRegex().Match(string.Empty)).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MatchAssertions.Value(IAssertion, Match, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    AssertionExtensions.Should(() => MatchAssertions.Value(null, Match.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => MatchAssertions.Value(Assert.To, null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("match");
    AssertionExtensions.Should(() => Assert.To.Value(Match.Empty, null)).ThrowExactly<ArgumentNullException>().WithParameterName("value");

    AssertionExtensions.Should(() => Assert.To.Value(Match.Empty, Attributes.RandomString(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Value(Match.Empty, Match.Empty.Value).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
  }
}