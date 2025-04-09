using System.Text.RegularExpressions;
using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StringAssertions.Length(null, string.Empty, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => StringAssertions.Length(Assert.To, null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("text");

      Validate(true, string.Empty, 0);
      Validate(false, string.Empty, int.MinValue);
      Validate(false, string.Empty, int.MaxValue);

      Attributes.RandomString().With(text => Validate(true, text, text.Length));
      Validate(false, Attributes.RandomString(), int.MinValue);
      Validate(false, Attributes.RandomString(), int.MaxValue);
    }

    return;

    static void Validate(bool result, string text, int length)
    {
      if (result)
      {
        Assert.To.Length(text, length).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Length(text, length, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringAssertions.Empty(IAssertion, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StringAssertions.Empty(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => StringAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");

      Validate(true, string.Empty);
      Validate(false, Attributes.RandomString());
    }

    return;

    static void Validate(bool result, string text)
    {
      if (result)
      {
        Assert.To.Empty(text).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Empty(text, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringAssertions.WhiteSpace(IAssertion, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void WhiteSpace_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StringAssertions.WhiteSpace(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.WhiteSpace(null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");

      Validate(true, string.Empty);
      Validate(true, "\r\n\t");
      Validate(false, Attributes.RandomString());
    }

    return;

    static void Validate(bool result, string text)
    {
      if (result)
      {
        Assert.To.WhiteSpace(text).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.WhiteSpace(text, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringAssertions.UpperCased(IAssertion, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void UpperCased_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StringAssertions.UpperCased(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.UpperCased(null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");

      Validate(true, string.Empty);
      Validate(true, Attributes.RandomString().ToUpperInvariant());
      Validate(false, Attributes.RandomString().ToLowerInvariant());
    }

    return;

    static void Validate(bool result, string text)
    {
      if (result)
      {
        Assert.To.UpperCased(text).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.UpperCased(text, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringAssertions.LowerCased(IAssertion, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void LowerCased_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StringAssertions.LowerCased(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.LowerCased(null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");

      Validate(true, string.Empty);
      Validate(true, Attributes.RandomString().ToLowerInvariant());
      Validate(false, Attributes.RandomString().ToUpperInvariant());
    }

    return;

    static void Validate(bool result, string text)
    {
      if (result)
      {
        Assert.To.LowerCased(text).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.LowerCased(text, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringAssertions.StartWith(IAssertion, string, string, StringComparison?, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void StartWith_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StringAssertions.StartWith(null, string.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.StartWith(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("text");
      AssertionExtensions.Should(() => Assert.To.StartWith(string.Empty, null)).ThrowExactly<ArgumentNullException>().WithParameterName("prefix");

      Validate(true, string.Empty, string.Empty);
      Validate(true, string.Empty, char.MinValue.ToString());
      Validate(false, string.Empty, char.MaxValue.ToString());

      Validate(true, Attributes.RandomString(), string.Empty);
      Attributes.RandomString().With(text => Validate(true, text, text));
      Attributes.RandomString().With(text => Validate(true, text, text.ToUpperInvariant(), StringComparison.OrdinalIgnoreCase));
      Attributes.RandomString().With(text => Validate(false, text, text.ToUpperInvariant()));
    }

    return;

    static void Validate(bool result, string text, string prefix, StringComparison? comparison = null)
    {
      if (result)
      {
        Assert.To.StartWith(text, prefix, comparison).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.StartWith(text, prefix, comparison, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringAssertions.EndWith(IAssertion, string, string, StringComparison?, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void EndWith_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StringAssertions.EndWith(null, string.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.EndWith(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("text");
      AssertionExtensions.Should(() => Assert.To.EndWith(string.Empty, null)).ThrowExactly<ArgumentNullException>().WithParameterName("postfix");

      Validate(true, string.Empty, string.Empty);
      Validate(true, string.Empty, char.MinValue.ToString());
      Validate(false, string.Empty, char.MaxValue.ToString());

      Validate(true, Attributes.RandomString(), string.Empty);
      Attributes.RandomString().With(text => Validate(true, text, text));
      Attributes.RandomString().With(text => Validate(true, text, text.ToUpperInvariant(), StringComparison.OrdinalIgnoreCase));
      Attributes.RandomString().With(text => Validate(false, text, text.ToUpperInvariant()));
    }

    return;

    static void Validate(bool result, string text, string postfix, StringComparison? comparison = null)
    {
      if (result)
      {
        Assert.To.EndWith(text, postfix, comparison).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.EndWith(text, postfix, comparison, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringAssertions.Match(IAssertion, string, Regex, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Match_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StringAssertions.Match(null, string.Empty, string.Empty.ToRegex())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Match(null, string.Empty.ToRegex())).ThrowExactly<ArgumentNullException>().WithParameterName("text");
      AssertionExtensions.Should(() => Assert.To.Match(string.Empty, null)).ThrowExactly<ArgumentNullException>().WithParameterName("regex");

      Validate(true, string.Empty, string.Empty.ToRegex());
      Validate(false, string.Empty, "anything".ToRegex());
      Validate(true, Attributes.Random().Digits(byte.MaxValue), "[0-9]".ToRegex());
      Validate(false, Attributes.Random().Letters(byte.MaxValue), "[0-9]".ToRegex());
    }

    return;

    static void Validate(bool result, string text, Regex regex)
    {
      if (result)
      {
        Assert.To.Match(text, regex).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Match(text, regex, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}