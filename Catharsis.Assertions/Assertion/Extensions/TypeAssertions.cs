namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="Type"/>
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
  /// <param name="type"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Public(this IAssertion assertion, Type type, string message = null) => type is not null ? assertion.True(type.IsPublic && type.IsVisible, message) : throw new ArgumentNullException(nameof(type));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="type"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Internal(this IAssertion assertion, Type type, string message = null) => type is not null ? assertion.True(type.IsNotPublic && !type.IsVisible, message) : throw new ArgumentNullException(nameof(type));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="from"></param>
  /// <param name="to"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="AssignableFrom{T}(IAssertion, Type, string)"/>
  public static IAssertion AssignableFrom(this IAssertion assertion, Type from, Type to, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (from is null) throw new ArgumentNullException(nameof(from));
    if (to is null) throw new ArgumentNullException(nameof(to));
    
    return assertion.True(from.IsAssignableFrom(to), message);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="type"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <seealso cref="AssignableFrom(IAssertion, Type, Type, string)"/>
  public static IAssertion AssignableFrom<T>(this IAssertion assertion, Type type, string message = null) => assertion.AssignableFrom(type, typeof(T), message);

  #if NET7_0_OR_GREATER
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="from"></param>
  /// <param name="to"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="AssignableTo{T}(IAssertion, Type, string)"/>
  public static IAssertion AssignableTo(this IAssertion assertion, Type from, Type to, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (from is null) throw new ArgumentNullException(nameof(from));
    if (to is null) throw new ArgumentNullException(nameof(to));

    return assertion.True(from.IsAssignableTo(to), message);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="type"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <seealso cref="AssignableTo(IAssertion, Type, Type, string)"/>
  public static IAssertion AssignableTo<T>(this IAssertion assertion, Type type, string message = null) => assertion.AssignableTo(type, typeof(T), message);
  #endif
}