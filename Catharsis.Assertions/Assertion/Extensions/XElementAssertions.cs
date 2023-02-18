using System.Xml.Linq;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="XElement"/> type.</para>
/// </summary>
/// <seealso cref="XElement"/>
public static class XElementAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="element"></param>
  /// <param name="name"></param>
  /// <param name="value"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="element"/>, or <paramref name="name"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Attribute(this IAssertion assertion, XElement element, XName name, string value = null, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (element is null) throw new ArgumentNullException(nameof(element));
    if (name is null) throw new ArgumentNullException(nameof(name));
    
    var attributes = element.Attributes(name);
    var result = value is not null ? attributes.Any(attribute => attribute.Name == name && attribute.Value == value) : attributes.Any(attribute => attribute.Name == name);

    return assertion.True(result, error);
  }
}