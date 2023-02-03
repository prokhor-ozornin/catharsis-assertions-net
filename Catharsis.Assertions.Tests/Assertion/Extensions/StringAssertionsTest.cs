using System.Text.RegularExpressions;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StringAssertions"/>.</para>
/// </summary>
public sealed class StringAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StringAssertions.Length(IAssertion, string, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Length_Method()
  {
    AssertionExtensions.Should(() => StringAssertions.Length(null, string.Empty, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => StringAssertions.Length(Assert.To, null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("text");

    AssertionExtensions.Should(() => Assert.To.Length(string.Empty, int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Length(string.Empty, int.MaxValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Length(string.Empty, string.Empty.Length).Should().NotBeNull().And.BeSameAs(Assert.To);

    AssertionExtensions.Should(() => Assert.To.Length(RandomString, int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Length(RandomString, int.MaxValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Length(RandomString, RandomString.Length).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringAssertions.Empty(IAssertion, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => StringAssertions.Empty(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => StringAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");
    
    Assert.To.Empty(string.Empty).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Empty(RandomString, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringAssertions.WhiteSpace(IAssertion, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void WhiteSpace_Method()
  {
    AssertionExtensions.Should(() => StringAssertions.WhiteSpace(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.WhiteSpace(null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");

    Assert.To.WhiteSpace(string.Empty).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.WhiteSpace("\r\n\t").Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.WhiteSpace(RandomString, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringAssertions.UpperCased(IAssertion, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void UpperCased_Method()
  {
    AssertionExtensions.Should(() => StringAssertions.UpperCased(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.UpperCased(null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");

    Assert.To.UpperCased(string.Empty).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.UpperCased(RandomString.ToUpperInvariant()).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.UpperCased(RandomString.ToLowerInvariant(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringAssertions.LowerCased(IAssertion, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void LowerCased_Method()
  {
    AssertionExtensions.Should(() => StringAssertions.LowerCased(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.LowerCased(null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");

    Assert.To.LowerCased(string.Empty).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.LowerCased(RandomString.ToLowerInvariant()).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.LowerCased(RandomString.ToUpperInvariant(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringAssertions.StartWith(IAssertion, string, string, StringComparison?, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void StartWith_Method()
  {
    AssertionExtensions.Should(() => StringAssertions.StartWith(null, string.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.StartWith(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("text");
    AssertionExtensions.Should(() => Assert.To.StartWith(string.Empty, null)).ThrowExactly<ArgumentNullException>().WithParameterName("prefix");

    Assert.To.StartWith(string.Empty, string.Empty).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.StartWith(string.Empty, char.MinValue.ToString()).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.StartWith(string.Empty, char.MaxValue.ToString(), null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    Assert.To.StartWith(RandomString, string.Empty).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.StartWith(RandomString, RandomString).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.StartWith(RandomString, RandomString.ToUpperInvariant(), null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.StartWith(RandomString, RandomString.ToUpperInvariant(), StringComparison.OrdinalIgnoreCase).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringAssertions.EndWith(IAssertion, string, string, StringComparison?, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void EndWith_Method()
  {
    AssertionExtensions.Should(() => StringAssertions.EndWith(null, string.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.EndWith(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("text");
    AssertionExtensions.Should(() => Assert.To.EndWith(string.Empty, null)).ThrowExactly<ArgumentNullException>().WithParameterName("postfix");

    Assert.To.EndWith(string.Empty, string.Empty).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.EndWith(string.Empty, char.MinValue.ToString()).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.EndWith(string.Empty, char.MaxValue.ToString(), null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    Assert.To.EndWith(RandomString, string.Empty).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.EndWith(RandomString, RandomString).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.EndWith(RandomString, RandomString.ToUpperInvariant(), null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.EndWith(RandomString, RandomString.ToUpperInvariant(), StringComparison.OrdinalIgnoreCase).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringAssertions.Match(IAssertion, string, Regex, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Match_Method()
  {
    AssertionExtensions.Should(() => StringAssertions.Match(null, string.Empty, string.Empty.ToRegex())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Match(null, string.Empty.ToRegex())).ThrowExactly<ArgumentNullException>().WithParameterName("text");
    AssertionExtensions.Should(() => Assert.To.Match(string.Empty, null)).ThrowExactly<ArgumentNullException>().WithParameterName("regex");

    Assert.To.Match(string.Empty, string.Empty.ToRegex()).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Match(string.Empty, "anything".ToRegex(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Match(Randomizer.Digits(byte.MaxValue), "[0-9]".ToRegex()).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Match(Randomizer.Letters(byte.MaxValue), "[0-9]".ToRegex(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }
}