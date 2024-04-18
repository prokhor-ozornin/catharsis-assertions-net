namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for enumerable types.</para>
/// </summary>
/// <seealso cref="IEnumerable{T}"/>
public static class IEnumerableAssertions
{
  /// <summary>
  ///   <para>Asserts that a given sequence contains a specified number of elements.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence of elements to inspect.</param>
  /// <param name="count">Asserted elements count.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="sequence"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Count<T>(this IAssertion assertion, IEnumerable<T> sequence, int count, string error = null) => sequence is not null ? assertion.True(sequence.Count() == count, error) : throw new ArgumentNullException(nameof(sequence));

  /// <summary>
  ///   <para>Asserts that a given sequence is empty (contains no elements).</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence of elements to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="sequence"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Empty<T>(this IAssertion assertion, IEnumerable<T> sequence, string error = null) => sequence is not null ? assertion.True(!sequence.Any(), error) : throw new ArgumentNullException(nameof(sequence));

  /// <summary>
  ///   <para>Asserts that a given sequence is equal to a specified one.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="left">Sequence of elements to inspect.</param>
  /// <param name="right">Asserted sequence to compare for equality.</param>
  /// <param name="comparer">Comparer to perform comparison of objects for equality.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="left"/>, or <paramref name="right"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion EquivalentTo<T>(this IAssertion assertion, IEnumerable<T> left, IEnumerable<T> right, IEqualityComparer<T> comparer = null, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (left is null) throw new ArgumentNullException(nameof(left));
    if (right is null) throw new ArgumentNullException(nameof(right));

