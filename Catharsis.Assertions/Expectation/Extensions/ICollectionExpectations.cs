namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="ICollection{T}"/> types.</para>
/// </summary>
/// <seealso cref="ICollection{T}"/>
public static class ICollectionExpectations
{
  /// <summary>
  ///   <para>Expects that a given collection contains a specified number of elements.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements inside the collection.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="count">Expected amount of elements.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<ICollection<T>> Count<T>(this IExpectation<ICollection<T>> expectation, int count) => expectation.HaveSubject().And().Expected(collection => collection.Count == count);

  /// <summary>
  ///   <para>Expects that a given collection is empty (contains no elements).</para>
  /// </summary>
  /// <typeparam name="T">Type of elements inside the collection.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<ICollection<T>> Empty<T>(this IExpectation<ICollection<T>> expectation) => expectation.Count(0);

  /// <summary>
  ///   <para>Expects that a given collection is read-only (does not allow modifications).</para>
  /// </summary>
  /// <typeparam name="T">Type of elements inside the collection.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<ICollection<T>> ReadOnly<T>(this IExpectation<ICollection<T>> expectation) => expectation.HaveSubject().And().Expected(collection => collection.IsReadOnly);
}