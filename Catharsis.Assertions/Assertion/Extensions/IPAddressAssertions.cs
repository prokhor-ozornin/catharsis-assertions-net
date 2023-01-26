using System.Net;
using System.Net.Sockets;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class IPAddressAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="address"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <see cref="Ip6(IAssertion, IPAddress, string)"/>
  public static IAssertion Ip4(this IAssertion assertion, IPAddress address, string message = null) => address is not null ? assertion.True(address.AddressFamily == AddressFamily.InterNetwork, message) : throw new ArgumentNullException(nameof(address));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="address"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Ip4(IAssertion, IPAddress, string)"/>
  public static IAssertion Ip6(this IAssertion assertion, IPAddress address, string message = null) => address is not null ? assertion.True(address.AddressFamily == AddressFamily.InterNetworkV6, message) : throw new ArgumentNullException(nameof(address));
}