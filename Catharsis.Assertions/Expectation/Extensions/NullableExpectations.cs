namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for nullable types.</para>
/// </summary>
/// <seealso cref="Nullable{T}"/>
public static class NullableExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<T?> HasValue<T>(this IExpectation<T?> expectation) where T : struct => expectation.Expected(instance => instance.HasValue);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="value"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<T?> Value<T>(this IExpectation<T?> expectation, T value) where T : struct => expectation.Expected(instance => instance.GetValueOrDefault().Equals(value));
}