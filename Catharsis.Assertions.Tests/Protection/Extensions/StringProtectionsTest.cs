using System.Text.RegularExpressions;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StringProtections"/>.</para>
/// </summary>
public sealed class StringProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StringProtections.Empty(IProtection, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => StringProtections.Empty(null, string.Empty)) .ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((string) null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");

    AssertionExtensions.Should(() => Protect.From.Empty(string.Empty, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    
    Attributes.RandomString().With(text => Protect.From.Empty(text).Should().BeOfType<string>().And.BeSameAs(text));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringProtections.WhiteSpace(IProtection, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void WhiteSpace_Method()
  {
    AssertionExtensions.Should(() => StringProtections.WhiteSpace(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.WhiteSpace(null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");

    AssertionExtensions.Should(() => Protect.From.WhiteSpace(string.Empty, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Protect.From.WhiteSpace("\r\n\t", "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    Attributes.RandomString().With(text => Protect.From.Empty(text).Should().BeOfType<string>().And.BeSameAs(text));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringProtections.Match(IProtection, string, Regex, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Match_Method()
  {
    AssertionExtensions.Should(() => StringProtections.Match(null, string.Empty, new Regex(string.Empty))).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Match(null, new Regex(string.Empty))).ThrowExactly<ArgumentNullException>().WithParameterName("text");
    AssertionExtensions.Should(() => Protect.From.Match(string.Empty, null)).ThrowExactly<ArgumentNullException>().WithParameterName("regex");

    AssertionExtensions.Should(() => Protect.From.Match(string.Empty, string.Empty.ToRegex(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Protect.From.Match(string.Empty, "anything".ToRegex()).Should().BeOfType<string>().And.BeSameAs(string.Empty);
    AssertionExtensions.Should(() => Protect.From.Match(Attributes.Random().Digits(byte.MaxValue), "[0-9]".ToRegex(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Attributes.Random().Letters(byte.MaxValue).With(text => Protect.From.Match(text, "[0-9]".ToRegex()).Should().BeOfType<string>().And.BeSameAs(text));
  }
}