namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class DictionaryExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="TKey"></typeparam>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="expectation"></param>
  /// <param name="key"></param>
  /// <returns></returns>
  public static IExpectation<IDictionary<TKey, TValue>> ContainKey<TKey, TValue>(this IExpectation<IDictionary<TKey, TValue>> expectation, TKey key) => expectation.HaveSubject().And().Expect(dictionary => dictionary.ContainsKey(key));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="TKey"></typeparam>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="expectation"></param>
  /// <param name="value"></param>
  /// <param name="comparer"></param>
  /// <returns></returns>
  public static IExpectation<IDictionary<TKey, TValue>> ContainValue<TKey, TValue>(this IExpectation<IDictionary<TKey, TValue>> expectation, TValue value, IEqualityComparer<TValue> comparer = null) => expectation.HaveSubject().And().Expect(dictionary => dictionary.Values.Contains(value, comparer));
}