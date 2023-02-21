using System.Security;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="SecureString"/> type.</para>
/// </summary>
/// <seealso cref="SecureString"/>
public static class SecureStringAssertions
{
  /// <summary>
  ///   <para>Asserts that a given secure string is of specified length.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="secure">Secure string to inspect.</param>
  /// <param name="length">String length.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="secure"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Length(this IAssertion assertion, SecureString secure, int length, string error = null) => secure is not null ? assertion.True(secure.Length == length, error) : throw new ArgumentNullException(nameof(secure));

  /// <summary>
  ///   <para>Asserts that a given secure string is empty (contains no characters).</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="secure">Secure string to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="secure"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Empty(this IAssertion assertion, SecureString secure, string error = null) => assertion.Length(secure, 0, error);

  /// <summary>
  ///   <para>Asserts that a given secure string is marked as read-only (cannot be modified).</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="secure">Secure string to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="secure"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ReadOnly(this IAssertion assertion, SecureString secure, string error = null) => secure is not null ? assertion.True(secure.IsReadOnly(), error) : throw new ArgumentNullException(nameof(secure));
}