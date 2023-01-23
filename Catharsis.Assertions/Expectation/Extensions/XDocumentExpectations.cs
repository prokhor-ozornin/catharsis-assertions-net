using System.Xml.Linq;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class XDocumentExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<XDocument> Empty(this IExpectation<XDocument> expectation) => expectation.HaveSubject().And().Expect(document => !document.Nodes().Any());

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="name"></param>
  /// <returns></returns>
  public static IExpectation<XDocument> Name(this IExpectation<XDocument> expectation, XName name) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expect(document => document.Root?.Name == name);
}