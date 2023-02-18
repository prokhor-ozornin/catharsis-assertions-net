namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for enumerable types.</para>
/// </summary>
/// <seealso cref="IEnumerable{T}"/>
public static class IEnumerableExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="count"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<IEnumerable<T>> Count<T>(this IExpectation<IEnumerable<T>> expectation, int count) => expectation.HaveSubject().And().Expected(sequence => sequence.Count() == count);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<IEnumerable<T>> Empty<T>(this IExpectation<IEnumerable<T>> expectation) => expectation.HaveSubject().And().Expected(sequence => !sequence.Any());

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="other"></param>
  /// <param name="comparer"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="other"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<IEnumerable<T>> EquivalentTo<T>(this IExpectation<IEnumerable<T>> expectation, IEnumerable<T> other, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(other, nameof(other)).And().Expected(sequence => sequence.SequenceEqual(other, comparer));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="element"></param>
  /// <param name="comparer"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<IEnumerable<T>> Contain<T>(this IExpectation<IEnumerable<T>> expectation, T element, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().Expected(sequence => sequence.Contains(element, comparer));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="other"></param>
  /// <param name="comparer"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="other"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<IEnumerable<T>> ContainAll<T>(this IExpectation<IEnumerable<T>> expectation, IEnumerable<T> other, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(other, nameof(other)).And().Expected(sequence => !other.Except(sequence, comparer).Any());

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="elements"></param>
  /// <param name="comparer"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="elements"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<IEnumerable<T>> ContainAnyOf<T>(this IExpectation<IEnumerable<T>> expectation, IEnumerable<T> elements, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(elements, nameof(elements)).Expected(sequence => sequence.Intersect(elements, comparer).Any());

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<IEnumerable<T>> ContainNulls<T>(this IExpectation<IEnumerable<T>> expectation) => expectation.HaveSubject().And().Expected(sequence => sequence.Any(element => element is null));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="comparer"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<IEnumerable<T>> ContainUnique<T>(this IExpectation<IEnumerable<T>> expectation, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().Expected(sequence => !sequence.GroupBy(sequence => sequence, comparer).Where(group => group.Count() > 1).Select(group => group.Key).Any());

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="index"></param>
  /// <param name="value"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<IEnumerable<T>> ElementAt<T>(this IExpectation<IEnumerable<T>> expectation, int index, T value) => expectation.HaveSubject().And().Expected(sequence => Equals(sequence.ElementAt(index), value));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="superset"></param>
  /// <param name="comparer"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="superset"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="SupersetOf{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/>
  public static IExpectation<IEnumerable<T>> SubsetOf<T>(this IExpectation<IEnumerable<T>> expectation, IEnumerable<T> superset, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(superset, nameof(superset)).And().Expected(sequence => !sequence.Except(superset, comparer).Any());

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="subset"></param>
  /// <param name="comparer"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="subset"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="SubsetOf{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/>
  public static IExpectation<IEnumerable<T>> SupersetOf<T>(this IExpectation<IEnumerable<T>> expectation, IEnumerable<T> subset, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(subset, nameof(subset)).And().Expected(sequence => !subset.Except(sequence, comparer).Any());

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="reversed"></param>
  /// <param name="comparer"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="reversed"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<IEnumerable<T>> Reversed<T>(this IExpectation<IEnumerable<T>> expectation, IEnumerable<T> reversed, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(reversed, nameof(reversed)).And().Expected(sequence => sequence.SequenceEqual(reversed.Reverse(), comparer));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="other"></param>
  /// <param name="comparer"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="other"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="EndWith{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/>
  public static IExpectation<IEnumerable<T>> StartWith<T>(this IExpectation<IEnumerable<T>> expectation, IEnumerable<T> other, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(other, nameof(other)).And().Expected(sequence => sequence.Take(other.Count()).SequenceEqual(other, comparer));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="other"></param>
  /// <param name="comparer"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="other"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="StartWith{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/>
  public static IExpectation<IEnumerable<T>> EndWith<T>(this IExpectation<IEnumerable<T>> expectation, IEnumerable<T> other, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(other, nameof(other)).And().Expected(sequence => sequence.TakeLast(other.Count()).SequenceEqual(other, comparer));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="condition"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="condition"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<IEnumerable<T>> Match<T>(this IExpectation<IEnumerable<T>> expectation, Predicate<T> condition) => expectation.HaveSubject().And().ThrowIfNull(condition, nameof(condition)).And().Expected(sequence => sequence.All(element => condition(element)));

#if NET7_0_OR_GREATER
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="index"></param>
  /// <param name="value"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<IEnumerable<T>> ElementAt<T>(this IExpectation<IEnumerable<T>> expectation, Index index, T value) => expectation.HaveSubject().And().Expected(sequence => Equals(sequence.ElementAt(index), value));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="comparer"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<IEnumerable<T>> Ordered<T>(this IExpectation<IEnumerable<T>> expectation, IComparer<T> comparer = null) => expectation.HaveSubject().And().Expected(sequence => sequence.SequenceEqual(sequence.Order(comparer)));
  #endif
}