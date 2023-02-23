using System.Xml;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of protections for <see cref="XmlDocument"/> type.</para>
/// </summary>
/// <seealso cref="XmlDocument"/>
public static class XmlDocumentProtections
{
  /// <summary>
  ///   <para>Protects given XML document from being empty (containing no child nodes).</para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="document">Document to protect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="document"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static XmlDocument Empty(this IProtection protection, XmlDocument document, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (document is null) throw new ArgumentNullException(nameof(document));

    protection.Truth(!document.HasChildNodes, error);

    return document;
  }
}