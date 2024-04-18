using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="HttpContentAssertions"/>.</para>
/// </summary>
public sealed class HttpContentAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="HttpContentAssertions.ContainHeader(IAssertion, HttpContent, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainHeader_Method()
  {
    using (new AssertionScope())
    {
      Validate(true, string.Empty.ToStringContent().With(content => content.Headers.Add("header", new string[] { null })), "header");
      Validate(false, string.Empty.ToStringContent(), "header");
      Validate(false, string.Empty.ToStringContent().With(content => content.Headers.Add("header", Enumerable.Empty<string>())), "header");
    }

    return;

    static void Validate(bool result, HttpContent content, string name)
    {
      using (content)
      {
        AssertionExtensions.Should(() => HttpContentAssertions.ContainHeader(null, content, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
        AssertionExtensions.Should(() => Assert.To.ContainHeader(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("content");
        AssertionExtensions.Should(() => Assert.To.ContainHeader(content, null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

        if (result)
        {
          Assert.To.ContainHeader(content, name).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.ContainHeader(content, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }
}