    return assertion.True(left.SequenceEqual(right, comparer), error);
  }

  /// <summary>
  ///   <para>Asserts that a given sequence contains a specified element.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence of elements to inspect.</param>
  /// <param name="element">Asserted sequence element.</param>
  /// <param name="comparer">Comparer to perform comparison of objects for equality.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="sequence"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Contain<T>(this IAssertion assertion, IEnumerable<T> sequence, T element, IEqualityComparer<T> comparer = null, string error = null) => sequence is not null ? assertion.True(sequence.Contains(element, comparer), error) : throw new ArgumentNullException(nameof(sequence));

  /// <summary>
  ///   <para>Asserts that a given sequence contains all of the specified elements at least once.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="superset">Sequence of elements to inspect.</param>
  /// <param name="subset">Set of elements all of which are asserted to be contained in the sequence.</param>
  /// <param name="comparer">Comparer to perform comparison of objects for equality.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="superset"/>, or <paramref name="subset"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ContainAll<T>(this IAssertion assertion, IEnumerable<T> superset, IEnumerable<T> subset, IEqualityComparer<T> comparer = null, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (superset is null) throw new ArgumentNullException(nameof(superset));
    if (subset is null) throw new ArgumentNullException(nameof(subset));

    return assertion.Empty(subset.Except(superset, comparer), error);
  }

  /// <summary>
  ///   <para>Asserts that a given sequence contains any of the specified elements at least once.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="superset">Sequence of elements to inspect.</param>
  /// <param name="subset">Set of elements one or more of which is asserted to be contained in the sequence.</param>
  /// <param name="comparer">Comparer to perform comparison of objects for equality.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="superset"/>, or <paramref name="subset"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ContainAnyOf<T>(this IAssertion assertion, IEnumerable<T> superset, IEnumerable<T> subset, IEqualityComparer<T> comparer = null, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (superset is null) throw new ArgumentNullException(nameof(superset));
    if (subset is null) throw new ArgumentNullException(nameof(subset));

    return assertion.True(superset.Intersect(subset, comparer).Any(), error);
  }

  /// <summary>
  ///   <para>Asserts that a given sequence contains at least one <see langword="null"/> reference.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence of elements to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="sequence"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ContainNulls<T>(this IAssertion assertion, IEnumerable<T> sequence, string error = null) => sequence is not null ? assertion.True(sequence.Any(element => element is null), error) : throw new ArgumentNullException(nameof(sequence));

  /// <summary>
  ///   <para>Asserts that a given sequence contains only unique elements.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence of elements to inspect.</param>
  /// <param name="comparer">Comparer to perform comparison of objects for equality.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="sequence"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ContainUnique<T>(this IAssertion assertion, IEnumerable<T> sequence, IEqualityComparer<T> comparer = null, string error = null) => sequence is not null ? assertion.True(!sequence.GroupBy(sequence => sequence, comparer).Where(group => group.Count() > 1).Select(group => group.Key).Any(), error) : throw new ArgumentNullException(nameof(sequence));

  /// <summary>
  ///   <para>Asserts that a given sequence contains a specified element at a specified index.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence of elements to inspect.</param>
  /// <param name="index">Asserted element index.</param>
  /// <param name="value">Asserted element value.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="sequence"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ElementAt<T>(this IAssertion assertion, IEnumerable<T> sequence, int index, T value, string error = null) => sequence is not null ? assertion.Equal(sequence.ElementAt(index), value, error) : throw new ArgumentNullException(nameof(sequence));

  /// <summary>
  ///   <para>Asserts that a given sequence represents a subset of a specified superset.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="subset">Asserted subset sequence.</param>
  /// <param name="superset">Asserted superset sequence.</param>
  /// <param name="comparer">Comparer to perform comparison of objects for equality.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="subset"/>, or <paramref name="superset"/> is a <see langword="null"/> reference.</exception>
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
  ///   <para>Asserts that a given sequence represents a superset for a specified subset.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="superset">Asserted superset sequence.</param>
  /// <param name="subset">Asserted subset sequence.</param>
  /// <param name="comparer">Comparer to perform comparison of objects for equality.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="superset"/>, or <paramref name="subset"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="SubsetOf{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/>
  public static IAssertion SupersetOf<T>(this IAssertion assertion, IEnumerable<T> superset, IEnumerable<T> subset, IEqualityComparer<T> comparer = null, string error = null) => assertion.SubsetOf(subset, superset, comparer, error);

  /// <summary>
  ///   <para>Asserts that a given sequence represents an inverted version of the specified one.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence of elements to inspect.</param>
  /// <param name="reversed">Asserted sequence with inverted order of elements.</param>
  /// <param name="comparer">Comparer to perform comparison of objects for equality.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="sequence"/>, or <paramref name="reversed"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Reversed<T>(this IAssertion assertion, IEnumerable<T> sequence, IEnumerable<T> reversed, IEqualityComparer<T> comparer = null, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (sequence is null) throw new ArgumentNullException(nameof(sequence));
    if (reversed is null) throw new ArgumentNullException(nameof(reversed));

    return assertion.EquivalentTo(sequence, reversed.Reverse(), comparer, error);
  }

  /// <summary>
  ///   <para>Asserts that a given sequence starts with the same elements as in a specified sequence.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="superset">Sequence of elements to inspect.</param>
  /// <param name="subset">Asserted starting sequence.</param>
  /// <param name="comparer">Comparer to perform comparison of objects for equality.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="superset"/>, or <paramref name="subset"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="EndWith{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/>
  public static IAssertion StartWith<T>(this IAssertion assertion, IEnumerable<T> superset, IEnumerable<T> subset, IEqualityComparer<T> comparer = null, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (superset is null) throw new ArgumentNullException(nameof(superset));
    if (subset is null) throw new ArgumentNullException(nameof(subset));

    return assertion.True(superset.Take(subset.Count()).SequenceEqual(subset, comparer), error);
  }

  /// <summary>
  ///   <para>Asserts that a given sequence ends with the same elements as in a specified sequence.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="superset">Sequence of elements to inspect.</param>
  /// <param name="subset">Asserted ending sequence.</param>
  /// <param name="comparer">Comparer to perform comparison of objects for equality.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="superset"/>, or <paramref name="subset"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="StartWith{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/>
  public static IAssertion EndWith<T>(this IAssertion assertion, IEnumerable<T> superset, IEnumerable<T> subset, IEqualityComparer<T> comparer = null, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (superset is null) throw new ArgumentNullException(nameof(superset));
    if (subset is null) throw new ArgumentNullException(nameof(subset));

    return assertion.True(superset.TakeLast(subset.Count()).SequenceEqual(subset, comparer), error);
  }

  /// <summary>
  ///   <para>Asserts that all elements of a given sequence satisfy a specified condition.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence of elements to inspect.</param>
  /// <param name="condition">Asserted condition to be satisfied.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="sequence"/>, or <paramref name="condition"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Match<T>(this IAssertion assertion, IEnumerable<T> sequence, Predicate<T> condition, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (sequence is null) throw new ArgumentNullException(nameof(sequence));
    if (condition is null) throw new ArgumentNullException(nameof(condition));

    return assertion.True(sequence.All(element => condition(element)), error);
  }

#if NET7_0_OR_GREATER
  /// <summary>
  ///   <para>Asserts that a given sequence contains a specified element at a specified index.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence of elements to inspect.</param>
  /// <param name="index">Asserted element index.</param>
  /// <param name="value">Asserted element value.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="sequence"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ElementAt<T>(this IAssertion assertion, IEnumerable<T> sequence, Index index, T value, string error = null) => sequence is not null ? assertion.Equal(sequence.ElementAt(index), value, error) : throw new ArgumentNullException(nameof(sequence));

  /// <summary>
  ///   <para>Asserts that a given sequence is ordered.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="sequence">Sequence of elements to inspect.</param>
  /// <param name="comparer">Comparer to perform comparison of objects.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="sequence"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Ordered<T>(this IAssertion assertion, IEnumerable<T> sequence, IComparer<T> comparer = null, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (sequence is null) throw new ArgumentNullException(nameof(sequence));

    return assertion.True(sequence.SequenceEqual(sequence.Order(comparer)), error);
  }
  #endif
}