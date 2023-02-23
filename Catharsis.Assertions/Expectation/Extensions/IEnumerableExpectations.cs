namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for enumerable types.</para>
/// </summary>
/// <seealso cref="IEnumerable{T}"/>
public static class IEnumerableExpectations
{
  /// <summary>
  ///   <para>Expects that a given sequence contains a specified number of elements.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="count"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<IEnumerable<T>> Count<T>(this IExpectation<IEnumerable<T>> expectation, int count) => expectation.HaveSubject().And().Expected(sequence => sequence.Count() == count);

  /// <summary>
  ///   <para>Expects that a given sequence is empty (contains no elements).</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<IEnumerable<T>> Empty<T>(this IExpectation<IEnumerable<T>> expectation) => expectation.HaveSubject().And().Expected(sequence => !sequence.Any());

  /// <summary>
  ///   <para>Expects that a given sequence is equal to a specified one.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="other">Expected sequence to compare for equality.</param>
  /// <param name="comparer">Comparer to perform comparison of objects for equality.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="other"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<IEnumerable<T>> EquivalentTo<T>(this IExpectation<IEnumerable<T>> expectation, IEnumerable<T> other, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(other, nameof(other)).And().Expected(sequence => sequence.SequenceEqual(other, comparer));

  /// <summary>
  ///   <para>Expects that a given sequence contains a specified element.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="element">Expected sequence element.</param>
  /// <param name="comparer">Comparer to perform comparison of objects for equality.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<IEnumerable<T>> Contain<T>(this IExpectation<IEnumerable<T>> expectation, T element, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().Expected(sequence => sequence.Contains(element, comparer));

  /// <summary>
  ///   <para>Expects that a given sequence contains all of the specified elements at least once.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="other">Set of elements all of which are asserted to be contained in the sequence.</param>
  /// <param name="comparer">Comparer to perform comparison of objects for equality.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="other"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<IEnumerable<T>> ContainAll<T>(this IExpectation<IEnumerable<T>> expectation, IEnumerable<T> other, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(other, nameof(other)).And().Expected(sequence => !other.Except(sequence, comparer).Any());

  /// <summary>
  ///   <para>Expects that a given sequence contains any of the specified elements at least once.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="other">Set of elements one or more of which is asserted to be contained in the sequence.</param>
  /// <param name="comparer">Comparer to perform comparison of objects for equality.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="other"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<IEnumerable<T>> ContainAnyOf<T>(this IExpectation<IEnumerable<T>> expectation, IEnumerable<T> other, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(other, nameof(other)).Expected(sequence => sequence.Intersect(other, comparer).Any());

  /// <summary>
  ///   <para>Expects that a given sequence contains at least one <see langword="null"/> reference.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<IEnumerable<T>> ContainNulls<T>(this IExpectation<IEnumerable<T>> expectation) => expectation.HaveSubject().And().Expected(sequence => sequence.Any(element => element is null));

  /// <summary>
  ///   <para>Expects that a given sequence contains only unique elements.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="comparer">Comparer to perform comparison of objects for equality.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<IEnumerable<T>> ContainUnique<T>(this IExpectation<IEnumerable<T>> expectation, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().Expected(sequence => !sequence.GroupBy(sequence => sequence, comparer).Where(group => group.Count() > 1).Select(group => group.Key).Any());

  /// <summary>
  ///   <para>Expects that a given sequence contains a specified element at a specified index.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="index">Expected element index.</param>
  /// <param name="value">Expected element value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<IEnumerable<T>> ElementAt<T>(this IExpectation<IEnumerable<T>> expectation, int index, T value) => expectation.HaveSubject().And().Expected(sequence => Equals(sequence.ElementAt(index), value));

  /// <summary>
  ///   <para>Expects that a given sequence represents a subset of a specified superset.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="superset">Expected superset sequence.</param>
  /// <param name="comparer">Comparer to perform comparison of objects for equality.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="superset"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="SupersetOf{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/>
  public static IExpectation<IEnumerable<T>> SubsetOf<T>(this IExpectation<IEnumerable<T>> expectation, IEnumerable<T> superset, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(superset, nameof(superset)).And().Expected(sequence => !sequence.Except(superset, comparer).Any());

  /// <summary>
  ///   <para>Expects that a given sequence represents a superset for a specified subset.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="subset">Expected subset sequence.</param>
  /// <param name="comparer">Comparer to perform comparison of objects for equality.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="subset"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="SubsetOf{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/>
  public static IExpectation<IEnumerable<T>> SupersetOf<T>(this IExpectation<IEnumerable<T>> expectation, IEnumerable<T> subset, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(subset, nameof(subset)).And().Expected(sequence => !subset.Except(sequence, comparer).Any());

  /// <summary>
  ///   <para>Expects that a given sequence represents an inverted version of the specified one.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="reversed">Expected sequence with inverted order of elements.</param>
  /// <param name="comparer">Comparer to perform comparison of objects for equality.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="reversed"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<IEnumerable<T>> Reversed<T>(this IExpectation<IEnumerable<T>> expectation, IEnumerable<T> reversed, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(reversed, nameof(reversed)).And().Expected(sequence => sequence.SequenceEqual(reversed.Reverse(), comparer));

  /// <summary>
  ///   <para>Expects that a given sequence starts with the same elements as in a specified sequence.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="other">Expected starting sequence.</param>
  /// <param name="comparer">Comparer to perform comparison of objects for equality.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="other"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="EndWith{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/>
  public static IExpectation<IEnumerable<T>> StartWith<T>(this IExpectation<IEnumerable<T>> expectation, IEnumerable<T> other, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(other, nameof(other)).And().Expected(sequence => sequence.Take(other.Count()).SequenceEqual(other, comparer));

  /// <summary>
  ///   <para>Expects that a given sequence ends with the same elements as in a specified sequence.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="other">Expected ending sequence.</param>
  /// <param name="comparer">Comparer to perform comparison of objects for equality.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="other"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="StartWith{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/>
  public static IExpectation<IEnumerable<T>> EndWith<T>(this IExpectation<IEnumerable<T>> expectation, IEnumerable<T> other, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(other, nameof(other)).And().Expected(sequence => sequence.TakeLast(other.Count()).SequenceEqual(other, comparer));

  /// <summary>
  ///   <para>Expects that all elements of a given sequence satisfy a specified condition.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="condition">Expected condition to be satisfied.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="condition"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<IEnumerable<T>> Match<T>(this IExpectation<IEnumerable<T>> expectation, Predicate<T> condition) => expectation.HaveSubject().And().ThrowIfNull(condition, nameof(condition)).And().Expected(sequence => sequence.All(element => condition(element)));

#if NET7_0_OR_GREATER
  /// <summary>
  ///   <para>Expects that a given sequence contains a specified element at a specified index.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="index">Expected element index.</param>
  /// <param name="value">Expected element value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<IEnumerable<T>> ElementAt<T>(this IExpectation<IEnumerable<T>> expectation, Index index, T value) => expectation.HaveSubject().And().Expected(sequence => Equals(sequence.ElementAt(index), value));

  /// <summary>
  ///   <para>Expects that a given sequence is ordered.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="comparer">Comparer to perform comparison of objects.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<IEnumerable<T>> Ordered<T>(this IExpectation<IEnumerable<T>> expectation, IComparer<T> comparer = null) => expectation.HaveSubject().And().Expected(sequence => sequence.SequenceEqual(sequence.Order(comparer)));
  #endif
}