namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for <see cref="IEnumerable{T}"/> types.</para>
/// </summary>
/// <seealso cref="IEnumerable{T}"/>
public static class IEnumerableAssertions
{
  /// <summary>
  ///   <para>Asserts that the given <see cref="IEnumerable{T}"/> has the specified number of elements.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence to inspect.</param>
  /// <param name="count">Asserted number of elements.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="sequence"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Count<T>(this IAssertion assertion, IEnumerable<T> sequence, int count, string error = null) => sequence is not null ? assertion.True(sequence.Count() == count, error) : throw new ArgumentNullException(nameof(sequence));

  /// <summary>
  ///   <para>Asserts that the given <see cref="IEnumerable{T}"/> is empty, meaning it contains no elements.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="sequence"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Empty<T>(this IAssertion assertion, IEnumerable<T> sequence, string error = null) => sequence is not null ? assertion.True(!sequence.Any(), error) : throw new ArgumentNullException(nameof(sequence));

  /// <summary>
  ///   <para>Asserts that the given <see cref="IEnumerable{T}"/> is equal to the specified one.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence to inspect.</param>
  /// <param name="other">Asserted sequence for comparison.</param>
  /// <param name="comparer">Comparer for equality.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="sequence"/>, or <paramref name="other"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion EquivalentTo<T>(this IAssertion assertion, IEnumerable<T> sequence, IEnumerable<T> other, IEqualityComparer<T> comparer = null, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (sequence is null) throw new ArgumentNullException(nameof(sequence));
    if (other is null) throw new ArgumentNullException(nameof(other));

