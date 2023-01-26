using System.Xml;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="XmlDocument"/>
public static class XmlDocumentExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="name"></param>
  /// <param name="uri"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<XmlDocument> Element(this IExpectation<XmlDocument> expectation, string name, string uri = null) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expected(document => (uri is not null ? document.GetElementsByTagName(name, uri) : document.GetElementsByTagName(name)).Count > 0);
}