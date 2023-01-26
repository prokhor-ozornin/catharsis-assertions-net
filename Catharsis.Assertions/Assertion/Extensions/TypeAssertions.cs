namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class TypeAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="type"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Abstract(this IAssertion assertion, Type type, string message = null) => type is not null ? assertion.True(type.IsAbstract && !type.IsSealed, message) : throw new ArgumentNullException(nameof(type));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="type"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Sealed(this IAssertion assertion, Type type, string message = null) => type is not null ? assertion.True(type.IsSealed && !type.IsAbstract, message) : throw new ArgumentNullException(nameof(type));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="type"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Static(this IAssertion assertion, Type type, string message = null) => type is not null ? assertion.True(type.IsAbstract && type.IsSealed, message) : throw new ArgumentNullException(nameof(type));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="current"></param>
  /// <param name="target"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <see cref="AssignableFrom{T}(IAssertion, Type, string)"/>
  public static IAssertion AssignableFrom(this IAssertion assertion, Type current, Type target, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (current is null) throw new ArgumentNullException(nameof(current));
    if (target is null) throw new ArgumentNullException(nameof(target));
    
    return assertion.True(current.IsAssignableFrom(target), message);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="current"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <see cref="AssignableFrom(IAssertion, Type, Type, string)"/>
  public static IAssertion AssignableFrom<T>(this IAssertion assertion, Type current, string message = null) => assertion.AssignableFrom(current, typeof(T), message);

  #if NET7_0_OR_GREATER
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="current"></param>
  /// <param name="target"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <see cref="AssignableTo{T}(IAssertion, Type, string)"/>
  public static IAssertion AssignableTo(this IAssertion assertion, Type current, Type target, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (current is null) throw new ArgumentNullException(nameof(current));
    if (target is null) throw new ArgumentNullException(nameof(target));

    return assertion.True(current.IsAssignableTo(target), message);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="current"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <see cref="AssignableTo(IAssertion, Type, Type, string)"/>
  public static IAssertion AssignableTo<T>(this IAssertion assertion, Type current, string message = null) => assertion.AssignableTo(current, typeof(T), message);
  #endif
}