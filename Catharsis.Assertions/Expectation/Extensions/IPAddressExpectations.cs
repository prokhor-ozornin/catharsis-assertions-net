using System.Net;
using System.Net.Sockets;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class IPAddressExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Ip6(IExpectation{IPAddress})"/>
  public static IExpectation<IPAddress> Ip4(this IExpectation<IPAddress> expectation) => expectation.HaveSubject().And().Expected(address => address.AddressFamily == AddressFamily.InterNetwork);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <see cref="Ip4(IExpectation{IPAddress})"/>
  public static IExpectation<IPAddress> Ip6(this IExpectation<IPAddress> expectation) => expectation.HaveSubject().And().Expected(address => address.AddressFamily == AddressFamily.InterNetworkV6);
}