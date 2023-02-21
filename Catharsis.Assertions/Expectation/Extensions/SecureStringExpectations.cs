using System.Security;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="SecureString"/> type.</para>
/// </summary>
/// <seealso cref="SecureString"/>
public static class SecureStringExpectations
{
  /// <summary>
  ///   <para>Expects that a given secure string is of specified length.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="length">String length.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<SecureString> Length(this IExpectation<SecureString> expectation, int length) => expectation.HaveSubject().And().Expected(secure => secure.Length == length);

  /// <summary>
  ///   <para>Expects that a given secure string is empty (contains no characters).</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<SecureString> Empty(this IExpectation<SecureString> expectation) => expectation.Length(0);

  /// <summary>
  ///   <para>Expects that a given secure string is marked as read-only (cannot be modified).</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<SecureString> ReadOnly(this IExpectation<SecureString> expectation) => expectation.HaveSubject().And().Expected(secure => secure.IsReadOnly());
}