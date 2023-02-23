﻿using System.Xml.Linq;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="XAttribute"/> type.</para>
/// </summary>
/// <seealso cref="XAttribute"/>
public static class XAttributeAssertions
{
  /// <summary>
  ///   <para>Asserts that a given XML attribute has a specified name.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="attribute">Attribute to inspect.</param>
  /// <param name="name">Asserted expanded attribute name.</param>
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
  ///   <para>Asserts that a given XML attribute has a specified value.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="attribute">Attribute to inspect.</param>
  /// <param name="value">Asserted attribute value.</param>
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