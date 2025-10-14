using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="HttpContentAssertions"/>.</para>
/// </summary>
/// <seealso cref="HttpContentAssertions"/>
public sealed class HttpContentAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="HttpContentAssertions.ContainHeader(IAssertion, HttpContent, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainHeader_Method()
  {
    using (new AssertionScope())
    {
      Test(true, string.Empty.ToStringContent().With(content => content.Headers.Add("header", [null])), "header");
      Test(false, string.Empty.ToStringContent(), "header");
      Test(false, string.Empty.ToStringContent().With(content => content.Headers.Add("header", [])), "header");
    }

    return;

    static void Test(bool result, HttpContent content, string name)
    {
      using (content)
      {
        AssertionExtensions.Should(() => HttpContentAssertions.ContainHeader(null, content, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
        AssertionExtensions.Should(() => Assert.To.ContainHeader(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("content");
        AssertionExtensions.Should(() => Assert.To.ContainHeader(content, null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

        if (result)
        {
          Assert.To.ContainHeader(content, name).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.ContainHeader(content, name, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }
}