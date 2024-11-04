using System.Text.RegularExpressions;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MatchAssertions.Successful(null, Match.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => MatchAssertions.Successful(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("match");

      Validate(true, string.Empty.ToRegex().Match(string.Empty));
      Validate(false, Match.Empty);
    }

    return;

    static void Validate(bool result, Match match)
    {
      if (result)
      {
        Assert.To.Successful(match).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Successful(match, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MatchAssertions.Value(IAssertion, Match, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MatchAssertions.Value(null, Match.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => MatchAssertions.Value(Assert.To, null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("match");
      AssertionExtensions.Should(() => Assert.To.Value(Match.Empty, null)).ThrowExactly<ArgumentNullException>().WithParameterName("value");

      Validate(true, Match.Empty, Match.Empty.Value);
      Validate(false, Match.Empty, Attributes.RandomString());
    }

    return;

    static void Validate(bool result, Match match, string value)
    {
      if (result)
      {
        Assert.To.Value(match, value).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Value(match, value, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}