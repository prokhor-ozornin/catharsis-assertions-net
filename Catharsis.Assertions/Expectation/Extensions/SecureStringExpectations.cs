using System.Security;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class SecureStringExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="length"></param>
  /// <returns></returns>
  public static IExpectation<SecureString> Length(this IExpectation<SecureString> expectation, int length) => expectation.HaveSubject().And().Expect(secure => secure.Length == length);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<SecureString> Empty(this IExpectation<SecureString> expectation) => expectation.Length(0);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<SecureString> ReadOnly(this IExpectation<SecureString> expectation) => expectation.HaveSubject().And().Expect(secure => secure.IsReadOnly());
}