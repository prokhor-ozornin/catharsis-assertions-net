using System.Net;
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

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="HttpResponseMessageAssertions.Status(IAssertion, System.Net.Http.HttpResponseMessage, HttpStatusCode, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Status_Method()
  {
    AssertionExtensions.Should(() => HttpResponseMessageAssertions.Status(null, Response, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Status(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("response");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="HttpResponseMessageAssertions.Header(IAssertion, System.Net.Http.HttpResponseMessage, string, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Header_Method()
  {
    AssertionExtensions.Should(() => HttpResponseMessageAssertions.Header(null, Response, "name", string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => HttpResponseMessageAssertions.Header(Assert.To, null, "name", string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("response");
    AssertionExtensions.Should(() => Assert.To.Header(Response, null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    throw new NotImplementedException();
  }

  public override void Dispose()
  {
    base.Dispose();
    Response.Dispose();
  }
}