using System.Net;
using System.Net.Sockets;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="IPAddress"/> type.</para>
/// </summary>
/// <seealso cref="IPAddress"/>
public static class IPAddressAssertions
{
  /// <summary>
  ///   <para>Asserts that a given IP address is IP version 4.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="address">IP address to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="address"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Ip6(IAssertion, IPAddress, string)"/>
  public static IAssertion Ip4(this IAssertion assertion, IPAddress address, string error = null) => address is not null ? assertion.True(address.AddressFamily == AddressFamily.InterNetwork, error) : throw new ArgumentNullException(nameof(address));

  /// <summary>
  ///   <para>Asserts that a given IP address is IP version 6.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="address">IP address to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="address"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Ip4(IAssertion, IPAddress, string)"/>
  public static IAssertion Ip6(this IAssertion assertion, IPAddress address, string error = null) => address is not null ? assertion.True(address.AddressFamily == AddressFamily.InterNetworkV6, error) : throw new ArgumentNullException(nameof(address));
}