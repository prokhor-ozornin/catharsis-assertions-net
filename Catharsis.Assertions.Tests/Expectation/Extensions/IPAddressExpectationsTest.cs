using System.Net;
using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IPAddressExpectations.Ip4(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IPAddress) null).Expect().Ip4()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, IPAddress.Any);
      Validate(true, IPAddress.Broadcast);
      Validate(true, IPAddress.Loopback);
      Validate(true, IPAddress.None);
      Validate(true, Attributes.Random().IpAddress());

      Validate(false, IPAddress.IPv6Any);
      Validate(false, IPAddress.IPv6Loopback);
      Validate(false, IPAddress.IPv6None);
      Validate(false, Attributes.Random().IpV6Address());
    }

    return;

    static void Validate(bool result, IPAddress address) => address.Expect().Ip4().Should().BeOfType<Expectation<IPAddress>>().Which.Result.Should().Be(result);
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

      Validate(true, IPAddress.IPv6Any);
      Validate(true, IPAddress.IPv6Loopback);
      Validate(true, IPAddress.IPv6None);
      Validate(true, Attributes.Random().IpV6Address());

      Validate(false, IPAddress.Any);
      Validate(false, IPAddress.Broadcast);
      Validate(false, IPAddress.Loopback);
      Validate(false, IPAddress.None);
      Validate(false, Attributes.Random().IpAddress());
    }

    return;

    static void Validate(bool result, IPAddress address) => address.Expect().Ip6().Should().BeOfType<Expectation<IPAddress>>().Which.Result.Should().Be(result);
  }
}