using System.Net;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="HttpResponseMessageExpectations"/>.</para>
/// </summary>
/// <seealso cref="HttpResponseMessageExpectations"/>
public sealed class HttpResponseMessageExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="HttpResponseMessageExpectations.Successful(IExpectation{HttpResponseMessage})"/> method.</para>
  /// </summary>
  [Fact]
  public void Successful_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => HttpResponseMessageExpectations.Successful(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((HttpResponseMessage) null).Expect().Successful()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

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
        response.Expect().Successful().Should().BeOfType<Expectation<HttpResponseMessage>>().Which.Result.Should().Be(result);
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="HttpResponseMessageExpectations.Status(IExpectation{HttpResponseMessage}, HttpStatusCode)"/> method.</para>
  /// </summary>
  [Fact]
  public void Status_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => HttpResponseMessageExpectations.Status(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((HttpResponseMessage) null).Expect().Status(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, new HttpResponseMessage(default), default);
      Test(false, new HttpResponseMessage(HttpStatusCode.OK), default);
    }

    return;

    static void Test(bool result, HttpResponseMessage response, HttpStatusCode status)
    {
      using (response)
      {
        response.Expect().Status(status).Should().BeOfType<Expectation<HttpResponseMessage>>().Which.Result.Should().Be(result);
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="HttpResponseMessageExpectations.Header(IExpectation{HttpResponseMessage}, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Header_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => HttpResponseMessageExpectations.Header(null, "name", string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((HttpResponseMessage) null).Expect().Header("name", string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

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
      using (response)
      {
        AssertionExtensions.Should(() => response.Expect().Header(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

        response.Expect().Header(name, value).Should().BeOfType<Expectation<HttpResponseMessage>>().Which.Result.Should().Be(result);
      }
    }
  }
}