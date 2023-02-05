using System.Net;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="HttpResponseMessageExpectations"/>.</para>
/// </summary>
public sealed class HttpResponseMessageExpectationsTest : UnitTest
{
  private HttpResponseMessage Response { get; } = new();

  /// <summary>
  ///   <para>Performs testing of <see cref="HttpResponseMessageExpectations.Successful(IExpectation{HttpResponseMessage})"/> method.</para>
  /// </summary>
  [Fact]
  public void Successful_Method()
  {
    AssertionExtensions.Should(() => HttpResponseMessageExpectations.Successful(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((HttpResponseMessage) null).Expect().Successful()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Enum.GetValues<HttpStatusCode>().ForEach(status =>
    {
      var code = (int) status;

      if (code is >= 200 and <= 299)
      {
        new HttpResponseMessage(status).TryFinallyDispose(message => message.Expect().Successful().Result.Should().BeTrue());
      }
      else
      {
        new HttpResponseMessage(status).TryFinallyDispose(message => message.Expect().Successful().Result.Should().BeFalse());
      }
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="HttpResponseMessageExpectations.Status(IExpectation{HttpResponseMessage}, HttpStatusCode)"/> method.</para>
  /// </summary>
  [Fact]
  public void Status_Method()
  {
    AssertionExtensions.Should(() => HttpResponseMessageExpectations.Status(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((HttpResponseMessage) null).Expect().Status(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Response.Expect().Status(HttpStatusCode.NotFound).Result.Should().BeFalse();
    Response.Expect().Status(Response.StatusCode).Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="HttpResponseMessageExpectations.Header(IExpectation{HttpResponseMessage}, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Header_Method()
  {
    AssertionExtensions.Should(() => HttpResponseMessageExpectations.Header(null, "name", string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((HttpResponseMessage) null).Expect().Header("name", string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Response.Expect().Header(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    Response.With(response =>
    {
      response.Headers.Add("connection", (string) null);
      Response.Expect().Header("connection", null).Result.Should().BeFalse();
      Response.Headers.Clear();

      response.Headers.Add("connection", Enumerable.Empty<string>());
      Response.Expect().Header("connection", null).Result.Should().BeFalse();
      Response.Headers.Clear();

      response.Headers.Add("connection", "open");
      response.Headers.Add("connection", "close");
      Response.Expect().Header("connection", "open").Result.Should().BeTrue();
      Response.Expect().Header("connection", "close").Result.Should().BeTrue();
      Response.Headers.Clear();

      response.Headers.Add("connection", new[] { "open", "close" });
      Response.Expect().Header("connection", "open").Result.Should().BeTrue();
      Response.Expect().Header("connection", "close").Result.Should().BeTrue();
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