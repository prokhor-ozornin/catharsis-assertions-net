using System.Xml.Linq;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="XDocument"/> type.</para>
/// </summary>
/// <seealso cref="XDocument"/>
public static class XDocumentExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<XDocument> Empty(this IExpectation<XDocument> expectation) => expectation.HaveSubject().And().Expected(document => !document.Nodes().Any());

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="name"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<XDocument> Name(this IExpectation<XDocument> expectation, XName name) => expectation.HaveSubject().And().Expected(document => document.Root?.Name == name);
}