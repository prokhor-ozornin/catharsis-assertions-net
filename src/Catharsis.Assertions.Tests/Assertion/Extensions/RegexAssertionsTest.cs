using System.Text.RegularExpressions;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="RegexAssertions"/>.</para>
/// </summary>
public sealed class RegexAssertionsTest : Test
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

      Test(true, string.Empty.ToRegex(), string.Empty);
      Test(true, "[0-9]".ToRegex(), Random.Digits(byte.MaxValue));
      Test(false, char.MinValue.ToString().ToRegex(), string.Empty);
      Test(false, "[0-9]".ToRegex(), Random.Letters(byte.MaxValue));
    }

    return;

    static void Test(bool result, Regex regex, string text)
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