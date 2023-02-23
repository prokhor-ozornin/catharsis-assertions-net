using System.Xml;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of protections for <see cref="XmlNode"/> type.</para>
/// </summary>
/// <seealso cref="XmlNode"/>
public static class XmlNodeProtections
{
  /// <summary>
  ///   <para>Protects given XML node from being empty (containing no child nodes).</para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="node">Node to protect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="node"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static XmlNode Empty(this IProtection protection, XmlNode node, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (node is null) throw new ArgumentNullException(nameof(node));

    protection.Truth(!node.HasChildNodes, error);

    return node;
  }
}