using System.Collections.Specialized;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="ICollection{T}"/>
/// <seealso cref="NameValueCollection"/>
public static class CollectionsProtections
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="collection"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static ICollection<T> Empty<T>(this IProtection protection, ICollection<T> collection, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (collection is null) throw new ArgumentNullException(nameof(collection));

    protection.Truth(collection.Count == 0, error);

    return collection;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="collection"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static NameValueCollection Empty(this IProtection protection, NameValueCollection collection, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (collection is null) throw new ArgumentNullException(nameof(collection));

    protection.Truth(collection.Count == 0, error);

    return collection;
  }
}