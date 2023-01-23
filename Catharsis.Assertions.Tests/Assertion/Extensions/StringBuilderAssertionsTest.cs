using System.Text;
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
  ///   <para>Performs testing of <see cref="StringBuilderAssertions.Length(IAssertion, System.Text.StringBuilder, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Length_Method()
  {
    AssertionExtensions.Should(() => StringBuilderAssertions.Length(null, Builder, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => StringBuilderAssertions.Length(Assert.To, null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("builder");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringBuilderAssertions.Empty(IAssertion, System.Text.StringBuilder, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => StringBuilderAssertions.Empty(null, Builder)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => StringBuilderAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("builder");

    throw new NotImplementedException();
  }
}