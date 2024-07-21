using System.Collections.Specialized;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of protections for <see cref="NameValueCollection"/> types.</para>
/// </summary>
/// <seealso cref="NameValueCollection"/>
public static class NameValueCollectionProtections
{
  /// <summary>
  ///   <para>This function protects the given <see cref="NameValueCollection"/> from being empty, ensuring that it contains at least one element.</para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="collection">Collection to protect.</param>
  /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="collection"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static NameValueCollection Empty(this IProtection protection, NameValueCollection collection, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (collection is null) throw new ArgumentNullException(nameof(collection));

    protection.Truth(collection.Count == 0, error);

    return collection;
  }
}