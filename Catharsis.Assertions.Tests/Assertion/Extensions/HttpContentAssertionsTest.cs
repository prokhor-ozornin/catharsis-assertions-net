using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="HttpContentAssertions"/>.</para>
/// </summary>
public sealed class HttpContentAssertionsTest : UnitTest
{
  private HttpContent Content { get; } = new StringContent(string.Empty);

  /// <summary>
  ///   <para>Performs testing of <see cref="HttpContentAssertions.Header(IAssertion, System.Net.Http.HttpContent, string, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Header_Method()
  {
    AssertionExtensions.Should(() => HttpContentAssertions.Header(null, Content, "name", string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => HttpContentAssertions.Header(Assert.To, null, "name", string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("content");
    AssertionExtensions.Should(() => Assert.To.Header(Content, null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    throw new NotImplementedException();
  }

  public override void Dispose()
  {
    base.Dispose();
    Content.Dispose();
  }
}