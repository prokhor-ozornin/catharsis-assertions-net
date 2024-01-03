using System.Text;
using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StringBuilderExpectations"/>.</para>
/// </summary>
public sealed class StringBuilderExpectationsTest : UnitTest
{
  private StringBuilder Builder { get; } = new();

  /// <summary>
  ///   <para>Performs testing of <see cref="StringBuilderExpectations.Length(IExpectation{StringBuilder}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Length_Method()
  {
    AssertionExtensions.Should(() => StringBuilderExpectations.Length(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((StringBuilder) null).Expect().Length(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Builder.Expect().Length(int.MinValue).Result.Should().BeFalse();
    Builder.Expect().Length(int.MaxValue).Result.Should().BeFalse();
    Builder.Expect().Length(Builder.Length).Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringBuilderExpectations.Empty(IExpectation{StringBuilder})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => StringBuilderExpectations.Empty(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((StringBuilder) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Builder.Expect().Empty().Result.Should().BeTrue();
    Builder.Append(char.MinValue).Expect().Empty().Result.Should().BeFalse();
  }
}