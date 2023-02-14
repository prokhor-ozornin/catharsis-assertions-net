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
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="method"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Abstract(this IAssertion assertion, MethodBase method, string error = null) => method is not null ? assertion.True(method.IsAbstract, error) : throw new ArgumentNullException(nameof(method));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="method"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Final(this IAssertion assertion, MethodBase method, string error = null) => method is not null ? assertion.True(method.IsFinal, error) : throw new ArgumentNullException(nameof(method));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="method"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Virtual(this IAssertion assertion, MethodBase method, string error = null) => method is not null ? assertion.True(method.IsVirtual, error) : throw new ArgumentNullException(nameof(method));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="method"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Overridable(this IAssertion assertion, MethodBase method, string error = null) => method is not null ? assertion.True(method.IsVirtual && !method.IsFinal, error) : throw new ArgumentNullException(nameof(method));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="method"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Private(this IAssertion assertion, MethodBase method, string error = null) => method is not null ? assertion.True(method.IsPrivate, error) : throw new ArgumentNullException(nameof(method));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="method"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Protected(this IAssertion assertion, MethodBase method, string error = null) => method is not null ? assertion.True(method.IsFamily, error) : throw new ArgumentNullException(nameof(method));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="method"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Public(this IAssertion assertion, MethodBase method, string error = null) => method is not null ? assertion.True(method.IsPublic, error) : throw new ArgumentNullException(nameof(method));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="method"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Internal(this IAssertion assertion, MethodBase method, string error = null) => method is not null ? assertion.True(method.IsAssembly, error) : throw new ArgumentNullException(nameof(method));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="method"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ProtectedInternal(this IAssertion assertion, MethodBase method, string error = null) => method is not null ? assertion.True(method.IsFamilyOrAssembly, error) : throw new ArgumentNullException(nameof(method));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="method"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Static(this IAssertion assertion, MethodBase method, string error = null) => method is not null ? assertion.True(method.IsStatic, error) : throw new ArgumentNullException(nameof(method));
}