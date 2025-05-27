using System.Text.RegularExpressions;
using Catharsis.Extensions;
using Catharsis.Fixture;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="MatchExpectations"/>.</para>
/// </summary>
public sealed class MatchExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="MatchExpectations.Successful(IExpectation{Match})"/> method.</para>
  /// </summary>
  [Fact]
  public void Successful_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MatchExpectations.Successful(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Match) null).Expect().Successful()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, string.Empty.ToRegex().Match(string.Empty));
      Test(false, Match.Empty);
    }

    return;
    
    static void Test(bool result, Match match) => match.Expect().Successful().Should().BeOfType<Expectation<Match>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MatchExpectations.Value(IExpectation{Match}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MatchExpectations.Value(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Match) null).Expect().Value(string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => Match.Empty.Expect().Value(null)).ThrowExactly<ArgumentNullException>().WithParameterName("value");

      Test(true, Match.Empty, Match.Empty.Value);
      Test(false, Match.Empty, Fixture<string>.Create());
    }

    return;

    static void Test(bool result, Match match, string value) => match.Expect().Value(value).Should().BeOfType<Expectation<Match>>().Which.Result.Should().Be(result);
  }
}