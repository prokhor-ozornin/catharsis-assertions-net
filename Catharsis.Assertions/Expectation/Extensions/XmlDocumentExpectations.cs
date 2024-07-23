using System.Xml;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="XmlDocument"/> type.</para>
/// </summary>
/// <seealso cref="XmlDocument"/>
public static class XmlDocumentExpectations
{
  /// <summary>
  ///   <para>Expects that a given <see cref="XmlDocument"/> contains a child element with a specified name.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="name">Expected element name.</param>
  /// <param name="uri">Expected element namespace URI.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="name"/> is <see langword="null"/>.</exception>
  public static IExpectation<XmlDocument> Element(this IExpectation<XmlDocument> expectation, string name, string uri = null) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expected(document => (uri is not null ? document.GetElementsByTagName(name, uri) : document.GetElementsByTagName(name)).Count > 0);
}