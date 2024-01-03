using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="HttpContentExpectations"/>.</para>
/// </summary>
public sealed class HttpContentExpectationsTest : UnitTest
{
  private HttpContent Content { get; } = new StringContent(string.Empty);

  /// <summary>
  ///   <para>Performs testing of <see cref="HttpContentExpectations.ContainHeader(IExpectation{HttpContent}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainHeader_Method()
  {
    AssertionExtensions.Should(() => HttpContentExpectations.ContainHeader(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((HttpContent) null).Expect().ContainHeader("name")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Content.Expect().ContainHeader(null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    Content.Expect().ContainHeader("header").Result.Should().BeFalse();

    Content.Headers.Add("header", Enumerable.Empty<string>());
    Content.Expect().ContainHeader("header").Result.Should().BeFalse();

    Content.Headers.Add("header", new string[] { null });
    Content.Expect().ContainHeader("header").Result.Should().BeTrue();
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