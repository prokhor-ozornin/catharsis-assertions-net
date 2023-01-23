namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
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
  public static T Being<T>(this IProtection protection, T instance, object other, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    if (ReferenceEquals(instance, other))
    {
      throw new ArgumentException(message);
    }

    return instance;
  }

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

    if (Equals(instance, other))
    {
      throw new ArgumentException(message);
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
  /// <exception cref="ArgumentException"></exception>
  public static T Default<T>(this IProtection protection, T instance, string message = null) where T : class
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    if (instance == default)
    {
      throw new ArgumentException(message);
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