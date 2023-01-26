namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="object"/>
public static class ObjectExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <param name="other"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<T> Same<T>(this IExpectation<T> expectation, object other) => expectation.Expected(instance => ReferenceEquals(instance, other));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <param name="other"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<T> Equal<T>(this IExpectation<T> expectation, object other) => expectation.HaveSubject().And().Expected(instance => Equals(instance, other));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<T> Default<T>(this IExpectation<T> expectation) where T : class => expectation.Expected(instance => instance == default);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <param name="type"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<T> OfType<T>(this IExpectation<T> expectation, Type type) => expectation.HaveSubject().And().ThrowIfNull(type, nameof(type)).And().Expected(instance => instance.GetType() == type);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<T> Null<T>(this IExpectation<T> expectation) => expectation.HaveSubject().And().Expected(instance => instance is null);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <param name="values"></param>
  /// <param name="comparer"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<T> OneOf<T>(this IExpectation<T> expectation, IEnumerable<T> values, IEqualityComparer<T> comparer = null) => expectation.HaveSubject().And().ThrowIfNull(values, nameof(values)).And().Expected(value => values.Contains(value, comparer));
}