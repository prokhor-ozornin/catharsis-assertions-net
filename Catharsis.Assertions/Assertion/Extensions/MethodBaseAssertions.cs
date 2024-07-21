using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="MethodBase"/> type.</para>
/// </summary>
/// <seealso cref="MethodBase"/>
public static class MethodBaseAssertions
{
  /// <summary>
  ///   <para>This function asserts that the given <see cref="MethodBase"/> of the specified type is <see langword="abstract"/>.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="method">Type's method to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="method"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Abstract(this IAssertion assertion, MethodBase method, string error = null) => method is not null ? assertion.True(method.IsAbstract, error) : throw new ArgumentNullException(nameof(method));

  /// <summary>
  ///   <para>This function asserts that the given <see cref="MethodBase"/> of the specified type is <see langword="static"/>.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="method">Type's method to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="method"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Static(this IAssertion assertion, MethodBase method, string error = null) => method is not null ? assertion.True(method.IsStatic, error) : throw new ArgumentNullException(nameof(method));

  /// <summary>
  ///   <para>This function asserts that the given <see cref="MethodBase"/> of the specified type is <see langword="final"/>.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="method">Type's method to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="method"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Final(this IAssertion assertion, MethodBase method, string error = null) => method is not null ? assertion.True(method.IsFinal, error) : throw new ArgumentNullException(nameof(method));

  /// <summary>
  ///   <para>This function asserts that the given <see cref="MethodBase"/> of the specified type is <see langword="virtual"/>.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="method">Type's method to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="method"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Virtual(this IAssertion assertion, MethodBase method, string error = null) => method is not null ? assertion.True(method.IsVirtual, error) : throw new ArgumentNullException(nameof(method));

  /// <summary>
  ///   <para>This function asserts that the given <see cref="MethodBase"/> of the specified type can be overriden.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="method">Type's method to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="method"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Overridable(this IAssertion assertion, MethodBase method, string error = null) => method is not null ? assertion.True(method.IsVirtual && !method.IsFinal, error) : throw new ArgumentNullException(nameof(method));

  /// <summary>
  ///   <para>This function asserts that the specified <see cref="MethodBase"/> has <see langword="private"/> visibility.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="method">Type's method to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="method"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Private(this IAssertion assertion, MethodBase method, string error = null) => method is not null ? assertion.True(method.IsPrivate, error) : throw new ArgumentNullException(nameof(method));

  /// <summary>
  ///   <para>This function asserts that the specified <see cref="MethodBase"/> has <see langword="protected"/> visibility.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="method">Type's method to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="method"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Protected(this IAssertion assertion, MethodBase method, string error = null) => method is not null ? assertion.True(method.IsFamily, error) : throw new ArgumentNullException(nameof(method));

  /// <summary>
  ///   <para>This function asserts that the specified <see cref="MethodBase"/> has <see langword="public"/> visibility.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="method">Type's method to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="method"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Public(this IAssertion assertion, MethodBase method, string error = null) => method is not null ? assertion.True(method.IsPublic, error) : throw new ArgumentNullException(nameof(method));

  /// <summary>
  ///   <para>This function asserts that the specified <see cref="MethodBase"/> has <see langword="internal"/> visibility.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="method">Type's method to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="method"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Internal(this IAssertion assertion, MethodBase method, string error = null) => method is not null ? assertion.True(method.IsAssembly, error) : throw new ArgumentNullException(nameof(method));

  /// <summary>
  ///   <para>This function asserts that the specified <see cref="MethodBase"/> has <see langword="protected internal"/> visibility.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="method">Type's method to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="method"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ProtectedInternal(this IAssertion assertion, MethodBase method, string error = null) => method is not null ? assertion.True(method.IsFamilyOrAssembly, error) : throw new ArgumentNullException(nameof(method));
}