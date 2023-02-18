using System.Collections.Specialized;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of protections for <see cref="NameValueCollection"/> types.</para>
/// </summary>
/// <seealso cref="NameValueCollection"/>
public static class NameValueCollectionProtections
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="collection"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="collection"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static NameValueCollection Empty(this IProtection protection, NameValueCollection collection, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (collection is null) throw new ArgumentNullException(nameof(collection));

    protection.Truth(collection.Count == 0, error);

    return collection;
  }
}