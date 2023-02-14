using System.Xml.Linq;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="XAttribute"/>
public static class XAttributeAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="attribute"></param>
  /// <param name="name"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="attribute"/>, or <paramref name="name"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Name(this IAssertion assertion, XAttribute attribute, XName name, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (attribute is null) throw new ArgumentNullException(nameof(attribute));
    if (name is null) throw new ArgumentNullException(nameof(name));

    return assertion.True(attribute.Name == name, error);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="attribute"></param>
  /// <param name="value"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="attribute"/>, or <paramref name="value"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Value(this IAssertion assertion, XAttribute attribute, string value, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (attribute is null) throw new ArgumentNullException(nameof(attribute));
    if (value is null) throw new ArgumentNullException(nameof(value));

    return assertion.True(attribute.Value == value, error);
  }
}