namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of protections for <see cref="ICollection{T}"/> types.</para>
/// </summary>
/// <seealso cref="ICollection{T}"/>
public static class ICollectionProtections
{
  /// <summary>
  ///   <para>Protects given collection from being empty (containing no elements).</para>
  /// </summary>
  /// <typeparam name="T">Type of elements inside the collection.</typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="collection">Collection to protect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="collection"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static ICollection<T> Empty<T>(this IProtection protection, ICollection<T> collection, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (collection is null) throw new ArgumentNullException(nameof(collection));

    protection.Truth(collection.Count == 0, error);

    return collection;
  }
}