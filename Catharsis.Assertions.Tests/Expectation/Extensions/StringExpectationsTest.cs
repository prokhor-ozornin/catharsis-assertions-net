using System.Text.RegularExpressions;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StringExpectations"/>.</para>
/// </summary>
public sealed class StringExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StringExpectations.Length(IExpectation{string}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Length_Method()
  {
    AssertionExtensions.Should(() => StringExpectations.Length(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((string) null).Expect().Length(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    string.Empty.Expect().Length(int.MinValue).Result.Should().BeFalse();
    string.Empty.Expect().Length(int.MaxValue).Result.Should().BeFalse();
    string.Empty.Expect().Length(string.Empty.Length).Result.Should().BeTrue();

    Attributes.RandomString().Expect().Length(int.MinValue).Result.Should().BeFalse();
    Attributes.RandomString().Expect().Length(int.MaxValue).Result.Should().BeFalse();
    Attributes.RandomString().Expect().Length(Attributes.RandomString().Length).Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringExpectations.Empty(IExpectation{string})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => StringExpectations.Empty(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((string) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    string.Empty.Expect().Empty().Result.Should().BeTrue();
    Attributes.RandomString().Expect().Empty().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringExpectations.WhiteSpace(IExpectation{string})"/> method.</para>
  /// </summary>
  [Fact]
  public void WhiteSpace_Method()
  {
    AssertionExtensions.Should(() => StringExpectations.WhiteSpace(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((string) null).Expect().WhiteSpace()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    string.Empty.Expect().WhiteSpace().Result.Should().BeTrue();
    "\r\n\t".Expect().WhiteSpace().Result.Should().BeTrue();
    Attributes.RandomString().Expect().WhiteSpace().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringExpectations.UpperCased(IExpectation{string})"/> method.</para>
  /// </summary>
  [Fact]
  public void UpperCased_Method()
  {
    AssertionExtensions.Should(() => StringExpectations.UpperCased(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((string) null).Expect().UpperCased()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    string.Empty.Expect().UpperCased().Result.Should().BeTrue();
    Attributes.RandomString().ToUpperInvariant().Expect().UpperCased().Result.Should().BeTrue();
    Attributes.RandomString().ToLowerInvariant().Expect().UpperCased().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringExpectations.LowerCased(IExpectation{string})"/> method.</para>
  /// </summary>
  [Fact]
  public void LowerCased_Method()
  {
    AssertionExtensions.Should(() => StringExpectations.LowerCased(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((string) null).Expect().LowerCased()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    string.Empty.Expect().LowerCased().Result.Should().BeTrue();
    Attributes.RandomString().ToLowerInvariant().Expect().LowerCased().Result.Should().BeTrue();
    Attributes.RandomString().ToUpperInvariant().Expect().LowerCased().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringExpectations.StartWith(IExpectation{string}, string, StringComparison?)"/> method.</para>
  /// </summary>
  [Fact]
  public void StartWith_Method()
  {
    AssertionExtensions.Should(() => StringExpectations.StartWith(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((string) null).Expect().StartWith(string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => string.Empty.Expect().StartWith(null)).ThrowExactly<ArgumentNullException>().WithParameterName("prefix");

    string.Empty.Expect().StartWith(string.Empty).Result.Should().BeTrue();
    string.Empty.Expect().StartWith(char.MinValue.ToString()).Result.Should().BeTrue();
    string.Empty.Expect().StartWith(char.MaxValue.ToString()).Result.Should().BeFalse();
    
    Attributes.RandomString().Expect().StartWith(string.Empty).Result.Should().BeTrue();
    Attributes.RandomString().Expect().StartWith(Attributes.RandomString()).Result.Should().BeTrue();
    Attributes.RandomString().Expect().StartWith(Attributes.RandomString().ToUpperInvariant()).Result.Should().BeFalse();
    Attributes.RandomString().Expect().StartWith(Attributes.RandomString().ToUpperInvariant(), StringComparison.OrdinalIgnoreCase).Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringExpectations.EndWith(IExpectation{string}, string, StringComparison?)"/> method.</para>
  /// </summary>
  [Fact]
  public void EndWith_Method()
  {
    AssertionExtensions.Should(() => StringExpectations.EndWith(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((string) null).Expect().EndWith(string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => string.Empty.Expect().EndWith(null)).ThrowExactly<ArgumentNullException>().WithParameterName("postfix");

    string.Empty.Expect().EndWith(string.Empty).Result.Should().BeTrue();
    string.Empty.Expect().EndWith(char.MinValue.ToString()).Result.Should().BeTrue();
    string.Empty.Expect().EndWith(char.MaxValue.ToString()).Result.Should().BeFalse();

    Attributes.RandomString().Expect().EndWith(string.Empty).Result.Should().BeTrue();
    Attributes.RandomString().Expect().EndWith(Attributes.RandomString()).Result.Should().BeTrue();
    Attributes.RandomString().Expect().EndWith(Attributes.RandomString().ToUpperInvariant()).Result.Should().BeFalse();
    Attributes.RandomString().Expect().EndWith(Attributes.RandomString().ToUpperInvariant(), StringComparison.OrdinalIgnoreCase).Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringExpectations.Match(IExpectation{string}, Regex)"/> method.</para>
  /// </summary>
  [Fact]
  public void Match_Method()
  {
    AssertionExtensions.Should(() => StringExpectations.Match(null, string.Empty.ToRegex())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((string) null).Expect().Match(string.Empty.ToRegex())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => string.Empty.Expect().Match(null)).ThrowExactly<ArgumentNullException>().WithParameterName("regex");

    string.Empty.Expect().Match(string.Empty.ToRegex()).Result.Should().BeTrue();
    string.Empty.Expect().Match("anything".ToRegex()).Result.Should().BeFalse();
    Attributes.Random().Digits(byte.MaxValue).Expect().Match("[0-9]".ToRegex()).Result.Should().BeTrue();
    Attributes.Random().Letters(byte.MaxValue).Expect().Match("[0-9]".ToRegex()).Result.Should().BeFalse();
  }
}