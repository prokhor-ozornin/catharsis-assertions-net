using System.Text.RegularExpressions;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
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
  public void Match_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => RegexExpectations.Match(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Regex) null).Expect().Match(null)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => string.Empty.ToRegex().Expect().Match(null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");

      Validate(true, string.Empty.ToRegex(), string.Empty);
      Validate(true, "[0-9]".ToRegex(), Attributes.Random().Digits(byte.MaxValue));
      Validate(false, char.MinValue.ToString().ToRegex(), string.Empty);
      Validate(false, "[0-9]".ToRegex(), Attributes.Random().Letters(byte.MaxValue));
    }

    return;

    static void Validate(bool result, Regex regex, string text) => regex.Expect().Match(text).Should().BeOfType<Expectation<Regex>>().Which.Result.Should().Be(result);
  }
}