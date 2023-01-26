using System.Text.RegularExpressions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="RegexExpectations"/>.</para>
/// </summary>
public sealed class RegexExpectationsTest : UnitTest
{
  private Regex Expression { get; } = new(string.Empty);

  /// <summary>
  ///   <para>Performs testing of <see cref="RegexExpectations.Matches(IExpectation{Regex}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Matches_Method()
  {
    AssertionExtensions.Should(() => RegexExpectations.Matches(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Regex) null).Expect().Matches(null)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Expression.Expect().Matches(null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");

    throw new NotImplementedException();
  }
}