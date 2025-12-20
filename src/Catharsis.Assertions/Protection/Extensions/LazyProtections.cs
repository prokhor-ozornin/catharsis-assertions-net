namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of protections for the <see cref="Lazy{T}"/> type.</para>
/// </summary>
/// <seealso cref="Lazy{T}"/>
public static class LazyProtections
{
  /// <param name="protection">Protection to perform.</param>
  extension(IProtection protection)
  {
    /// <summary>
    ///   <para>This function protects the given <see cref="Lazy{T}"/> object from being <see langword="null"/>, ensuring that it has a valid value.</para>
    /// </summary>
    /// <typeparam name="T">Type of lazily instantiated instance.</typeparam>
    /// <param name="instance">Object to protect.</param>
    /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public Lazy<T> Null<T>(Lazy<T> instance, string error = null)
    {
      if (protection is null) throw new ArgumentNullException(nameof(protection));

      if (instance is null || !instance.IsValueCreated || instance.Value is null)
      {
        throw new ArgumentNullException(error);
      }
    
      return instance;
    }
  }
}