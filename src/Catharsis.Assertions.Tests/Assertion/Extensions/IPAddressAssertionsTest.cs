using AutoFixture;
using System.Net;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IPAddressAssertions"/>.</para>
/// </summary>
public sealed class IPAddressAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IPAddressAssertions.Ip4(IAssertion, IPAddress, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Ip4_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IPAddressAssertions.Ip4(null, IPAddress.Loopback)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Ip4(null)).ThrowExactly<ArgumentNullException>().WithParameterName("address");

      Test(true, IPAddress.Any);
      Test(true, IPAddress.Broadcast);
      Test(true, IPAddress.Loopback);
      Test(true, IPAddress.None);
      Test(true, Random.IpAddress());

      Test(false, IPAddress.IPv6Any);
      Test(false, IPAddress.IPv6Loopback);
      Test(false, IPAddress.IPv6None);
      Test(false, Random.IpV6Address());
    }

    return;

    static void Test(bool result, IPAddress address)
    {
      if (result)
      {
        Assert.To.Ip4(address).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Ip4(address, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IPAddressAssertions.Ip6(IAssertion, IPAddress, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Ip6_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IPAddressAssertions.Ip6(null, IPAddress.Loopback)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Ip6(null)).ThrowExactly<ArgumentNullException>().WithParameterName("address");

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

    static void Test(bool result, IPAddress address)
    {
      if (result)
      {
        Assert.To.Ip6(address).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Ip6(address, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}