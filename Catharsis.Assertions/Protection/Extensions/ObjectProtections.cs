namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of protections for <see cref="object"/> type.</para>
/// </summary>
/// <seealso cref="object"/>
public static class ObjectProtections
{
  /// <summary>
  ///   <para>Protects given typed object from being the same instance as the specified one.</para>
  /// </summary>
  /// <typeparam name="T">Type of protected object.</typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="instance">Typed object to protect.</param>
  /// <param name="other">Object for reference equality comparison.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="protection"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static T Same<T>(this IProtection protection, T instance, object other, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    protection.Truth(ReferenceEquals(instance, other), error);

    return instance;
  }

  /// <summary>
  ///   <para>Protects given typed object from being an instance of a specified type.</para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="instance">Typed object to protect.</param>
  /// <param name="type">Type of object instance.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/>, <paramref name="instance"/>, or <paramref name="type"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
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
  ///   <para>Protects given typed object from being an instance of a specified type.</para>
  /// </summary>
  /// <typeparam name="T">Type of object instance.</typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="instance">Typed object to protect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="instance"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  /// <seealso cref="OfType(IProtection, object, Type, string)"/>
  public static object OfType<T>(this IProtection protection, object instance, string error = null) => protection.OfType(instance, typeof(T), error);

  /// <summary>
  ///   <para>Protects given typed object from being equal to the specified one.</para>
  /// </summary>
  /// <typeparam name="T">Type of object instance.</typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="instance">Typed object to protect.</param>
  /// <param name="other">Object for equality comparison.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="protection"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static T Equality<T>(this IProtection protection, T instance, object other, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    protection.Truth(Equals(instance, other), error);

    return instance;
  }

  /// <summary>
  ///   <para>Protects given typed object from being equal to the default value of its type.</para>
  /// </summary>
  /// <typeparam name="T">Type of object instance.</typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="instance">Typed object to protect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="protection"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static T Default<T>(this IProtection protection, T instance, string error = null) => protection.Equality(instance, default(T), error);

  /// <summary>
  ///   <para>Protects given typed object from being <see langword="null"/>.</para>
  /// </summary>
  /// <typeparam name="T">Type of object instance.</typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="instance">Typed object to protect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="instance"/> is a <see langword="null"/> reference.</exception>
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
  ///   <para>Protects given typed object from being equal to any of the specified values.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="value">Typed object to protect.</param>
  /// <param name="values">Values to protect from.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="values"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  /// <seealso cref="AnyOf{T}(IProtection, T, string, T[])"/>
  public static T AnyOf<T>(this IProtection protection, T value, IEnumerable<T> values, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (values is null) throw new ArgumentNullException(nameof(values));

    protection.Truth(values.Contains(value), error);

    return value;
  }

  /// <summary>
  ///   <para>Protects given typed object from being equal to any of the specified values.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="value">Typed object to protect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <param name="values">Values to protect from.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="values"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  /// <seealso cref="AnyOf{T}(IProtection, T, IEnumerable{T}, string)"/>
  public static T AnyOf<T>(this IProtection protection, T value, string error = null, params T[] values) => protection.AnyOf(value, values, error);
}