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
  /// <param name="protection"></param>
  /// <param name="collection"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static ICollection<T> Empty<T>(this IProtection protection, ICollection<T> collection, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (collection is null) throw new ArgumentNullException(message);

    if (collection.Count == 0)
    {
      throw new ArgumentException(message);
    }

    return collection;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection"></param>
  /// <param name="collection"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static NameValueCollection Empty(this IProtection protection, NameValueCollection collection, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (collection is null) throw new ArgumentNullException(message);

    if (collection.Count == 0)
    {
      throw new ArgumentException(message);
    }

    return collection;
  }
}