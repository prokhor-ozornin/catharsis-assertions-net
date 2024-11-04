namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="Nullable{T}"/> type.</para>
/// </summary>
/// <seealso cref="Nullable{T}"/>
public static class NullableExpectations
{
  /// <summary>
  ///   <para>Expects that the given <see cref="Nullable{T}"/> object has a value.</para>
  /// </summary>
  /// <typeparam name="T">The type of the nullable object.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<T?> HasValue<T>(this IExpectation<T?> expectation) where T : struct => expectation.Expected(instance => instance.HasValue);

  /// <summary>
  ///   <para>Expects that the given <see cref="Nullable{T}"/> object has the specified value.</para>
  /// </summary>
  /// <typeparam name="T">The type of the nullable object.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="value">Expected object's value.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<T?> Value<T>(this IExpectation<T?> expectation, T value) where T : struct => expectation.Expected(instance => instance.GetValueOrDefault().Equals(value));
}