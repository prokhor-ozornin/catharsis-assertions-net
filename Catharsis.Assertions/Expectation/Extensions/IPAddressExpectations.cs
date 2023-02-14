using System.Net;
using System.Net.Sockets;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="IPAddress"/>
public static class IPAddressExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Ip6(IExpectation{IPAddress})"/>
  public static IExpectation<IPAddress> Ip4(this IExpectation<IPAddress> expectation) => expectation.HaveSubject().And().Expected(address => address.AddressFamily == AddressFamily.InterNetwork);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Ip4(IExpectation{IPAddress})"/>
  public static IExpectation<IPAddress> Ip6(this IExpectation<IPAddress> expectation) => expectation.HaveSubject().And().Expected(address => address.AddressFamily == AddressFamily.InterNetworkV6);
}