namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="object"/>
public static class ObjectAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="instance"></param>
  /// <param name="other"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Same<T>(this IAssertion assertion, T instance, object other, string error = null) => assertion.True(ReferenceEquals(instance, other), error);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="instance"></param>
  /// <param name="other"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Equal<T>(this IAssertion assertion, T instance, object other, string error = null) => assertion.True(Equals(instance, other), error);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="instance"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Default<T>(this IAssertion assertion, T instance, string error = null) => assertion.Equal(instance, default(T), error);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="instance"></param>
  /// <param name="type"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion OfType(this IAssertion assertion, object instance, Type type, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (instance is null) throw new ArgumentNullException(nameof(instance));
    if (type is null) throw new ArgumentNullException(nameof(type));

    return assertion.True(instance.GetType() == type, error);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="instance"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion OfType<T>(this IAssertion assertion, object instance, string error = null) => assertion.OfType(instance, typeof(T), error);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="instance"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Null<T>(this IAssertion assertion, T instance, string error = null) => assertion.True(instance is null, error);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="value"></param>
  /// <param name="values"></param>
  /// <param name="comparer"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion OneOf<T>(this IAssertion assertion, T value, IEnumerable<T> values, IEqualityComparer<T> comparer = null, string error = null) => assertion.Contain(values, value, comparer, error);
}