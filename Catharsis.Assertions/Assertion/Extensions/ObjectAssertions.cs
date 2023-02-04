namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="object"/>
public static class ObjectAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="instance"></param>
  /// <param name="other"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Same<T>(this IAssertion assertion, T instance, object other, string message = null) => assertion.True(ReferenceEquals(instance, other), message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="instance"></param>
  /// <param name="other"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Equal<T>(this IAssertion assertion, T instance, object other, string message = null) => assertion.True(Equals(instance, other), message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="instance"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Default<T>(this IAssertion assertion, T instance, string message = null) => assertion.Equal(instance, default(T), message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="instance"></param>
  /// <param name="type"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion OfType(this IAssertion assertion, object instance, Type type, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (instance is null) throw new ArgumentNullException(nameof(instance));
    if (type is null) throw new ArgumentNullException(nameof(type));

    return assertion.True(instance.GetType() == type, message);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="instance"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static IAssertion OfType<T>(this IAssertion assertion, object instance, string message = null) => assertion.OfType(instance, typeof(T), message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="instance"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static IAssertion Null<T>(this IAssertion assertion, T instance, string message = null) => assertion.True(instance is null, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="value"></param>
  /// <param name="values"></param>
  /// <param name="comparer"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion OneOf<T>(this IAssertion assertion, T value, IEnumerable<T> values, IEqualityComparer<T> comparer = null, string message = null) => assertion.Contain(values, value, comparer, message);
}