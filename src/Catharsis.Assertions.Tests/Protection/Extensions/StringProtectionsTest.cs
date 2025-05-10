using AutoFixture;
using System.Text.RegularExpressions;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StringProtections"/>.</para>
/// </summary>
public sealed class StringProtectionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StringProtections.Empty(IProtection, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StringProtections.Empty(null, string.Empty)) .ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.Empty((string) null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");

      Test(true, Fixture.Create<string>());
      Test(false, string.Empty);
    }

    return;

    static void Test(bool result, string text)
    {
      if (result)
      {
        Protect.From.Empty(text).Should().BeOfType<string>().And.BeSameAs(text);
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Empty(text, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringProtections.WhiteSpace(IProtection, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void WhiteSpace_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StringProtections.WhiteSpace(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.WhiteSpace(null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");

      Test(true, Fixture.Create<string>());
      Test(false, string.Empty);
      Test(false, "\r\n\t");
    }

    return;

    static void Test(bool result, string text)
    {
      if (result)
      {
        Protect.From.Empty(text).Should().BeOfType<string>().And.BeSameAs(text);
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.WhiteSpace(text, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringProtections.Match(IProtection, string, Regex, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Match_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StringProtections.Match(null, string.Empty, new Regex(string.Empty))).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.Match(null, new Regex(string.Empty))).ThrowExactly<ArgumentNullException>().WithParameterName("text");
      AssertionExtensions.Should(() => Protect.From.Match(string.Empty, null)).ThrowExactly<ArgumentNullException>().WithParameterName("regex");

      Test(true, string.Empty, "anything".ToRegex());
      Test(true, Random.Letters(byte.MaxValue), "[0-9]".ToRegex());
      
      Test(false, string.Empty, string.Empty.ToRegex());
      Test(false, Random.Digits(byte.MaxValue), "[0-9]".ToRegex());
    }

    return;

    static void Test(bool result, string text, Regex regex)
    {
      if (result)
      {
        Protect.From.Match(text, regex).Should().BeOfType<string>().And.BeSameAs(text);
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Match(text, regex, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    }
  }
}