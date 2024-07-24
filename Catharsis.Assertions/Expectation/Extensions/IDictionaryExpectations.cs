namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for <see cref="IDictionary{TKey,TValue}"/> types.</para>
/// </summary>
/// <seealso cref="IDictionary{TKey, TValue}"/>
public static class IDictionaryExpectations
{
  /// <summary>
  ///   <para>Expects that the given <see cref="IDictionary{TKey,TValue}"/> has an element with the specified key.</para>
  /// </summary>
  /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
  /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="key">Expected key's value.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="key"/> is <see langword="null"/>.</exception>
  public static IExpectation<IDictionary<TKey, TValue>> ContainKey<TKey, TValue>(this IExpectation<IDictionary<TKey, TValue>> expectation, TKey key) where TKey : notnull => expectation.HaveSubject().And().ThrowIfNull(key, nameof(key)).And().Expected(dictionary => dictionary.ContainsKey(key));

  /// <summary>
  ///   <para>Expects that the given <see cref="IDictionary{TKey,TValue}"/> has an element with the specified value.</para>
  /// </summary>
  /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
  /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="value">Expected element's value.</param>
  /// <param name="comparer">Equality comparer for dictionary's values.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<IDictionary<TKey, TValue>> ContainValue<TKey, TValue>(this IExpectation<IDictionary<TKey, TValue>> expectation, TValue value, IEqualityComparer<TValue> comparer = null) => expectation.HaveSubject().And().Expected(dictionary => dictionary.Values.Contains(value, comparer));
}