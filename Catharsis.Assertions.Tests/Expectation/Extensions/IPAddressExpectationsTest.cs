using System.Net;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

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

    new[] { IPAddress.Any, IPAddress.Broadcast, IPAddress.Loopback, IPAddress.None }.ForEach(address => address.Expect().Ip4().Result.Should().BeTrue());
    new[] { IPAddress.IPv6Any, IPAddress.IPv6Loopback, IPAddress.IPv6None }.ForEach(address => address.Expect().Ip4().Result.Should().BeFalse());
    
    Randomizer.IpAddress().Expect().Ip4().Result.Should().BeTrue();
    Randomizer.IpV6Address().Expect().Ip4().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IPAddressExpectations.Ip6(IExpectation{IPAddress})"/> method.</para>
  /// </summary>
  [Fact]
  public void Ip6_Method()
  {
    AssertionExtensions.Should(() => IPAddressExpectations.Ip6(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IPAddress) null).Expect().Ip6()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    new[] { IPAddress.IPv6Any, IPAddress.IPv6Loopback, IPAddress.IPv6None }.ForEach(address => address.Expect().Ip6().Result.Should().BeTrue());
    new[] { IPAddress.Any, IPAddress.Broadcast, IPAddress.Loopback, IPAddress.None }.ForEach(address => address.Expect().Ip6().Result.Should().BeFalse());

    Randomizer.IpV6Address().Expect().Ip6().Result.Should().BeTrue();
    Randomizer.IpAddress().Expect().Ip6().Result.Should().BeFalse();
  }
}