using System.Xml;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class XmlElementExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="name"></param>
  /// <param name="uri"></param>
  /// <returns></returns>
  public static IExpectation<XmlElement> Attribute(this IExpectation<XmlElement> expectation, string name, string uri = null) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expect(element => element.HasAttribute(name, uri));
}