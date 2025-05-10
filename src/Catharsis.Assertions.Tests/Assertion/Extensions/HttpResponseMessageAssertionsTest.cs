using System.Net;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="HttpResponseMessageAssertions"/>.</para>
/// </summary>
public sealed class HttpResponseMessageAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="HttpResponseMessageAssertions.Successful(IAssertion, HttpResponseMessage, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Successful_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => HttpResponseMessageAssertions.Successful(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("response");

      Enum.GetValues<HttpStatusCode>().ForEach(status =>
      {
        var code = (int) status;
        Test(code is >= 200 and <= 299, new HttpResponseMessage(status));
      });
    }

    return;

    static void Test(bool result, HttpResponseMessage response)
    {
      using (response)
      {
        AssertionExtensions.Should(() => HttpResponseMessageAssertions.Successful(null, response)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

        if (result)
        {
          Assert.To.Successful(response).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Successful(response, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="HttpResponseMessageAssertions.Status(IAssertion, HttpResponseMessage, HttpStatusCode, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Status_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => Assert.To.Status((HttpResponseMessage) null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("response");

      Test(true, new HttpResponseMessage(default), default);
      Test(false, new HttpResponseMessage(HttpStatusCode.OK), default);
    }

    return;

    static void Test(bool result, HttpResponseMessage response, HttpStatusCode status)
    {
      AssertionExtensions.Should(() => HttpResponseMessageAssertions.Status(null, response, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      using (response)
      {
        if (result)
        {
          Assert.To.Status(response, status).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Status(response, status, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="HttpResponseMessageAssertions.Header(IAssertion, HttpResponseMessage, string, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Header_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => Assert.To.Header(null, "name", string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("response");

      Test(false, new HttpResponseMessage().With(response => response.Headers.Add("connection", (string) null)), "connection", null);
      Test(false, new HttpResponseMessage().With(response => response.Headers.Add("connection", [])), "connection", null);

      Test(true, new HttpResponseMessage().With(response => response.Headers.With(headers =>
      {
        headers.Add("connection", "open");
        headers.Add("connection", "close");
      })), "connection", "open");

      Test(true, new HttpResponseMessage().With(response => response.Headers.Add("connection", ["open", "close"])), "connection", "close");
    }

    return;

    static void Test(bool result, HttpResponseMessage response, string name, string value)
    {
      AssertionExtensions.Should(() => HttpResponseMessageAssertions.Header(null, response, "name", string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Header(response, null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

      using (response)
      {
        if (result)
        {
          Assert.To.Header(response, name, value).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Header(response, name, value, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }
}