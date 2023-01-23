namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class NullableExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<T?> HasValue<T>(this IExpectation<T?> expectation) where T : struct => expectation.Expect(instance => instance.HasValue);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <param name="value"></param>
  /// <returns></returns>
  public static IExpectation<T?> Value<T>(this IExpectation<T?> expectation, T value) where T : struct => expectation.Expect(instance => instance.GetValueOrDefault().Equals(value));
}