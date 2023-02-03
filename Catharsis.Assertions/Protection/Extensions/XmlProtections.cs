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
    if (document is null) throw new ArgumentNullException(nameof(document));

    protection.Truth(!document.HasChildNodes, message);

    return document;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection"></param>
  /// <param name="node"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static XmlNode Empty(this IProtection protection, XmlNode node, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (node is null) throw new ArgumentNullException(nameof(node));

    protection.Truth(!node.HasChildNodes, message);

    return node;
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
    if (document is null) throw new ArgumentNullException(nameof(document));

    protection.Truth(!document.Nodes().Any(), message);

    return document;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection"></param>
  /// <param name="container"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static XContainer Empty(this IProtection protection, XContainer container, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (container is null) throw new ArgumentNullException(nameof(container));

    protection.Truth(!container.Nodes().Any(), message);

    return container;
  }
}