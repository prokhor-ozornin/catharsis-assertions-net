namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="object"/> type.</para>
/// </summary>
/// <seealso cref="object"/>
public static class ObjectAssertions
{
  /// <summary>
  ///   <para>Asserts that a given typed object is the same instance as the specified one.</para>
  /// </summary>
  /// <typeparam name="T">Type of object instance.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="instance">Typed object to inspect.</param>
  /// <param name="other">Asserted object for reference equality comparison.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Same<T>(this IAssertion assertion, T instance, object other, string error = null) => assertion.True(ReferenceEquals(instance, other), error);

  /// <summary>
  ///   <para>Asserts that a given typed object is considered equal to the specified one.</para>
  /// </summary>
  /// <typeparam name="T">Type of object instance.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="instance">Typed object to inspect.</param>
  /// <param name="other">Asserted object for equality comparison.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Equal<T>(this IAssertion assertion, T instance, object other, string error = null) => assertion.True(Equals(instance, other), error);

  /// <summary>
  ///   <para>Asserts that a given typed object is considered equal to the default value of its type.</para>
  /// </summary>
  /// <typeparam name="T">Type of object instance.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="instance">Typed object to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Default<T>(this IAssertion assertion, T instance, string error = null) => assertion.Equal(instance, default(T), error);

  /// <summary>
  ///   <para>Asserts that a given object instance is of specified type.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="instance">Object to inspect.</param>
  /// <param name="type">Asserted type of object instance.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="instance"/>, or <paramref name="type"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion OfType(this IAssertion assertion, object instance, Type type, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (instance is null) throw new ArgumentNullException(nameof(instance));
    if (type is null) throw new ArgumentNullException(nameof(type));

    return assertion.True(instance.GetType() == type, error);
  }

  /// <summary>
  ///   <para>Asserts that a given object instance is of specified type.</para>
  /// </summary>
  /// <typeparam name="T">Type of object instance.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="instance">Object to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="instance"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion OfType<T>(this IAssertion assertion, object instance, string error = null) => assertion.OfType(instance, typeof(T), error);

  /// <summary>
  ///   <para>Asserts that a given object is a <see langword="null"/> reference.</para>
  /// </summary>
  /// <typeparam name="T">Type of object instance.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="instance">Object to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Null<T>(this IAssertion assertion, T instance, string error = null) => assertion.True(instance is null, error);

  /// <summary>
  ///   <para>Asserts that a given object is considered equal to at least one in a specified sequence.</para>
  /// </summary>
  /// <typeparam name="T">Asserted type of object instance.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="value">Typed object to inspect.</param>
  /// <param name="sequence">Asserted sequence of possible object values.</param>
  /// <param name="comparer">Comparer to perform comparison of objects for equality.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="sequence"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion OneOf<T>(this IAssertion assertion, T value, IEnumerable<T> sequence, IEqualityComparer<T> comparer = null, string error = null) => assertion.Contain(sequence, value, comparer, error);
}