namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for nullable types.</para>
/// </summary>
/// <seealso cref="Nullable{T}"/>
public static class NullableAssertions
{
  /// <summary>
  ///   <para>Asserts that a given nullable object has a valid value of its underlying type.</para>
  /// </summary>
  /// <typeparam name="T">Underlying type of the nullable object.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="instance">Nullable object instance to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion HasValue<T>(this IAssertion assertion, T? instance, string error = null) where T : struct => assertion.True(instance.HasValue, error);

  /// <summary>
  ///   <para>Asserts that a given nullable object has a specified value, either default or not.</para>
  /// </summary>
  /// <typeparam name="T">Underlying type of the nullable object.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="instance">Nullable object instance to inspect.</param>
  /// <param name="value">Value to look for.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Value<T>(this IAssertion assertion, T? instance, T value, string error = null) where T : struct => assertion.Equal(instance.GetValueOrDefault(), value, error);
}