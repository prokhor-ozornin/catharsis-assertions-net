using System.Net;
using Catharsis.Extensions;
using Catharsis.Fixture;
using FluentAssertions;
using Xunit;
using FluentAssertions.Execution;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IPAddressExpectations"/>.</para>
/// </summary>
public sealed class IPAddressExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IPAddressExpectations.Ip4(IExpectation{IPAddress})"/> method.</para>
  /// </summary>
  [Fact]
  public void Ip4_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IPAddressExpectations.Ip4(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IPAddress) null).Expect().Ip4()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, IPAddress.Any);
      Test(true, IPAddress.Broadcast);
      Test(true, IPAddress.Loopback);
      Test(true, IPAddress.None);
      Test(true, Fixture<IPAddress>.Create());

      Test(false, IPAddress.IPv6Any);
      Test(false, IPAddress.IPv6Loopback);
      Test(false, IPAddress.IPv6None);
    }

    return;

    static void Test(bool result, IPAddress address) => address.Expect().Ip4().Should().BeOfType<Expectation<IPAddress>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IPAddressExpectations.Ip6(IExpectation{IPAddress})"/> method.</para>
  /// </summary>
  [Fact]
  public void Ip6_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IPAddressExpectations.Ip6(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IPAddress) null).Expect().Ip6()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, IPAddress.IPv6Any);
      Test(true, IPAddress.IPv6Loopback);
      Test(true, IPAddress.IPv6None);
      Test(true, Random.IpV6Address());

      Test(false, IPAddress.Any);
      Test(false, IPAddress.Broadcast);
      Test(false, IPAddress.Loopback);
      Test(false, IPAddress.None);
      Test(false, Random.IpAddress());
    }

    return;

    static void Test(bool result, IPAddress address) => address.Expect().Ip6().Should().BeOfType<Expectation<IPAddress>>().Which.Result.Should().Be(result);
  }
}