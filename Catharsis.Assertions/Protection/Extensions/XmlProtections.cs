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
  /// <param name="protection">Protection to perform.</param>
  /// <param name="document"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="document"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  /// <seealso cref="Empty(IProtection, XmlNode, string)"/>
  /// <seealso cref="Empty(IProtection, XDocument, string)"/>
  /// <seealso cref="Empty(IProtection, XContainer, string)"/>
  public static XmlDocument Empty(this IProtection protection, XmlDocument document, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (document is null) throw new ArgumentNullException(nameof(document));

    protection.Truth(!document.HasChildNodes, error);

    return document;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="node"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="node"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  /// <seealso cref="Empty(IProtection, XmlDocument, string)"/>
  /// <seealso cref="Empty(IProtection, XDocument, string)"/>
  /// <seealso cref="Empty(IProtection, XContainer, string)"/>
  public static XmlNode Empty(this IProtection protection, XmlNode node, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (node is null) throw new ArgumentNullException(nameof(node));

    protection.Truth(!node.HasChildNodes, error);

    return node;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="document"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="document"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  /// <seealso cref="Empty(IProtection, XmlDocument, string)"/>
  /// <seealso cref="Empty(IProtection, XmlNode, string)"/>
  /// <seealso cref="Empty(IProtection, XContainer, string)"/>
  public static XDocument Empty(this IProtection protection, XDocument document, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (document is null) throw new ArgumentNullException(nameof(document));

    protection.Truth(!document.Nodes().Any(), error);

    return document;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="container"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="container"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  /// <seealso cref="Empty(IProtection, XmlDocument, string)"/>
  /// <seealso cref="Empty(IProtection, XmlNode, string)"/>
  /// <seealso cref="Empty(IProtection, XDocument, string)"/>
  public static XContainer Empty(this IProtection protection, XContainer container, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (container is null) throw new ArgumentNullException(nameof(container));

    protection.Truth(!container.Nodes().Any(), error);

    return container;
  }
}