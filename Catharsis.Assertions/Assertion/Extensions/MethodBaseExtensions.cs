using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="MethodBase"/>
public static class MethodBaseAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="method"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Abstract(this IAssertion assertion, MethodBase method, string message = null) => method is not null ? assertion.True(method.IsAbstract, message) : throw new ArgumentNullException(nameof(method));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="method"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Final(this IAssertion assertion, MethodBase method, string message = null) => method is not null ? assertion.True(method.IsFinal, message) : throw new ArgumentNullException(nameof(method));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="method"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Private(this IAssertion assertion, MethodBase method, string message = null) => method is not null ? assertion.True(method.IsPrivate, message) : throw new ArgumentNullException(nameof(method));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="method"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Public(this IAssertion assertion, MethodBase method, string message = null) => method is not null ? assertion.True(method.IsPublic, message) : throw new ArgumentNullException(nameof(method));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="method"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Static(this IAssertion assertion, MethodBase method, string message = null) => method is not null ? assertion.True(method.IsStatic, message) : throw new ArgumentNullException(nameof(method));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="method"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Virtual(this IAssertion assertion, MethodBase method, string message = null) => method is not null ? assertion.True(method.IsVirtual, message) : throw new ArgumentNullException(nameof(method));
}