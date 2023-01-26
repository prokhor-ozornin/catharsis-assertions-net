using System.Net;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IPAddressExpectations"/>.</para>
/// </summary>
public sealed class IPAddressExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IPAddressExpectations.Ip4(IExpectation{IPAddress})"/> method.</para>
  /// </summary>
  [Fact]
  public void Ip4_Method()
  {
    AssertionExtensions.Should(() => IPAddressExpectations.Ip4(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IPAddress) null).Expect().Ip4()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IPAddressExpectations.Ip6(IExpectation{IPAddress})"/> method.</para>
  /// </summary>
  [Fact]
  public void Ip6_Method()
  {
    AssertionExtensions.Should(() => IPAddressExpectations.Ip6(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IPAddress) null).Expect().Ip6()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }
}