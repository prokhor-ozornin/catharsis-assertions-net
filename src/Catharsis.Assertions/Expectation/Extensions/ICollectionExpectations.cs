namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for <see cref="ICollection{T}"/> types.</para>
/// </summary>
/// <seealso cref="ICollection{T}"/>
public static class ICollectionExpectations
{
  /// <summary>
  ///   <para>Expects that the given <see cref="ICollection{T}"/> has a specified number of elements.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the collection.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="count">Expected number of elements.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<ICollection<T>> Count<T>(this IExpectation<ICollection<T>> expectation, int count) => expectation.HaveSubject().And().Expected(collection => collection.Count == count);

  /// <summary>
  ///   <para>Expects that the given <see cref="ICollection{T}"/> is empty, meaning it contains no elements.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the collection.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<ICollection<T>> Empty<T>(this IExpectation<ICollection<T>> expectation) => expectation.Count(0);

  /// <summary>
  ///   <para>Expects that the given <see cref="ICollection{T}"/> is read-only.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the collection.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<ICollection<T>> ReadOnly<T>(this IExpectation<ICollection<T>> expectation) => expectation.HaveSubject().And().Expected(collection => collection.IsReadOnly);
}