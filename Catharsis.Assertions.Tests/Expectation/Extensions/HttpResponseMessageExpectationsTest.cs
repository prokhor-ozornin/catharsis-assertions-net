using System.Net;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests.Expectation.Extensions;

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

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="HttpResponseMessageExpectations.Status(IExpectation{HttpResponseMessage}, HttpStatusCode)"/> method.</para>
  /// </summary>
  [Fact]
  public void Status_Method()
  {
    AssertionExtensions.Should(() => HttpResponseMessageExpectations.Status(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((HttpResponseMessage) null).Expect().Status(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
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

    throw new NotImplementedException();
  }

  public override void Dispose()
  {
    base.Dispose();
    Response.Dispose();
  }
}