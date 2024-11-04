using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="HttpContentExpectations"/>.</para>
/// </summary>
public sealed class HttpContentExpectationsTest : UnitTest
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

      Validate(true, string.Empty.ToStringContent().With(content => content.Headers.Add("header", new string[] { null })), "header");
      Validate(false, string.Empty.ToStringContent(), "header");
      Validate(false, string.Empty.ToStringContent().With(content => content.Headers.Add("header", Enumerable.Empty<string>())), "header");
    }

    return;

    static void Validate(bool result, HttpContent content, string name)
    {
      using (content)
      {
        AssertionExtensions.Should(() => content.Expect().ContainHeader(null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

        content.Expect().ContainHeader(name).Should().BeOfType<Expectation<HttpContent>>().Which.Result.Should().Be(result);
      }
    }
  }
}