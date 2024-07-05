using System.Net;
using System.Net.Sockets;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="IPAddress"/> type.</para>
/// </summary>
/// <seealso cref="IPAddress"/>
public static class IPAddressAssertions
{
  /// <summary>
  ///   <para>This function asserts that the given IP address is of IP version 4.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="address">IP address to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="address"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Ip6(IAssertion, IPAddress, string)"/>
  public static IAssertion Ip4(this IAssertion assertion, IPAddress address, string error = null) => address is not null ? assertion.True(address.AddressFamily == AddressFamily.InterNetwork, error) : throw new ArgumentNullException(nameof(address));

  /// <summary>
  ///   <para>This function asserts that the given IP address is of IP version 6.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="address">IP address to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="address"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Ip4(IAssertion, IPAddress, string)"/>
  public static IAssertion Ip6(this IAssertion assertion, IPAddress address, string error = null) => address is not null ? assertion.True(address.AddressFamily == AddressFamily.InterNetworkV6, error) : throw new ArgumentNullException(nameof(address));
}