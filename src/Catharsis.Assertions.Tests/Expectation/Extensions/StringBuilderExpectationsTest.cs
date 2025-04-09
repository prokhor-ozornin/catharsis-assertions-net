using System.Text;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StringBuilderExpectations"/>.</para>
/// </summary>
public sealed class StringBuilderExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StringBuilderExpectations.Length(IExpectation{StringBuilder}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Length_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StringBuilderExpectations.Length(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((StringBuilder) null).Expect().Length(0)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, new StringBuilder(), 0);
      Validate(false, new StringBuilder(), int.MinValue);
      Validate(false, new StringBuilder(), int.MaxValue);
    }

    return;

    static void Validate(bool result, StringBuilder builder, int length) => builder.Expect().Length(length).Should().BeOfType<Expectation<StringBuilder>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringBuilderExpectations.Empty(IExpectation{StringBuilder})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StringBuilderExpectations.Empty(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((StringBuilder) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, new StringBuilder());
      Validate(false, new StringBuilder().With(char.MinValue));
    }

    return;

    static void Validate(bool result, StringBuilder builder) => builder.Expect().Empty().Should().BeOfType<Expectation<StringBuilder>>().Which.Result.Should().Be(result);
  }
}