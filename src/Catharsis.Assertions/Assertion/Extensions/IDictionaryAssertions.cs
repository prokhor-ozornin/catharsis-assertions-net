namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for <see cref="IDictionary{TKey,TValue}"/> types.</para>
/// </summary>
/// <seealso cref="IDictionary{TKey, TValue}"/>
public static class IDictionaryAssertions
{
  /// <summary>
  ///   <para>Asserts that the given <see cref="IDictionary{TKey,TValue}"/> has an element with the specified key.</para>
  /// </summary>
  /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
  /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="dictionary">Dictionary to inspect.</param>
  /// <param name="key">Asserted key's value.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="dictionary"/>, or <paramref name="key"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ContainKey<TKey, TValue>(this IAssertion assertion, IDictionary<TKey, TValue> dictionary, TKey key, string error = null) where TKey : notnull
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (dictionary is null) throw new ArgumentNullException(nameof(dictionary));
    if (key is null) throw new ArgumentNullException(nameof(key));

    return assertion.True(dictionary.ContainsKey(key), error);
  }

  /// <summary>
  ///   <para>Asserts that the given <see cref="IDictionary{TKey,TValue}"/> has an element with the specified value.</para>
  /// </summary>
  /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
  /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="dictionary">Dictionary to inspect.</param>
  /// <param name="value">Asserted element's value.</param>
  /// <param name="comparer">Equality comparer for dictionary's values.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="dictionary"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ContainValue<TKey, TValue>(this IAssertion assertion, IDictionary<TKey, TValue> dictionary, TValue value, IEqualityComparer<TValue> comparer = null, string error = null) => dictionary is not null ? assertion.Contain(dictionary.Values, value, comparer, error) : throw new ArgumentNullException(nameof(dictionary));
}