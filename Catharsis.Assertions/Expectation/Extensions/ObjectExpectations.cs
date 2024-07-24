namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="object"/> type.</para>
/// </summary>
/// <seealso cref="object"/>
public static class ObjectExpectations
{
  /// <summary>
  ///   <para>Expects that the given <see cref="object"/> of a specific type is the same as the specified object.</para>
  /// </summary>
  /// <typeparam name="T">The type of object.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="other">Expected object for reference equality comparison.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<T> Same<T>(this IExpectation<T> expectation, object other) => expectation.Expected(instance => ReferenceEquals(instance, other));

  /// <summary>
  ///   <para>Expects that the given <see cref="object"/> is considered equal to the specified object.</para>
  /// </summary>
  /// <typeparam name="T">The type of object.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="other">Expected object for equality comparison.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<T> Equal<T>(this IExpectation<T> expectation, object other) => expectation.Expected(instance => Equals(instance, other));

  /// <summary>
  ///   <para>Expects that the given <see cref="object"/> is equal to the default value for its <see cref="Type"/>.</para>
  /// </summary>
  /// <typeparam name="T">The type of object.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<T> Default<T>(this IExpectation<T> expectation) => expectation.Equal(default(T));

  /// <summary>
  ///   <para>Expects that the given <see cref="object"/> is of the specified <see cref="Type"/>.</para>
  /// </summary>
  /// <typeparam name="T">The type of object.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="type">Expected object type.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="type"/> is <see langword="null"/>.</exception>
  public static IExpectation<T> OfType<T>(this IExpectation<T> expectation, Type type) => expectation.HaveSubject().And().ThrowIfNull(type, nameof(type)).And().Expected(instance => instance.GetType() == type);

  /// <summary>
  ///   <para>Expects that the given <see cref="object"/> is <see langword="null"/>.</para>
  /// </summary>
  /// <typeparam name="T">The type of object.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<T> Null<T>(this IExpectation<T> expectation) => expectation.Expected(instance => instance is null);

  /// <summary>
  ///   <para>Expects that the given <see cref="object"/> is equal to at least one element in the specified sequence.</para>
  /// </summary>
  /// <typeparam name="T">The type of object.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="sequence">Expected sequence of possible values for an object.</param>
  /// <param name="comparer">Comparer for equality.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or <paramref name="sequence"/> is <see langword="null"/>.</exception>
  public static IExpectation<T> OneOf<T>(this IExpectation<T> expectation, IEnumerable<T> sequence, IEqualityComparer<T> comparer = null) => expectation.ThrowIfNull(sequence, nameof(sequence)).And().Expected(value => sequence.Contains(value, comparer));
}