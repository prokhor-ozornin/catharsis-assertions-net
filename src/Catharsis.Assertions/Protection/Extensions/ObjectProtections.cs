namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of protections for the <see cref="object"/> type.</para>
/// </summary>
/// <seealso cref="object"/>
public static class ObjectProtections
{
  /// <param name="protection">Protection to perform.</param>
  extension(IProtection protection)
  {
    /// <summary>
    ///   <para>This function protects the given <see cref="object"/> from being the same instance as another object, ensuring that their references are not equal.</para>
    /// </summary>
    /// <typeparam name="T">Type of object.</typeparam>
    /// <param name="instance">Object to protect.</param>
    /// <param name="other">Target for equality comparison.</param>
    /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="protection"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
    public T Same<T>(T instance, object other, string error = null)
    {
      if (protection is null) throw new ArgumentNullException(nameof(protection));

      protection.Truth(ReferenceEquals(instance, other), error);

      return instance;
    }

    /// <summary>
    ///   <para>This function protects the given <see cref="object"/> from having a specific type, ensuring that its <see cref="Type"/> is different.</para>
    /// </summary>
    /// <param name="instance">Object to protect.</param>
    /// <param name="type">Type of object.</param>
    /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="protection"/>, <paramref name="instance"/>, or <paramref name="type"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
    /// <seealso cref="OfType{T}(IProtection, object, string)"/>
    public object OfType(object instance, Type type, string error = null)
    {
      if (protection is null) throw new ArgumentNullException(nameof(protection));
      if (instance is null) throw new ArgumentNullException(nameof(instance));
      if (type is null) throw new ArgumentNullException(nameof(type));

      protection.Truth(instance.GetType() == type, error);

      return instance;
    }

    /// <summary>
    ///   <para>This function protects the given <see cref="object"/> from having a specific type, ensuring that its <see cref="Type"/> is different.</para>
    /// </summary>
    /// <typeparam name="T">Type of object.</typeparam>
    /// <param name="instance">Object to protect.</param>
    /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="instance"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
    /// <seealso cref="OfType(IProtection, object, Type, string)"/>
    public object OfType<T>(object instance, string error = null) => protection.OfType(instance, typeof(T), error);

    /// <summary>
    ///   <para>This function protects the given <see cref="object"/> from being equal to another object, ensuring that they are not considered equal.</para>
    /// </summary>
    /// <typeparam name="T">Type of object.</typeparam>
    /// <param name="instance">Object to protect.</param>
    /// <param name="other">Target for equality comparison.</param>
    /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="protection"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
    public T Equality<T>(T instance, object other, string error = null)
    {
      if (protection is null) throw new ArgumentNullException(nameof(protection));

      protection.Truth(Equals(instance, other), error);

      return instance;
    }

    /// <summary>
    ///   <para>This function protects the given <see cref="object"/> from being equal to the default value of its <see cref="Type"/>, ensuring that it is different.</para>
    /// </summary>
    /// <typeparam name="T">Type of object.</typeparam>
    /// <param name="instance">Object to protect.</param>
    /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="protection"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
    public T Default<T>(T instance, string error = null) => protection.Equality(instance, default(T), error);

    /// <summary>
    ///   <para>This function protects the given <see cref="object"/> from being <see langword="null"/>, ensuring that it represents a valid reference.</para>
    /// </summary>
    /// <typeparam name="T">Type of object.</typeparam>
    /// <param name="instance">Object to protect.</param>
    /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="instance"/> is <see langword="null"/>.</exception>
    public T Null<T>(T instance, string error = null)
    {
      if (protection is null) throw new ArgumentNullException(nameof(protection));

      if (instance is null)
      {
        throw new ArgumentNullException(error);
      }

      return instance;
    }

    /// <summary>
    ///   <para>This function protects the given <see cref="object"/> from being equal to a specified range of values, ensuring it does not match any of the specified values.</para>
    /// </summary>
    /// <typeparam name="T">Type of values.</typeparam>
    /// <param name="value">Object to protect.</param>
    /// <param name="values">Range of values.</param>
    /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="values"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
    /// <seealso cref="AnyOf{T}(IProtection, T, string, T[])"/>
    public T AnyOf<T>(T value, IEnumerable<T> values, string error = null)
    {
      if (protection is null) throw new ArgumentNullException(nameof(protection));
      if (values is null) throw new ArgumentNullException(nameof(values));

      protection.Truth(values.Contains(value), error);

      return value;
    }

    /// <summary>
    ///   <para>This function protects the given <see cref="object"/> from being equal to a specified range of values, ensuring it does not match any of the specified values.</para>
    /// </summary>
    /// <typeparam name="T">TType of values.</typeparam>
    /// <param name="value">Object to protect.</param>
    /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
    /// <param name="values">Range of values.</param>
    /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="values"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
    /// <seealso cref="AnyOf{T}(IProtection, T, IEnumerable{T}, string)"/>
    public T AnyOf<T>(T value, string error = null, params T[] values) => protection.AnyOf(value, values, error);
  }
}