    return assertion.True(sequence.SequenceEqual(other, comparer), error);
  }

  /// <summary>
  ///   <para>Asserts that the given <see cref="IEnumerable{T}"/> contains the specified element.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence to inspect.</param>
  /// <param name="element">Asserted sequence element.</param>
  /// <param name="comparer">Comparer for equality.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="sequence"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Contain<T>(this IAssertion assertion, IEnumerable<T> sequence, T element, IEqualityComparer<T> comparer = null, string error = null) => sequence is not null ? assertion.True(sequence.Contains(element, comparer), error) : throw new ArgumentNullException(nameof(sequence));

  /// <summary>
  ///   <para>Asserts that the given <see cref="IEnumerable{T}"/> contains all the specified elements at least once.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence to inspect.</param>
  /// <param name="other">Asserted set of contained elements.</param>
  /// <param name="comparer">Comparer for equality.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="sequence"/>, or <paramref name="other"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ContainAll<T>(this IAssertion assertion, IEnumerable<T> sequence, IEnumerable<T> other, IEqualityComparer<T> comparer = null, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (sequence is null) throw new ArgumentNullException(nameof(sequence));
    if (other is null) throw new ArgumentNullException(nameof(other));

    return assertion.Empty(other.Except(sequence, comparer), error);
  }

  /// <summary>
  ///   <para>Asserts that the given <see cref="IEnumerable{T}"/> contains at least one of the specified elements.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence to inspect.</param>
  /// <param name="other">Asserted set of contained elements.</param>
  /// <param name="comparer">Comparer for equality.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="sequence"/>, or <paramref name="other"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ContainAnyOf<T>(this IAssertion assertion, IEnumerable<T> sequence, IEnumerable<T> other, IEqualityComparer<T> comparer = null, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (sequence is null) throw new ArgumentNullException(nameof(sequence));
    if (other is null) throw new ArgumentNullException(nameof(other));

    return assertion.True(sequence.Intersect(other, comparer).Any(), error);
  }

  /// <summary>
  ///   <para>Asserts that the given <see cref="IEnumerable{T}"/> contains at least one <see langword="null"/> element.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="sequence"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ContainNulls<T>(this IAssertion assertion, IEnumerable<T> sequence, string error = null) => sequence is not null ? assertion.True(sequence.Any(element => element is null), error) : throw new ArgumentNullException(nameof(sequence));

  /// <summary>
  ///   <para>Asserts that the given <see cref="IEnumerable{T}"/> contains only distinct elements.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence to inspect.</param>
  /// <param name="comparer">Comparer for equality.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="sequence"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ContainUnique<T>(this IAssertion assertion, IEnumerable<T> sequence, IEqualityComparer<T> comparer = null, string error = null) => sequence is not null ? assertion.True(!sequence.GroupBy(sequence => sequence, comparer).Where(group => group.Count() > 1).Select(group => group.Key).Any(), error) : throw new ArgumentNullException(nameof(sequence));

  /// <summary>
  ///   <para>Asserts that the given <see cref="IEnumerable{T}"/> contains a specified element at a given index.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence to inspect.</param>
  /// <param name="index">Asserted element index.</param>
  /// <param name="value">Asserted element value.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="sequence"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ElementAt<T>(this IAssertion assertion, IEnumerable<T> sequence, int index, T value, string error = null) => sequence is not null ? assertion.Equal(sequence.ElementAt(index), value, error) : throw new ArgumentNullException(nameof(sequence));

  /// <summary>
  ///   <para>Asserts that the given <see cref="IEnumerable{T}"/> represents a subset of the specified superset.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="subset">Asserted subset sequence.</param>
  /// <param name="superset">Asserted superset sequence.</param>
  /// <param name="comparer">Comparer for equality.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="subset"/>, or <paramref name="superset"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="SupersetOf{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/>
  public static IAssertion SubsetOf<T>(this IAssertion assertion, IEnumerable<T> subset, IEnumerable<T> superset, IEqualityComparer<T> comparer = null, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (subset is null) throw new ArgumentNullException(nameof(subset));
    if (superset is null) throw new ArgumentNullException(nameof(superset));

    return assertion.Empty(subset.Except(superset, comparer), error);
  }

  /// <summary>
  ///   <para>Asserts that the given <see cref="IEnumerable{T}"/> represents a superset of the specified subset.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="superset">Asserted superset sequence.</param>
  /// <param name="subset">Asserted subset sequence.</param>
  /// <param name="comparer">Comparer for equality.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="superset"/>, or <paramref name="subset"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="SubsetOf{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/>
  public static IAssertion SupersetOf<T>(this IAssertion assertion, IEnumerable<T> superset, IEnumerable<T> subset, IEqualityComparer<T> comparer = null, string error = null) => assertion.SubsetOf(subset, superset, comparer, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="IEnumerable{T}"/> represents a reversed version of another sequence.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence to inspect.</param>
  /// <param name="reversed">Asserted inverted sequence.</param>
  /// <param name="comparer">Comparer for equality.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="sequence"/>, or <paramref name="reversed"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Reversed<T>(this IAssertion assertion, IEnumerable<T> sequence, IEnumerable<T> reversed, IEqualityComparer<T> comparer = null, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (sequence is null) throw new ArgumentNullException(nameof(sequence));
    if (reversed is null) throw new ArgumentNullException(nameof(reversed));

    return assertion.EquivalentTo(sequence, reversed.Reverse(), comparer, error);
  }

  /// <summary>
  ///   <para>Asserts that the given <see cref="IEnumerable{T}"/> starts with the same elements as in the specified sequence.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence to inspect.</param>
  /// <param name="other">Asserted starting sequence.</param>
  /// <param name="comparer">Comparer for equality.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="sequence"/>, or <paramref name="other"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="EndWith{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/>
  public static IAssertion StartWith<T>(this IAssertion assertion, IEnumerable<T> sequence, IEnumerable<T> other, IEqualityComparer<T> comparer = null, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (sequence is null) throw new ArgumentNullException(nameof(sequence));
    if (other is null) throw new ArgumentNullException(nameof(other));

    return assertion.True(sequence.Take(other.Count()).SequenceEqual(other, comparer), error);
  }

  /// <summary>
  ///   <para>Asserts that the given <see cref="IEnumerable{T}"/> ends with the same elements as in the specified sequence.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence to inspect.</param>
  /// <param name="other">Asserted ending sequence.</param>
  /// <param name="comparer">Comparer for equality.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="sequence"/>, or <paramref name="other"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="StartWith{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/>
  public static IAssertion EndWith<T>(this IAssertion assertion, IEnumerable<T> sequence, IEnumerable<T> other, IEqualityComparer<T> comparer = null, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (sequence is null) throw new ArgumentNullException(nameof(sequence));
    if (other is null) throw new ArgumentNullException(nameof(other));

    return assertion.True(sequence.TakeLast(other.Count()).SequenceEqual(other, comparer), error);
  }

  /// <summary>
  ///   <para>Asserts that all elements in a given <see cref="IEnumerable{T}"/> satisfy a specified condition.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence to inspect.</param>
  /// <param name="condition">Asserted condition to be met.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="sequence"/>, or <paramref name="condition"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Match<T>(this IAssertion assertion, IEnumerable<T> sequence, Predicate<T> condition, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (sequence is null) throw new ArgumentNullException(nameof(sequence));
    if (condition is null) throw new ArgumentNullException(nameof(condition));

    return assertion.True(sequence.All(element => condition(element)), error);
  }

#if NET10_0_OR_GREATER
  /// <summary>
  ///   <para>Asserts that the given <see cref="IEnumerable{T}"/> contains a specific element at a given index.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence to inspect.</param>
  /// <param name="index">Asserted element index.</param>
  /// <param name="value">Asserted element value.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="sequence"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ElementAt<T>(this IAssertion assertion, IEnumerable<T> sequence, Index index, T value, string error = null) => sequence is not null ? assertion.Equal(sequence.ElementAt(index), value, error) : throw new ArgumentNullException(nameof(sequence));

  /// <summary>
  ///   <para>Asserts that the given <see cref="IEnumerable{T}"/> is ordered.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence to inspect.</param>
  /// <param name="comparer">Comparer for equality.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="sequence"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Ordered<T>(this IAssertion assertion, IEnumerable<T> sequence, IComparer<T> comparer = null, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (sequence is null) throw new ArgumentNullException(nameof(sequence));

    return assertion.True(sequence.SequenceEqual(sequence.Order(comparer)), error);
  }
  #endif
}