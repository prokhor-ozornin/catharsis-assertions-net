namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="object"/> type.</para>
/// </summary>
/// <seealso cref="object"/>
public static class ObjectExpectations
{
  /// <summary>
  ///   <para>Expects that a given typed object is the same instance as the specified one.</para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="other">Expected object for reference equality comparison.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<T> Same<T>(this IExpectation<T> expectation, object other) => expectation.Expected(instance => ReferenceEquals(instance, other));

  /// <summary>
  ///   <para>Expects that a given typed object is considered equal to the specified one.</para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="other">Expected object for equality comparison.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<T> Equal<T>(this IExpectation<T> expectation, object other) => expectation.Expected(instance => Equals(instance, other));

  /// <summary>
  ///   <para>Expects that a given typed object is considered equal to the default value of its type.</para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<T> Default<T>(this IExpectation<T> expectation) => expectation.Equal(default(T));

  /// <summary>
  ///   <para>Expects that a given object instance is of specified type.</para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="type">Expected type of object instance.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="type"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<T> OfType<T>(this IExpectation<T> expectation, Type type) => expectation.HaveSubject().And().ThrowIfNull(type, nameof(type)).And().Expected(instance => instance.GetType() == type);

  /// <summary>
  ///   <para>Expects that a given object is a <see langword="null"/> reference.</para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<T> Null<T>(this IExpectation<T> expectation) => expectation.Expected(instance => instance is null);

  /// <summary>
  ///   <para>Expects that a given object is considered equal to at least one in a specified sequence.</para>
  /// </summary>
  /// <typeparam name="T">Type of object instance.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="sequence">Expected sequence of possible object values.</param>
  /// <param name="comparer">Comparer to perform comparison of objects for equality.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or <paramref name="sequence"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<T> OneOf<T>(this IExpectation<T> expectation, IEnumerable<T> sequence, IEqualityComparer<T> comparer = null) => expectation.ThrowIfNull(sequence, nameof(sequence)).And().Expected(value => sequence.Contains(value, comparer));
}