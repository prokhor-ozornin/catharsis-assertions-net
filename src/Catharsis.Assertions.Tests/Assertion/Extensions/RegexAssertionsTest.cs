using System.Text.RegularExpressions;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => RegexAssertions.Match(null, string.Empty.ToRegex(), string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Match(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("regex");
      AssertionExtensions.Should(() => Assert.To.Match(string.Empty.ToRegex(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");

      Validate(true, string.Empty.ToRegex(), string.Empty);
      Validate(true, "[0-9]".ToRegex(), Attributes.Random().Digits(byte.MaxValue));
      Validate(false, char.MinValue.ToString().ToRegex(), string.Empty);
      Validate(false, "[0-9]".ToRegex(), Attributes.Random().Letters(byte.MaxValue));
    }

    return;

    static void Validate(bool result, Regex regex, string text)
    {
      if (result)
      {
        Assert.To.Match(regex, text).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Match(regex, text, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}