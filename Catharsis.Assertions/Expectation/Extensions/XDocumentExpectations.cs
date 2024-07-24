using System.Xml.Linq;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="XDocument"/> type.</para>
/// </summary>
/// <seealso cref="XDocument"/>
public static class XDocumentExpectations
{
  /// <summary>
  ///   <para>Expects that the given <see cref="XDocument"/> is empty, meaning it contains no child nodes.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<XDocument> Empty(this IExpectation<XDocument> expectation) => expectation.HaveSubject().And().Expected(document => !document.Nodes().Any());

  /// <summary>
  ///   <para>Expects that the given <see cref="XDocument"/> has a root element with the specified name.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="name">Expected element name.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<XDocument> Name(this IExpectation<XDocument> expectation, XName name) => expectation.HaveSubject().And().Expected(document => document.Root?.Name == name);
}