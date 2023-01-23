using System.Text.RegularExpressions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="RegexAssertions"/>.</para>
/// </summary>
public sealed class RegexAssertionsTest : UnitTest
{
  private Regex Expression { get; } = new(string.Empty);

  /// <summary>
  ///   <para>Performs testing of <see cref="RegexAssertions.Matches(IAssertion, Regex, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Matches_Method()
  {
    AssertionExtensions.Should(() => RegexAssertions.Matches(null, Expression, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Matches(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("regex");
    AssertionExtensions.Should(() => Assert.To.Matches(Expression, null)).ThrowExactly<ArgumentNullException>().WithParameterName("regex");

    throw new NotImplementedException();
  }
}