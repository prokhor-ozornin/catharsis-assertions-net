namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for <see cref="IEnumerable{T}"/> types.</para>
/// </summary>
/// <seealso cref="IEnumerable{T}"/>
public static class IEnumerableExpectations
{
  /// <summary>
  ///   <para>Expects that the given <see cref="IEnumerable{T}"/> has the specified number of elements.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="count">Expected number of elements.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<IEnumerable<T>> Count<T>(this IExpectation<IEnumerable<T>> expectation, int count) => expectation.HaveSubject().And().Expected(sequence => sequence.Count() == count);

  /// <summary>
  ///   <para>Expects that the given <see cref="IEnumerable{T}"/> is empty, meaning it contains no elements.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<IEnumerable<T>> Empty<T>(this IExpectation<IEnumerable<T>> expectation) => expectation.HaveSubject().And().Expected(sequence => !sequence.Any());

  /// <summary>
  ///   <para>Expects that the given <see cref="IEnumerable{T}"/> is equal to the specified one.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="other">Expected sequence for comparison.</param>
  /// <param name="comparer">Comparer for equality.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="other"/> is <see langword="null"/>.</exception>
  public static IExpectation<IEnumerable<T>> EquivalentTo<T>(this IExpectation<IEnumerable<T>> expectation, IEnumerable<T> other, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(other, nameof(other)).And().Expected(sequence => sequence.SequenceEqual(other, comparer));

  /// <summary>
  ///   <para>Expects that the given <see cref="IEnumerable{T}"/> contains the specified element.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="element">Expected sequence element.</param>
  /// <param name="comparer">Comparer for equality.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<IEnumerable<T>> Contain<T>(this IExpectation<IEnumerable<T>> expectation, T element, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().Expected(sequence => sequence.Contains(element, comparer));

  /// <summary>
  ///   <para>Expects that the given <see cref="IEnumerable{T}"/> contains all the specified elements at least once.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="other">Expected set of contained elements.</param>
  /// <param name="comparer">Comparer for equality.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="other"/> is <see langword="null"/>.</exception>
  public static IExpectation<IEnumerable<T>> ContainAll<T>(this IExpectation<IEnumerable<T>> expectation, IEnumerable<T> other, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(other, nameof(other)).And().Expected(sequence => !other.Except(sequence, comparer).Any());

  /// <summary>
  ///   <para>Expects that the given <see cref="IEnumerable{T}"/> contains at least one of the specified elements.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="other">Expected set of contained elements.</param>
  /// <param name="comparer">Comparer for equality.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="other"/> is <see langword="null"/>.</exception>
  public static IExpectation<IEnumerable<T>> ContainAnyOf<T>(this IExpectation<IEnumerable<T>> expectation, IEnumerable<T> other, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(other, nameof(other)).Expected(sequence => sequence.Intersect(other, comparer).Any());

  /// <summary>
  ///   <para>Expects that the given <see cref="IEnumerable{T}"/> contains at least one <see langword="null"/> element.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<IEnumerable<T>> ContainNulls<T>(this IExpectation<IEnumerable<T>> expectation) => expectation.HaveSubject().And().Expected(sequence => sequence.Any(element => element is null));

  /// <summary>
  ///   <para>Expects that the given <see cref="IEnumerable{T}"/> contains only distinct elements.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="comparer">Comparer for equality.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<IEnumerable<T>> ContainUnique<T>(this IExpectation<IEnumerable<T>> expectation, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().Expected(sequence => !sequence.GroupBy(sequence => sequence, comparer).Where(group => group.Count() > 1).Select(group => group.Key).Any());

  /// <summary>
  ///   <para>Expects that the given <see cref="IEnumerable{T}"/> contains a specified element at a given index.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="index">Expected element index.</param>
  /// <param name="value">Expected element value.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<IEnumerable<T>> ElementAt<T>(this IExpectation<IEnumerable<T>> expectation, int index, T value) => expectation.HaveSubject().And().Expected(sequence => Equals(sequence.ElementAt(index), value));

  /// <summary>
  ///   <para>Expects that the given <see cref="IEnumerable{T}"/> represents a subset of the specified superset.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="superset">Expected superset sequence.</param>
  /// <param name="comparer">Comparer for equality.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="superset"/> is <see langword="null"/>.</exception>
  /// <seealso cref="SupersetOf{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/>
  public static IExpectation<IEnumerable<T>> SubsetOf<T>(this IExpectation<IEnumerable<T>> expectation, IEnumerable<T> superset, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(superset, nameof(superset)).And().Expected(sequence => !sequence.Except(superset, comparer).Any());

  /// <summary>
  ///   <para>Expects that the given <see cref="IEnumerable{T}"/> represents a superset of the specified subset.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="subset">Expected subset sequence.</param>
  /// <param name="comparer">Comparer for equality.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="subset"/> is <see langword="null"/>.</exception>
  /// <seealso cref="SubsetOf{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/>
  public static IExpectation<IEnumerable<T>> SupersetOf<T>(this IExpectation<IEnumerable<T>> expectation, IEnumerable<T> subset, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(subset, nameof(subset)).And().Expected(sequence => !subset.Except(sequence, comparer).Any());

  /// <summary>
  ///   <para>Expects that the given <see cref="IEnumerable{T}"/> represents a reversed version of another sequence.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="reversed">Expected inverted sequence.</param>
  /// <param name="comparer">Comparer for equality.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="reversed"/> is <see langword="null"/>.</exception>
  public static IExpectation<IEnumerable<T>> Reversed<T>(this IExpectation<IEnumerable<T>> expectation, IEnumerable<T> reversed, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(reversed, nameof(reversed)).And().Expected(sequence => sequence.SequenceEqual(reversed.Reverse(), comparer));

  /// <summary>
  ///   <para>Expects that the given <see cref="IEnumerable{T}"/> starts with the same elements as in the specified sequence.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="other">Expected starting sequence.</param>
  /// <param name="comparer">Comparer for equality.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="other"/> is <see langword="null"/>.</exception>
  /// <seealso cref="EndWith{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/>
  public static IExpectation<IEnumerable<T>> StartWith<T>(this IExpectation<IEnumerable<T>> expectation, IEnumerable<T> other, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(other, nameof(other)).And().Expected(sequence => sequence.Take(other.Count()).SequenceEqual(other, comparer));

  /// <summary>
  ///   <para>Expects that the given <see cref="IEnumerable{T}"/> ends with the same elements as in the specified sequence.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="other">Expected ending sequence.</param>
  /// <param name="comparer">Comparer for equality.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="other"/> is <see langword="null"/>.</exception>
  /// <seealso cref="StartWith{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/>
  public static IExpectation<IEnumerable<T>> EndWith<T>(this IExpectation<IEnumerable<T>> expectation, IEnumerable<T> other, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(other, nameof(other)).And().Expected(sequence => sequence.TakeLast(other.Count()).SequenceEqual(other, comparer));

  /// <summary>
  ///   <para>Expects that all elements in a given <see cref="IEnumerable{T}"/> satisfy a specified condition.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="condition">Expected condition to be met.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="condition"/> is <see langword="null"/>.</exception>
  public static IExpectation<IEnumerable<T>> Match<T>(this IExpectation<IEnumerable<T>> expectation, Predicate<T> condition) => expectation.HaveSubject().And().ThrowIfNull(condition, nameof(condition)).And().Expected(sequence => sequence.All(element => condition(element)));

#if NET8_0_OR_GREATER
  /// <summary>
  ///   <para>Expects that the given <see cref="IEnumerable{T}"/> contains a specific element at a given index.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="index">Expected element index.</param>
  /// <param name="value">Expected element value.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<IEnumerable<T>> ElementAt<T>(this IExpectation<IEnumerable<T>> expectation, Index index, T value) => expectation.HaveSubject().And().Expected(sequence => Equals(sequence.ElementAt(index), value));

  /// <summary>
  ///   <para>Expects that the given <see cref="IEnumerable{T}"/> is ordered.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="comparer">Comparer for equality.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<IEnumerable<T>> Ordered<T>(this IExpectation<IEnumerable<T>> expectation, IComparer<T> comparer = null) => expectation.HaveSubject().And().Expected(sequence => sequence.SequenceEqual(sequence.Order(comparer)));
#endif
}