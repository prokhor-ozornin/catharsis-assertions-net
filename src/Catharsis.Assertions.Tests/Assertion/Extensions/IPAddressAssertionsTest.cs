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

      Validate(true, IPAddress.Any);
      Validate(true, IPAddress.Broadcast);
      Validate(true, IPAddress.Loopback);
      Validate(true, IPAddress.None);
      Validate(true, Random.IpAddress());

      Validate(false, IPAddress.IPv6Any);
      Validate(false, IPAddress.IPv6Loopback);
      Validate(false, IPAddress.IPv6None);
      Validate(false, Random.IpV6Address());
    }

    return;

    static void Validate(bool result, IPAddress address)
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

      Validate(true, IPAddress.IPv6Any);
      Validate(true, IPAddress.IPv6Loopback);
      Validate(true, IPAddress.IPv6None);
      Validate(true, Random.IpV6Address());

      Validate(false, IPAddress.Any);
      Validate(false, IPAddress.Broadcast);
      Validate(false, IPAddress.Loopback);
      Validate(false, IPAddress.None);
      Validate(false, Random.IpAddress());
    }

    return;

    static void Validate(bool result, IPAddress address)
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