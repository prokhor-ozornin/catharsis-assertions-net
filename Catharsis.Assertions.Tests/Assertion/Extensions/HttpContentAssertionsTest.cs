using Catharsis.Commons;
using Catharsis.Extensions;
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
  ///   <para>Performs testing of <see cref="HttpContentAssertions.ContainHeader(IAssertion, HttpContent, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainHeader_Method()
  {
    AssertionExtensions.Should(() => HttpContentAssertions.ContainHeader(null, Content, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ContainHeader(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("content");
    AssertionExtensions.Should(() => Assert.To.ContainHeader(Content, null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    AssertionExtensions.Should(() => Assert.To.ContainHeader(Content, "header", "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");

    Content.Headers.Add("header", Enumerable.Empty<string>());
    AssertionExtensions.Should(() => Assert.To.ContainHeader(Content, "header", "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");

    Content.Headers.Add("header", ((string) null).ToSequence());
    Assert.To.ContainHeader(Content, "header").Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public override void Dispose()
  {
    base.Dispose();
    Content.Dispose();
  }
}