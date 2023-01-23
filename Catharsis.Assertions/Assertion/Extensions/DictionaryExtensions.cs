﻿namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class DictionaryAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="TKey"></typeparam>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="dictionary"></param>
  /// <param name="key"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion ContainKey<TKey, TValue>(this IAssertion assertion, IDictionary<TKey, TValue> dictionary, TKey key, string message = null) => dictionary is not null ? assertion.True(dictionary.ContainsKey(key), message) : throw new ArgumentNullException(nameof(dictionary));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="TKey"></typeparam>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="dictionary"></param>
  /// <param name="value"></param>
  /// <param name="comparer"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion ContainValue<TKey, TValue>(this IAssertion assertion, IDictionary<TKey, TValue> dictionary, TValue value, IEqualityComparer<TValue> comparer = null, string message = null) => dictionary is not null ? assertion.Contain(dictionary.Values, value, comparer, message) : throw new ArgumentNullException(nameof(dictionary));
}