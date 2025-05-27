using System.Text.RegularExpressions;
using Catharsis.Extensions;
using Catharsis.Fixture;
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

      Test(true, string.Empty, 0);
      Test(false, string.Empty, int.MinValue);
      Test(false, string.Empty, int.MaxValue);

      Fixture<string>.Create().With(text => Test(true, text, text.Length));
      Test(false, Fixture<string>.Create(), int.MinValue);
      Test(false, Fixture<string>.Create(), int.MaxValue);
    }

    return;

    static void Test(bool result, string text, int length) => text.Expect().Length(length).Should().BeOfType<Expectation<string>>().Which.Result.Should().Be(result);
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

      Test(true, string.Empty);
      Test(false, Fixture<string>.Create());
    }

    return;

    static void Test(bool result, string text) => text.Expect().Empty().Should().BeOfType<Expectation<string>>().Which.Result.Should().Be(result);
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

      Test(true, string.Empty);
      Test(true, "\r\n\t");
      Test(false, Fixture<string>.Create());
    }

    return;

    static void Test(bool result, string text) => text.Expect().WhiteSpace().Should().BeOfType<Expectation<string>>().Which.Result.Should().Be(result);
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

      Test(true, string.Empty);
      Test(true, Fixture<string>.Create().ToUpperInvariant());
      Test(false, Fixture<string>.Create().ToLowerInvariant());
    }

    return;

    static void Test(bool result, string text) => text.Expect().UpperCased().Should().BeOfType<Expectation<string>>().Which.Result.Should().Be(result);
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

      Test(true, string.Empty);
      Test(true, Fixture<string>.Create().ToLowerInvariant());
      Test(false, Fixture<string>.Create().ToUpperInvariant());
    }

    return;

    static void Test(bool result, string text) => text.Expect().LowerCased().Should().BeOfType<Expectation<string>>().Which.Result.Should().Be(result);
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

      Test(true, string.Empty, string.Empty);
      Test(true, string.Empty, char.MinValue.ToString());
      Test(false, string.Empty, char.MaxValue.ToString());

      Test(true, Fixture<string>.Create(), string.Empty);
      Fixture<string>.Create().With(text => Test(true, text, text));
      Fixture<string>.Create().With(text => Test(true, text, text.ToUpperInvariant(), StringComparison.OrdinalIgnoreCase));
      Fixture<string>.Create().With(text => Test(false, text, text.ToUpperInvariant()));
    }

    return;

    static void Test(bool result, string text, string prefix, StringComparison? comparison = null) => text.Expect().StartWith(prefix, comparison).Should().BeOfType<Expectation<string>>().Which.Result.Should().Be(result);
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

      Test(true, string.Empty, string.Empty);
      Test(true, string.Empty, char.MinValue.ToString());
      Test(false, string.Empty, char.MaxValue.ToString());

      Test(true, Fixture<string>.Create(), string.Empty);
      Fixture<string>.Create().With(text => Test(true, text, text));
      Fixture<string>.Create().With(text => Test(true, text, text.ToUpperInvariant(), StringComparison.OrdinalIgnoreCase));
      Fixture<string>.Create().With(text => Test(false, text, text.ToUpperInvariant()));
    }

    return;

    static void Test(bool result, string text, string postfix, StringComparison? comparison = null) => text.Expect().EndWith(postfix, comparison).Should().BeOfType<Expectation<string>>().Which.Result.Should().Be(result);
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

      Test(true, string.Empty, string.Empty.ToRegex());
      Test(false, string.Empty, "anything".ToRegex());
      Test(true, Random.Digits(byte.MaxValue), "[0-9]".ToRegex());
      Test(false, Random.Letters(byte.MaxValue), "[0-9]".ToRegex());
    }

    return;

    static void Test(bool result, string text, Regex regex) => text.Expect().Match(regex).Should().BeOfType<Expectation<string>>().Which.Result.Should().Be(result);
  }
}