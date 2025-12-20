using System.Net;
using System.Net.Sockets;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="IPAddress"/> type.</para>
/// </summary>
/// <seealso cref="IPAddress"/>
public static class IPAddressExpectations
{
  /// <param name="expectation">Expectation to be fulfilled.</param>
  extension(IExpectation<IPAddress> expectation)
  {
    /// <summary>
    ///   <para>Expects that the given <see cref="IPAddress"/> is of IP version 4.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    /// <seealso cref="Ip6(IExpectation{IPAddress})"/>
    public IExpectation<IPAddress> Ip4() => expectation.HaveSubject().And().Expected(address => address.AddressFamily == AddressFamily.InterNetwork);

    /// <summary>
    ///   <para>Expects that the given <see cref="IPAddress"/> is of IP version 6.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    /// <seealso cref="Ip4(IExpectation{IPAddress})"/>
    public IExpectation<IPAddress> Ip6() => expectation.HaveSubject().And().Expected(address => address.AddressFamily == AddressFamily.InterNetworkV6);
  }
}