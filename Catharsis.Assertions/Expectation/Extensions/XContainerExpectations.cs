using System.Xml.Linq;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for <see cref="XContainer"/> type.</para>
/// </summary>
/// <seealso cref="XContainer"/>
public static class XContainerExpectations
{
  /// <summary>
  ///   <para>Expects that a given <see cref="XContainer"/> contains a child element with a specified name.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="name">Expected expanded element name.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="name"/> is <see langword="null"/>.</exception>
  public static IExpectation<XContainer> Element(this IExpectation<XContainer> expectation, XName name) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expected(container => container.Elements(name).Any());

  /// <summary>
  ///   <para>Expects that a given <see cref="XContainer"/> is empty (contains no child nodes).</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<XContainer> Empty(this IExpectation<XContainer> expectation) => expectation.HaveSubject().And().Expected(container => !container.Nodes().Any());
}