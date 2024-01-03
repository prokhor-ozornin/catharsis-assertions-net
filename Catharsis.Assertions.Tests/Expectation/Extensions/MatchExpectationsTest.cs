using System.Text.RegularExpressions;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="MatchExpectations"/>.</para>
/// </summary>
public sealed class MatchExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="MatchExpectations.Successful(IExpectation{Match})"/> method.</para>
  /// </summary>
  [Fact]
  public void Successful_Method()
  {
    AssertionExtensions.Should(() => MatchExpectations.Successful(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Match) null).Expect().Successful()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Match.Empty.Expect().Successful().Result.Should().BeFalse();
    string.Empty.ToRegex().Match(string.Empty).Expect().Successful().Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MatchExpectations.Value(IExpectation{Match}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    AssertionExtensions.Should(() => MatchExpectations.Value(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Match) null).Expect().Value(string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Match.Empty.Expect().Value(null)).ThrowExactly<ArgumentNullException>().WithParameterName("value");

    Match.Empty.Expect().Value(Attributes.RandomString()).Result.Should().BeFalse();
    Match.Empty.Expect().Value(Match.Empty.Value).Result.Should().BeTrue();
  }
}