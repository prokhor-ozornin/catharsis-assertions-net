namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of protections for <see cref="ICollection{T}"/> types.</para>
/// </summary>
/// <seealso cref="ICollection{T}"/>
public static class ICollectionProtections
{
  /// <param name="protection">Protection to perform.</param>
  extension(IProtection protection)
  {
    /// <summary>
    ///   <para>This function protects the given <see cref="ICollection{T}"/> from being empty, ensuring that it contains at least one element.</para>
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="collection">Collection to protect.</param>
    /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="collection"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
    public ICollection<T> Empty<T>(ICollection<T> collection, string error = null)
    {
      if (protection is null) throw new ArgumentNullException(nameof(protection));
      if (collection is null) throw new ArgumentNullException(nameof(collection));

      protection.Truth(collection.Count == 0, error);

      return collection;
    }
  }
}