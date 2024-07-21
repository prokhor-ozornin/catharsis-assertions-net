namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for nullable types.</para>
/// </summary>
/// <seealso cref="Nullable{T}"/>
public static class NullableExpectations
{
  /// <summary>
  ///   <para>Expects that a given <see cref="Nullable{T}"/> object has a valid value of its underlying type.</para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<T?> HasValue<T>(this IExpectation<T?> expectation) where T : struct => expectation.Expected(instance => instance.HasValue);

  /// <summary>
  ///   <para>Expects that a given <see cref="Nullable{T}"/> object has a specified value, either default or not.</para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="value">Expected object value.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<T?> Value<T>(this IExpectation<T?> expectation, T value) where T : struct => expectation.Expected(instance => instance.GetValueOrDefault().Equals(value));
}