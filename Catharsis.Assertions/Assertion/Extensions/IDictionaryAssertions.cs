namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for dictionary types.</para>
/// </summary>
/// <seealso cref="IDictionary{TKey, TValue}"/>
public static class IDictionaryAssertions
{
  /// <summary>
  ///   <para>Asserts that a given dictionary contains an element with specified key.</para>
  /// </summary>
  /// <typeparam name="TKey">Type of dictionary keys.</typeparam>
  /// <typeparam name="TValue">Type of dictionary values.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="dictionary">Dictionary to inspect.</param>
  /// <param name="key">Key to search for.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="dictionary"/>, or <paramref name="key"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ContainKey<TKey, TValue>(this IAssertion assertion, IDictionary<TKey, TValue> dictionary, TKey key, string error = null) where TKey : notnull
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (dictionary is null) throw new ArgumentNullException(nameof(dictionary));
    if (key is null) throw new ArgumentNullException(nameof(key));

    return assertion.True(dictionary.ContainsKey(key), error);
  }

  /// <summary>
  ///   <para>Asserts that a given dictionary contains an element with specified value.</para>
  /// </summary>
  /// <typeparam name="TKey">Type of dictionary keys.</typeparam>
  /// <typeparam name="TValue">Type of dictionary values.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="dictionary">Dictionary to inspect.</param>
  /// <param name="value">Value to search for.</param>
  /// <param name="comparer">Equality comparer for dictionary values.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="dictionary"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ContainValue<TKey, TValue>(this IAssertion assertion, IDictionary<TKey, TValue> dictionary, TValue value, IEqualityComparer<TValue> comparer = null, string error = null) => dictionary is not null ? assertion.Contain(dictionary.Values, value, comparer, error) : throw new ArgumentNullException(nameof(dictionary));
}