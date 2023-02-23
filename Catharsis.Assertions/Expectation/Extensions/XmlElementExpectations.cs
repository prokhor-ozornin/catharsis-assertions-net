using System.Xml;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="XmlElement"/> type.</para>
/// </summary>
/// <seealso cref="XmlElement"/>
public static class XmlElementExpectations
{
  /// <summary>
  ///   <para>Expects that a given XML element has an attribute with a specified name.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="name">Expected attribute name.</param>
  /// <param name="uri">Expected attribute namespace URI.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="name"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<XmlElement> Attribute(this IExpectation<XmlElement> expectation, string name, string uri = null) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expected(element => uri is not null ? element.HasAttribute(name, uri) : element.HasAttribute(name));
}