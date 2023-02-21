using System.Net;
using System.Net.Sockets;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="IPAddress"/> type.</para>
/// </summary>
/// <seealso cref="IPAddress"/>
public static class IPAddressExpectations
{
  /// <summary>
  ///   <para>Expects that a given IP address is IP version 4.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Ip6(IExpectation{IPAddress})"/>
  public static IExpectation<IPAddress> Ip4(this IExpectation<IPAddress> expectation) => expectation.HaveSubject().And().Expected(address => address.AddressFamily == AddressFamily.InterNetwork);

  /// <summary>
  ///   <para>Expects that a given IP address is IP version 6.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Ip4(IExpectation{IPAddress})"/>
  public static IExpectation<IPAddress> Ip6(this IExpectation<IPAddress> expectation) => expectation.HaveSubject().And().Expected(address => address.AddressFamily == AddressFamily.InterNetworkV6);
}