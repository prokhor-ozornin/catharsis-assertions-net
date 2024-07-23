using System.Xml.Linq;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="XElement"/> type.</para>
/// </summary>
/// <seealso cref="XElement"/>
public static class XElementAssertions
{
  /// <summary>
  ///   <para>Asserts that the given <see cref="XElement"/> has an attribute with specified name and value.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="element">Element to inspect.</param>
  /// <param name="name">Asserted expanded attribute name.</param>
  /// <param name="value">Asserted attribute value or <see langword="null"/> to skip value check.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="element"/>, or <paramref name="name"/> is <see langword="null"/>.</exception>
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