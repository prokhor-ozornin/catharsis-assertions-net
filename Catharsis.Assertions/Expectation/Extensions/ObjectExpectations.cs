namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class ObjectExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <param name="other"></param>
  /// <returns></returns>
  public static IExpectation<T> Same<T>(this IExpectation<T> expectation, object other) => expectation.Expect(instance => ReferenceEquals(instance, other));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <param name="other"></param>
  /// <returns></returns>
  public static IExpectation<T> Equal<T>(this IExpectation<T> expectation, object other) => expectation.HaveSubject().And().Expect(instance => Equals(instance, other));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<T> Default<T>(this IExpectation<T> expectation) where T : class => expectation.Expect(instance => instance == default);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <param name="type"></param>
  /// <returns></returns>
  public static IExpectation<T> OfType<T>(this IExpectation<T> expectation, Type type) => expectation.HaveSubject().And().ThrowIfNull(type, nameof(type)).And().Expect(instance => instance.GetType() == type);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<T> Null<T>(this IExpectation<T> expectation) => expectation.HaveSubject().And().Expect(instance => instance is null);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <param name="values"></param>
  /// <param name="comparer"></param>
  /// <returns></returns>
  public static IExpectation<T> OneOf<T>(this IExpectation<T> expectation, IEnumerable<T> values, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(values, nameof(values)).And().Expect(value => values.Contains(value, comparer));
}