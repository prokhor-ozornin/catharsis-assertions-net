namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="IDictionary{TKey, TValue}"/>
public static class DictionaryAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="TKey"></typeparam>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="dictionary"></param>
  /// <param name="key"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ContainKey<TKey, TValue>(this IAssertion assertion, IDictionary<TKey, TValue> dictionary, TKey key, string error = null) where TKey : notnull
  {
    if (dictionary is null) throw new ArgumentNullException(nameof(dictionary));
    if (key is null) throw new ArgumentNullException(nameof(key));

    return assertion.True(dictionary.ContainsKey(key), error);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="TKey"></typeparam>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="dictionary"></param>
  /// <param name="value"></param>
  /// <param name="comparer"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ContainValue<TKey, TValue>(this IAssertion assertion, IDictionary<TKey, TValue> dictionary, TValue value, IEqualityComparer<TValue> comparer = null, string error = null) => dictionary is not null ? assertion.Contain(dictionary.Values, value, comparer, error) : throw new ArgumentNullException(nameof(dictionary));
}