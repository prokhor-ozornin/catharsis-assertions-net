using System.Net;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="HttpResponseMessageAssertions"/>.</para>
/// </summary>
public sealed class HttpResponseMessageAssertionsTest : UnitTest
{
  private HttpResponseMessage Response { get; } = new();

  /// <summary>
  ///   <para>Performs testing of <see cref="HttpResponseMessageAssertions.Successful(IAssertion, System.Net.Http.HttpResponseMessage, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Successful_Method()
  {
    AssertionExtensions.Should(() => HttpResponseMessageAssertions.Successful(null, Response)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => HttpResponseMessageAssertions.Successful(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("response");

    Enum.GetValues<HttpStatusCode>().ForEach(status =>
    {
      var code = (int) status;

      if (code is >= 200 and <= 299)
      {
        new HttpResponseMessage(status).TryFinallyDispose(message => Assert.To.Successful(message).Should().NotBeNull().And.BeSameAs(Assert.To));
      }
      else
      {
        new HttpResponseMessage(status).TryFinallyDispose(message => AssertionExtensions.Should(() => Assert.To.Successful(message, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error"));
      }
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="HttpResponseMessageAssertions.Status(IAssertion, HttpResponseMessage, HttpStatusCode, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Status_Method()
  {
    AssertionExtensions.Should(() => HttpResponseMessageAssertions.Status(null, Response, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Status((HttpResponseMessage) null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("response");

    AssertionExtensions.Should(() => Assert.To.Status(Response, HttpStatusCode.NotFound, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Status(Response, Response.StatusCode).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="HttpResponseMessageAssertions.Header(IAssertion, System.Net.Http.HttpResponseMessage, string, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Header_Method()
  {
    AssertionExtensions.Should(() => HttpResponseMessageAssertions.Header(null, Response, "name", string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Header(null, "name", string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("response");
    AssertionExtensions.Should(() => Assert.To.Header(Response, null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    Response.With(response =>
    {
      response.Headers.Add("connection", (string) null);
      AssertionExtensions.Should(() => Assert.To.Header(Response, "connection", null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Response.Headers.Clear();

      response.Headers.Add("connection", Enumerable.Empty<string>());
      AssertionExtensions.Should(() => Assert.To.Header(Response, "connection", null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Response.Headers.Clear();

      response.Headers.Add("connection", "open");
      response.Headers.Add("connection", "close");
      Assert.To.Header(Response, "connection", "open").Should().NotBeNull().And.BeSameAs(Assert.To);
      Assert.To.Header(Response, "connection", "close").Should().NotBeNull().And.BeSameAs(Assert.To);
      Response.Headers.Clear();

      response.Headers.Add("connection", ["open", "close"]);
      Assert.To.Header(Response, "connection", "open").Should().NotBeNull().And.BeSameAs(Assert.To);
      Assert.To.Header(Response, "connection", "close").Should().NotBeNull().And.BeSameAs(Assert.To);
      Response.Headers.Clear();
    });
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public override void Dispose()
  {
    base.Dispose();
    Response.Dispose();
  }
}