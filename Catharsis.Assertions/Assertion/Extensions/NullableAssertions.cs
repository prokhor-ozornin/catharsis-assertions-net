namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for nullable types.</para>
/// </summary>
/// <seealso cref="Nullable{T}"/>
public static class NullableAssertions
{
  /// <summary>
  ///   <para>This function asserts that the given nullable object has a value.</para>
  /// </summary>
  /// <typeparam name="T">Underlying type of the nullable object.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="instance">Nullable object to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion HasValue<T>(this IAssertion assertion, T? instance, string error = null) where T : struct => assertion.True(instance.HasValue, error);

  /// <summary>
  ///   <para>This function asserts that the given nullable object has the specified value.</para>
  /// </summary>
  /// <typeparam name="T">Underlying type of the nullable object.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="instance">Nullable object to inspect.</param>
  /// <param name="value">Asserted object value.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Value<T>(this IAssertion assertion, T? instance, T value, string error = null) where T : struct => assertion.Equal(instance.GetValueOrDefault(), value, error);
}