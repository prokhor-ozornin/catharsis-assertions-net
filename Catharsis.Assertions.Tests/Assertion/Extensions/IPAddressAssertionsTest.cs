using System.Net;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IPAddressAssertions"/>.</para>
/// </summary>
public sealed class IPAddressAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IPAddressAssertions.Ip4(IAssertion, IPAddress, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Ip4_Method()
  {
    AssertionExtensions.Should(() => IPAddressAssertions.Ip4(null, IPAddress.Loopback)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Ip4(null)).ThrowExactly<ArgumentNullException>().WithParameterName("address");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IPAddressAssertions.Ip6(IAssertion, IPAddress, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Ip6_Method()
  {
    AssertionExtensions.Should(() => IPAddressAssertions.Ip6(null, IPAddress.Loopback)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Ip6(null)).ThrowExactly<ArgumentNullException>().WithParameterName("address");

    throw new NotImplementedException();
  }
}