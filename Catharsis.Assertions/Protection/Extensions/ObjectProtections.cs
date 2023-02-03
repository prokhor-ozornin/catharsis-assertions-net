namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="object"/>
public static class ObjectProtections
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection"></param>
  /// <param name="instance"></param>
  /// <param name="other"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static T Same<T>(this IProtection protection, T instance, object other, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    protection.Truth(ReferenceEquals(instance, other), message);

    return instance;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection"></param>
  /// <param name="instance"></param>
  /// <param name="type"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static object OfType(this IProtection protection, object instance, Type type, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (instance is null) throw new ArgumentNullException(nameof(instance));
    if (type is null) throw new ArgumentNullException(nameof(type));

    protection.Truth(instance.GetType() == type, message);

    return instance;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection"></param>
  /// <param name="instance"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static object OfType<T>(this IProtection protection, object instance, string message = null) => protection.OfType(instance, typeof(T), message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection"></param>
  /// <param name="instance"></param>
  /// <param name="other"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static T Equality<T>(this IProtection protection, T instance, object other, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    protection.Truth(Equals(instance, other), message);

    return instance;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection"></param>
  /// <param name="instance"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static T Default<T>(this IProtection protection, T instance, string message = null) where T : class
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    protection.Truth(instance == default, message);

    return instance;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection"></param>
  /// <param name="instance"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static T Null<T>(this IProtection protection, T instance, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    if (instance is null)
    {
      throw new ArgumentNullException(message);
    }

    return instance;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection"></param>
  /// <param name="instance"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static Lazy<T> Null<T>(this IProtection protection, Lazy<T> instance, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    if (!instance.IsValueCreated || instance.Value is null)
    {
      throw new ArgumentNullException(message);
    }
    
    return instance;
  }
}