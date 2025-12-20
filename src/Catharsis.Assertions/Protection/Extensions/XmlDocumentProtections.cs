using System.Xml;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of protections for the <see cref="XmlDocument"/> type.</para>
/// </summary>
/// <seealso cref="XmlDocument"/>
public static class XmlDocumentProtections
{
  /// <param name="protection">Protection to perform.</param>
  extension(IProtection protection)
  {
    /// <summary>
    ///   <para>This function protects the given <see cref="XmlDocument"/> from being empty, ensuring that it contains at least one child node.</para>
    /// </summary>
    /// <param name="document">XML document to protect.</param>
    /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="document"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
    public XmlDocument Empty(XmlDocument document, string error = null)
    {
      if (protection is null) throw new ArgumentNullException(nameof(protection));
      if (document is null) throw new ArgumentNullException(nameof(document));

      protection.Truth(!document.HasChildNodes, error);

      return document;
    }
  }
}