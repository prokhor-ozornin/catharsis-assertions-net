using System.Xml;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of protections for <see cref="XmlNode"/> type.</para>
/// </summary>
/// <seealso cref="XmlNode"/>
public static class XmlNodeProtections
{
  /// <summary>
  ///   <para>Protects the given <see cref="XmlNode"/> from being empty, ensuring that it contains at least one child node.</para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="node">XML node to protect.</param>
  /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="node"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static XmlNode Empty(this IProtection protection, XmlNode node, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (node is null) throw new ArgumentNullException(nameof(node));

    protection.Truth(!node.HasChildNodes, error);

    return node;
  }
}