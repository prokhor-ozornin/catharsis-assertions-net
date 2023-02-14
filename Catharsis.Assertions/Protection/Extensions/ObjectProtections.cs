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
  /// <param name="protection">Protection to perform.</param>
  /// <param name="instance"></param>
  /// <param name="other"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static T Same<T>(this IProtection protection, T instance, object other, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    protection.Truth(ReferenceEquals(instance, other), error);

    return instance;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="instance"></param>
  /// <param name="type"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="OfType{T}(IProtection, object, string)"/>
  public static object OfType(this IProtection protection, object instance, Type type, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (instance is null) throw new ArgumentNullException(nameof(instance));
    if (type is null) throw new ArgumentNullException(nameof(type));

    protection.Truth(instance.GetType() == type, error);

    return instance;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="instance"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <seealso cref="OfType(IProtection, object, Type, string)"/>
  public static object OfType<T>(this IProtection protection, object instance, string error = null) => protection.OfType(instance, typeof(T), error);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="instance"></param>
  /// <param name="other"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static T Equality<T>(this IProtection protection, T instance, object other, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    protection.Truth(Equals(instance, other), error);

    return instance;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="instance"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static T Default<T>(this IProtection protection, T instance, string error = null) => protection.Equality(instance, default(T), error);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="instance"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static T Null<T>(this IProtection protection, T instance, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    if (instance is null)
    {
      throw new ArgumentNullException(error);
    }

    return instance;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="instance"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static Lazy<T> Null<T>(this IProtection protection, Lazy<T> instance, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    if (!instance.IsValueCreated || instance.Value is null)
    {
      throw new ArgumentNullException(error);
    }
    
    return instance;
  }
}