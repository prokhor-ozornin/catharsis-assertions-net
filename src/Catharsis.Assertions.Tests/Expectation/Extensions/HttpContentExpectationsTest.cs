using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="HttpContentExpectations"/>.</para>
/// </summary>
/// <seealso cref="HttpContentExpectations"/>
public sealed class HttpContentExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="HttpContentExpectations.ContainHeader(IExpectation{HttpContent}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainHeader_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => HttpContentExpectations.ContainHeader(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((HttpContent) null).Expect().ContainHeader("name")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, string.Empty.ToStringContent().With(content => content.Headers.Add("header", [null])), "header");
      Test(false, string.Empty.ToStringContent(), "header");
      Test(false, string.Empty.ToStringContent().With(content => content.Headers.Add("header", [])), "header");
    }

    return;

    static void Test(bool result, HttpContent content, string name)
    {
      using (content)
      {
        AssertionExtensions.Should(() => content.Expect().ContainHeader(null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

        content.Expect().ContainHeader(name).Should().BeOfType<Expectation<HttpContent>>().Which.Result.Should().Be(result);
      }
    }
  }
}