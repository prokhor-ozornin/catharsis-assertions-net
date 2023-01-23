namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class NullableAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="instance"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static IAssertion HasValue<T>(this IAssertion assertion, T? instance, string message = null) where T : struct => assertion.True(instance.HasValue, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="instance"></param>
  /// <param name="value"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static IAssertion Value<T>(this IAssertion assertion, T? instance, T value, string message = null) where T : struct => assertion.Equal(instance.GetValueOrDefault(), value, message);
}