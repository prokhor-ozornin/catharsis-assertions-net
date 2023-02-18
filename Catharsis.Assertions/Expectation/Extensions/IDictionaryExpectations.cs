namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for dictionary types.</para>
/// </summary>
/// <seealso cref="IDictionary{TKey, TValue}"/>
public static class IDictionaryExpectations
{
  /// <summary>
  ///   <para>Expects that a given dictionary contains an element with specified key.</para>
  /// </summary>
  /// <typeparam name="TKey">Type of dictionary keys.</typeparam>
  /// <typeparam name="TValue">Type of dictionary values.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="key">Key to look for.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="key"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<IDictionary<TKey, TValue>> ContainKey<TKey, TValue>(this IExpectation<IDictionary<TKey, TValue>> expectation, TKey key) where TKey : notnull => expectation.HaveSubject().And().ThrowIfNull(key, nameof(key)).And().Expected(dictionary => dictionary.ContainsKey(key));

  /// <summary>
  ///   <para>Expects that a given dictionary contains an element with specified value.</para>
  /// </summary>
  /// <typeparam name="TKey">Type of dictionary keys.</typeparam>
  /// <typeparam name="TValue">Type of dictionary values.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="value">Value to search for.</param>
  /// <param name="comparer">Equality comparer for dictionary values.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<IDictionary<TKey, TValue>> ContainValue<TKey, TValue>(this IExpectation<IDictionary<TKey, TValue>> expectation, TValue value, IEqualityComparer<TValue> comparer = null) => expectation.HaveSubject().And().Expected(dictionary => dictionary.Values.Contains(value, comparer));
}