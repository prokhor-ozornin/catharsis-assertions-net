﻿using System.Text;
using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StringBuilderAssertions"/>.</para>
/// </summary>
public sealed class StringBuilderAssertionsTest : UnitTest
{
  private StringBuilder Builder { get; } = new();

  /// <summary>
  ///   <para>Performs testing of <see cref="StringBuilderAssertions.Length(IAssertion, StringBuilder, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Length_Method()
  {
    AssertionExtensions.Should(() => StringBuilderAssertions.Length(null, Builder, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => StringBuilderAssertions.Length(Assert.To, null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("builder");

    AssertionExtensions.Should(() => Assert.To.Length(Builder, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Length(Builder, int.MaxValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Length(Builder, Builder.Length).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringBuilderAssertions.Empty(IAssertion, StringBuilder, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => StringBuilderAssertions.Empty(null, Builder)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => StringBuilderAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("builder");

    Assert.To.Empty(Builder, "error").Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Empty(Builder.Append(char.MinValue), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }
}