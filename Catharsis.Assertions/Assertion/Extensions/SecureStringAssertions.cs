using System.Security;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="SecureString"/>
public static class SecureStringAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="secure"></param>
  /// <param name="length"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Length(this IAssertion assertion, SecureString secure, int length, string message = null) => secure is not null ? assertion.True(secure.Length == length, message) : throw new ArgumentNullException(nameof(secure));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="secure"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Empty(this IAssertion assertion, SecureString secure, string message = null) => assertion.Length(secure, 0, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="secure"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion ReadOnly(this IAssertion assertion, SecureString secure, string message = null) => secure is not null ? assertion.True(secure.IsReadOnly(), message) : throw new ArgumentNullException(nameof(secure));
}