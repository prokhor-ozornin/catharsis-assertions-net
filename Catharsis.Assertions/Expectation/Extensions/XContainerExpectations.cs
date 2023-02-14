using System.Xml.Linq;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="XContainer"/>
public static class XContainerExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="name"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<XContainer> Element(this IExpectation<XContainer> expectation, XName name) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expected(container => container.Elements(name).Any());

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<XContainer> Empty(this IExpectation<XContainer> expectation) => expectation.HaveSubject().And().Expected(container => !container.Nodes().Any());
}