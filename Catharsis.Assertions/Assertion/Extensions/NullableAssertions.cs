namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="Nullable{T}"/>
public static class NullableAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="instance"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion HasValue<T>(this IAssertion assertion, T? instance, string error = null) where T : struct => assertion.True(instance.HasValue, error);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="instance"></param>
  /// <param name="value"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Value<T>(this IAssertion assertion, T? instance, T value, string error = null) where T : struct => assertion.Equal(instance.GetValueOrDefault(), value, error);
}