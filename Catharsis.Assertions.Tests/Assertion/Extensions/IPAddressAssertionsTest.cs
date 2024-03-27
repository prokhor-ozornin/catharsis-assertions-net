using System.Net;
using Catharsis.Commons;
using Catharsis.Extensions;
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

    new[] { IPAddress.Any, IPAddress.Broadcast, IPAddress.Loopback, IPAddress.None }.ForEach(address => Assert.To.Ip4(address).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To));
    new[] { IPAddress.IPv6Any, IPAddress.IPv6Loopback, IPAddress.IPv6None }.ForEach(address => AssertionExtensions.Should(() => Assert.To.Ip4(address, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error"));

    Assert.To.Ip4(Attributes.Random().IpAddress()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Ip4(Attributes.Random().IpV6Address(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IPAddressAssertions.Ip6(IAssertion, IPAddress, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Ip6_Method()
  {
    AssertionExtensions.Should(() => IPAddressAssertions.Ip6(null, IPAddress.Loopback)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Ip6(null)).ThrowExactly<ArgumentNullException>().WithParameterName("address");

    new[] { IPAddress.Any, IPAddress.Broadcast, IPAddress.Loopback, IPAddress.None }.ForEach(address => AssertionExtensions.Should(() => Assert.To.Ip6(address, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error"));
    new[] { IPAddress.IPv6Any, IPAddress.IPv6Loopback, IPAddress.IPv6None }.ForEach(address => Assert.To.Ip6(address, "error").Should().BeOfType<Assertion>().And.BeSameAs(Assert.To));

    Assert.To.Ip6(Attributes.Random().IpV6Address()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Ip6(Attributes.Random().IpAddress(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");

  }
}