using AutoFixture;
using System.Text.RegularExpressions;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StringExpectations"/>.</para>
/// </summary>
public sealed class StringExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StringExpectations.Length(IExpectation{string}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Length_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StringExpectations.Length(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((string)null).Expect().Length(0)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, string.Empty, 0);
      Validate(false, string.Empty, int.MinValue);
      Validate(false, string.Empty, int.MaxValue);

      Fixture.Create<string>().With(text => Validate(true, text, text.Length));
      Validate(false, Fixture.Create<string>(), int.MinValue);
      Validate(false, Fixture.Create<string>(), int.MaxValue);
    }

    return;

    static void Validate(bool result, string text, int length) => text.Expect().Length(length).Should().BeOfType<Expectation<string>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringExpectations.Empty(IExpectation{string})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StringExpectations.Empty(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((string) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, string.Empty);
      Validate(false, Fixture.Create<string>());
    }

    return;

    static void Validate(bool result, string text) => text.Expect().Empty().Should().BeOfType<Expectation<string>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringExpectations.WhiteSpace(IExpectation{string})"/> method.</para>
  /// </summary>
  [Fact]
  public void WhiteSpace_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StringExpectations.WhiteSpace(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((string) null).Expect().WhiteSpace()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, string.Empty);
      Validate(true, "\r\n\t");
      Validate(false, Fixture.Create<string>());
    }

    return;

    static void Validate(bool result, string text) => text.Expect().WhiteSpace().Should().BeOfType<Expectation<string>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringExpectations.UpperCased(IExpectation{string})"/> method.</para>
  /// </summary>
  [Fact]
  public void UpperCased_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StringExpectations.UpperCased(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((string) null).Expect().UpperCased()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, string.Empty);
      Validate(true, Fixture.Create<string>().ToUpperInvariant());
      Validate(false, Fixture.Create<string>().ToLowerInvariant());
    }

    return;

    static void Validate(bool result, string text) => text.Expect().UpperCased().Should().BeOfType<Expectation<string>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringExpectations.LowerCased(IExpectation{string})"/> method.</para>
  /// </summary>
  [Fact]
  public void LowerCased_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StringExpectations.LowerCased(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((string) null).Expect().LowerCased()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, string.Empty);
      Validate(true, Fixture.Create<string>().ToLowerInvariant());
      Validate(false, Fixture.Create<string>().ToUpperInvariant());
    }

    return;

    static void Validate(bool result, string text) => text.Expect().LowerCased().Should().BeOfType<Expectation<string>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringExpectations.StartWith(IExpectation{string}, string, StringComparison?)"/> method.</para>
  /// </summary>
  [Fact]
  public void StartWith_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StringExpectations.StartWith(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((string) null).Expect().StartWith(string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => string.Empty.Expect().StartWith(null)).ThrowExactly<ArgumentNullException>().WithParameterName("prefix");

      Validate(true, string.Empty, string.Empty);
      Validate(true, string.Empty, char.MinValue.ToString());
      Validate(false, string.Empty, char.MaxValue.ToString());

      Validate(true, Fixture.Create<string>(), string.Empty);
      Fixture.Create<string>().With(text => Validate(true, text, text));
      Fixture.Create<string>().With(text => Validate(true, text, text.ToUpperInvariant(), StringComparison.OrdinalIgnoreCase));
      Fixture.Create<string>().With(text => Validate(false, text, text.ToUpperInvariant()));
    }

    return;

    static void Validate(bool result, string text, string prefix, StringComparison? comparison = null) => text.Expect().StartWith(prefix, comparison).Should().BeOfType<Expectation<string>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringExpectations.EndWith(IExpectation{string}, string, StringComparison?)"/> method.</para>
  /// </summary>
  [Fact]
  public void EndWith_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StringExpectations.EndWith(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((string) null).Expect().EndWith(string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => string.Empty.Expect().EndWith(null)).ThrowExactly<ArgumentNullException>().WithParameterName("postfix");

      Validate(true, string.Empty, string.Empty);
      Validate(true, string.Empty, char.MinValue.ToString());
      Validate(false, string.Empty, char.MaxValue.ToString());

      Validate(true, Fixture.Create<string>(), string.Empty);
      Fixture.Create<string>().With(text => Validate(true, text, text));
      Fixture.Create<string>().With(text => Validate(true, text, text.ToUpperInvariant(), StringComparison.OrdinalIgnoreCase));
      Fixture.Create<string>().With(text => Validate(false, text, text.ToUpperInvariant()));
    }

    return;

    static void Validate(bool result, string text, string postfix, StringComparison? comparison = null) => text.Expect().EndWith(postfix, comparison).Should().BeOfType<Expectation<string>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringExpectations.Match(IExpectation{string}, Regex)"/> method.</para>
  /// </summary>
  [Fact]
  public void Match_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StringExpectations.Match(null, string.Empty.ToRegex())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((string) null).Expect().Match(string.Empty.ToRegex())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => string.Empty.Expect().Match(null)).ThrowExactly<ArgumentNullException>().WithParameterName("regex");

      Validate(true, string.Empty, string.Empty.ToRegex());
      Validate(false, string.Empty, "anything".ToRegex());
      Validate(true, Random.Digits(byte.MaxValue), "[0-9]".ToRegex());
      Validate(false, Random.Letters(byte.MaxValue), "[0-9]".ToRegex());
    }

    return;

    static void Validate(bool result, string text, Regex regex) => text.Expect().Match(regex).Should().BeOfType<Expectation<string>>().Which.Result.Should().Be(result);
  }
}