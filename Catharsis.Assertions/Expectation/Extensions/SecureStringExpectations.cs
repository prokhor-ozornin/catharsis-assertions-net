using System.Security;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="SecureString"/> type.</para>
/// </summary>
/// <seealso cref="SecureString"/>
public static class SecureStringExpectations
{
  /// <summary>
  ///   <para>Expects that the given <see cref="SecureString"/> has the specified length.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="length">Expected string length.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<SecureString> Length(this IExpectation<SecureString> expectation, int length) => expectation.HaveSubject().And().Expected(secure => secure.Length == length);

  /// <summary>
  ///   <para>Expects that the given <see cref="SecureString"/> is empty, meaning it contains no characters.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<SecureString> Empty(this IExpectation<SecureString> expectation) => expectation.Length(0);

  /// <summary>
  ///   <para>Expects that the given <see cref="SecureString"/> is marked as read-only and cannot be changed.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<SecureString> ReadOnly(this IExpectation<SecureString> expectation) => expectation.HaveSubject().And().Expected(secure => secure.IsReadOnly());
}