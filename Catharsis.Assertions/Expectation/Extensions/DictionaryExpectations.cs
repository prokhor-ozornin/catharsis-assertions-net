namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="IDictionary{TKey, TValue}"/>
public static class DictionaryExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="TKey"></typeparam>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="key"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="key"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<IDictionary<TKey, TValue>> ContainKey<TKey, TValue>(this IExpectation<IDictionary<TKey, TValue>> expectation, TKey key) where TKey : notnull => expectation.HaveSubject().And().ThrowIfNull(key, nameof(key)).And().Expected(dictionary => dictionary.ContainsKey(key));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="TKey"></typeparam>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="value"></param>
  /// <param name="comparer"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<IDictionary<TKey, TValue>> ContainValue<TKey, TValue>(this IExpectation<IDictionary<TKey, TValue>> expectation, TValue value, IEqualityComparer<TValue> comparer = null) => expectation.HaveSubject().And().Expected(dictionary => dictionary.Values.Contains(value, comparer));
}