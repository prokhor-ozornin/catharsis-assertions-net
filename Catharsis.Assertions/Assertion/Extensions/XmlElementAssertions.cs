using System.Xml;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="XmlElement"/> type.</para>
/// </summary>
/// <seealso cref="XmlElement"/>
public static class XmlElementAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="element"></param>
  /// <param name="name"></param>
  /// <param name="uri"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="element"/>, or <paramref name="name"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Attribute(this IAssertion assertion, XmlElement element, string name, string uri = null, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (element is null) throw new ArgumentNullException(nameof(element));
    if (name is null) throw new ArgumentNullException(nameof(name));

    return assertion.True(uri is not null ? element.HasAttribute(name, uri) : element.HasAttribute(name), error);
  }
}