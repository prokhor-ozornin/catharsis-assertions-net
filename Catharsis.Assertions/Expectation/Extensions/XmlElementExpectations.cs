using System.Xml;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="XmlElement"/> type.</para>
/// </summary>
/// <seealso cref="XmlElement"/>
public static class XmlElementExpectations
{
  /// <summary>
  ///   <para>Expects that a given <see cref="XmlElement"/> has an attribute with a specified name.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="name">Expected attribute name.</param>
  /// <param name="uri">Expected attribute namespace URI.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="name"/> is <see langword="null"/>.</exception>
  public static IExpectation<XmlElement> Attribute(this IExpectation<XmlElement> expectation, string name, string uri = null) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expected(element => uri is not null ? element.HasAttribute(name, uri) : element.HasAttribute(name));
}