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
  /// <typeparam name="T">Type of expectation's subject.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="other"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<T> Same<T>(this IExpectation<T> expectation, object other) => expectation.Expected(instance => ReferenceEquals(instance, other));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="other"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<T> Equal<T>(this IExpectation<T> expectation, object other) => expectation.Expected(instance => Equals(instance, other));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<T> Default<T>(this IExpectation<T> expectation) => expectation.Equal(default(T));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="type"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<T> OfType<T>(this IExpectation<T> expectation, Type type) => expectation.HaveSubject().And().ThrowIfNull(type, nameof(type)).And().Expected(instance => instance.GetType() == type);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<T> Null<T>(this IExpectation<T> expectation) => expectation.Expected(instance => instance is null);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="sequence"></param>
  /// <param name="comparer"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<T> OneOf<T>(this IExpectation<T> expectation, IEnumerable<T> sequence, IEqualityComparer<T> comparer = null) => expectation.ThrowIfNull(sequence, nameof(sequence)).And().Expected(value => sequence.Contains(value, comparer));
}