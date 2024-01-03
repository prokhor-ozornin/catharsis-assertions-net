using System.Text.RegularExpressions;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="RegexExpectations"/>.</para>
/// </summary>
public sealed class RegexExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="RegexExpectations.Match(IExpectation{Regex}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Matches_Method()
  {
    AssertionExtensions.Should(() => RegexExpectations.Match(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Regex) null).Expect().Match(null)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => string.Empty.ToRegex().Expect().Match(null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");

    string.Empty.ToRegex().Expect().Match(string.Empty).Expect().Result.Should().BeTrue();
    "anything".ToRegex().Expect().Match(string.Empty).Result.Should().BeFalse();
    "[0-9]".ToRegex().Expect().Match(Attributes.Random().Digits(byte.MaxValue)).Result.Should().BeTrue();
    "[0-9]".ToRegex().Expect().Match(Attributes.Random().Letters(byte.MaxValue)).Result.Should().BeFalse();
  }
}