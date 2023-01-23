using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests.Expectation.Extensions;

/// <summary>
///   <para>Tests set for class <see cref="HttpContentExpectations"/>.</para>
/// </summary>
public sealed class HttpContentExpectationsTest : UnitTest
{
  private HttpContent Content { get; } = new StringContent(string.Empty);

  /// <summary>
  ///   <para>Performs testing of <see cref="HttpContentExpectations.Header(IExpectation{HttpContent}, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Header_Method()
  {
    AssertionExtensions.Should(() => HttpContentExpectations.Header(null, "name", string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((HttpContent) null).Expect().Header("name", string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Content.Expect().Header(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    throw new NotImplementedException();
  }

  public override void Dispose()
  {
    base.Dispose();
    Content.Dispose();
  }
}