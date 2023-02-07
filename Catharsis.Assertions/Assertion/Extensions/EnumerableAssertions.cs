namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="IEnumerable{T}"/>
public static class EnumerableAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="sequence"></param>
  /// <param name="count"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Count<T>(this IAssertion assertion, IEnumerable<T> sequence, int count, string message = null) => sequence is not null ? assertion.True(sequence.Count() == count, message) : throw new ArgumentNullException(nameof(sequence));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="sequence"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Empty<T>(this IAssertion assertion, IEnumerable<T> sequence, string message = null) => sequence is not null ? assertion.True(!sequence.Any(), message) : throw new ArgumentNullException(nameof(sequence));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="sequence"></param>
  /// <param name="other"></param>
  /// <param name="comparer"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion EquivalentTo<T>(this IAssertion assertion, IEnumerable<T> sequence, IEnumerable<T> other, IEqualityComparer<T> comparer = null, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (sequence is null) throw new ArgumentNullException(nameof(sequence));
    if (other is null) throw new ArgumentNullException(nameof(other));

    return assertion.True(sequence.SequenceEqual(other, comparer), message);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="sequence"></param>
  /// <param name="element"></param>
  /// <param name="comparer"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Contain<T>(this IAssertion assertion, IEnumerable<T> sequence, T element, IEqualityComparer<T> comparer = null, string message = null) => sequence is not null ? assertion.True(sequence.Contains(element, comparer), message) : throw new ArgumentNullException(nameof(sequence));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="sequence"></param>
  /// <param name="other"></param>
  /// <param name="comparer"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion ContainAll<T>(this IAssertion assertion, IEnumerable<T> sequence, IEnumerable<T> other, IEqualityComparer<T> comparer = null, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (sequence is null) throw new ArgumentNullException(nameof(sequence));
    if (other is null) throw new ArgumentNullException(nameof(other));

    return assertion.Empty(other.Except(sequence, comparer), message);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="sequence"></param>
  /// <param name="other"></param>
  /// <param name="comparer"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion ContainAnyOf<T>(this IAssertion assertion, IEnumerable<T> sequence, IEnumerable<T> other, IEqualityComparer<T> comparer = null, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (sequence is null) throw new ArgumentNullException(nameof(sequence));
    if (other is null) throw new ArgumentNullException(nameof(other));

    return assertion.True(sequence.Intersect(other, comparer).Any(), message);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="sequence"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion ContainNulls<T>(this IAssertion assertion, IEnumerable<T> sequence, string message = null) => sequence is not null ? assertion.True(sequence.Any(element => element is null), message) : throw new ArgumentNullException(nameof(sequence));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="sequence"></param>
  /// <param name="comparer"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion ContainUnique<T>(this IAssertion assertion, IEnumerable<T> sequence, IEqualityComparer<T> comparer = null, string message = null) => sequence is not null ? assertion.True(!sequence.GroupBy(sequence => sequence, comparer).Where(group => group.Count() > 1).Select(group => group.Key).Any(), message) : throw new ArgumentNullException(nameof(sequence));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="sequence"></param>
  /// <param name="index"></param>
  /// <param name="value"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion ElementAt<T>(this IAssertion assertion, IEnumerable<T> sequence, int index, T value, string message = null) => sequence is not null ? assertion.Equal(sequence.ElementAt(index), value, message) : throw new ArgumentNullException(nameof(sequence));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="subset"></param>
  /// <param name="superset"></param>
  /// <param name="comparer"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="SupersetOf{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/>
  public static IAssertion SubsetOf<T>(this IAssertion assertion, IEnumerable<T> subset, IEnumerable<T> superset, IEqualityComparer<T> comparer = null, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (subset is null) throw new ArgumentNullException(nameof(subset));
    if (superset is null) throw new ArgumentNullException(nameof(superset));

    return assertion.Empty(subset.Except(superset, comparer), message);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="superset"></param>
  /// <param name="subset"></param>
  /// <param name="comparer"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <seealso cref="SubsetOf{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/>
  public static IAssertion SupersetOf<T>(this IAssertion assertion, IEnumerable<T> superset, IEnumerable<T> subset, IEqualityComparer<T> comparer = null, string message = null) => assertion.SubsetOf(subset, superset, comparer, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="sequence"></param>
  /// <param name="reversed"></param>
  /// <param name="comparer"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static IAssertion Reversed<T>(this IAssertion assertion, IEnumerable<T> sequence, IEnumerable<T> reversed, IEqualityComparer<T> comparer = null, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (sequence is null) throw new ArgumentNullException(nameof(sequence));
    if (reversed is null) throw new ArgumentNullException(nameof(reversed));

    return assertion.EquivalentTo(sequence, reversed.Reverse(), comparer, message);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="sequence"></param>
  /// <param name="other"></param>
  /// <param name="comparer"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="EndWith{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/>
  public static IAssertion StartWith<T>(this IAssertion assertion, IEnumerable<T> sequence, IEnumerable<T> other, IEqualityComparer<T> comparer = null, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (sequence is null) throw new ArgumentNullException(nameof(sequence));
    if (other is null) throw new ArgumentNullException(nameof(other));

    return assertion.True(sequence.Take(other.Count()).SequenceEqual(other, comparer), message);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="sequence"></param>
  /// <param name="other"></param>
  /// <param name="comparer"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="StartWith{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/>
  public static IAssertion EndWith<T>(this IAssertion assertion, IEnumerable<T> sequence, IEnumerable<T> other, IEqualityComparer<T> comparer = null, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (sequence is null) throw new ArgumentNullException(nameof(sequence));
    if (other is null) throw new ArgumentNullException(nameof(other));

    return assertion.True(sequence.TakeLast(other.Count()).SequenceEqual(other, comparer), message);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="sequence"></param>
  /// <param name="condition"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Match<T>(this IAssertion assertion, IEnumerable<T> sequence, Predicate<T> condition, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (sequence is null) throw new ArgumentNullException(nameof(sequence));
    if (condition is null) throw new ArgumentNullException(nameof(condition));

    return assertion.True(sequence.All(element => condition(element)), message);
  }

  #if NET7_0_OR_GREATER
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="sequence"></param>
  /// <param name="index"></param>
  /// <param name="value"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion ElementAt<T>(this IAssertion assertion, IEnumerable<T> sequence, Index index, T value, string message = null) => sequence is not null ? assertion.Equal(sequence.ElementAt(index), value, message) : throw new ArgumentNullException(nameof(sequence));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="sequence"></param>
  /// <param name="comparer"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Ordered<T>(this IAssertion assertion, IEnumerable<T> sequence, IComparer<T> comparer = null, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (sequence is null) throw new ArgumentNullException(nameof(sequence));

    return assertion.True(sequence.SequenceEqual(sequence.Order(comparer)), message);
  }
  #endif
}