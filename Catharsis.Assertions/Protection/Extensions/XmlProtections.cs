using System.Xml;
using System.Xml.Linq;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="XmlDocument"/>
/// <seealso cref="XDocument"/>
public static class XmlProtections
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection"></param>
  /// <param name="document"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static XmlDocument Empty(this IProtection protection, XmlDocument document, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (document is null) throw new ArgumentNullException(message);

    if (document.ChildNodes.Count == 0)
    {
      throw new ArgumentException(message);
    }

    return document;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection"></param>
  /// <param name="document"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static XDocument Empty(this IProtection protection, XDocument document, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (document is null) throw new ArgumentNullException(message);

    if (!document.Nodes().Any())
    {
      throw new ArgumentException(message);
    }

    return document;
  }
}