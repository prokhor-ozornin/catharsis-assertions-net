using System.Xml.Linq;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class XContainerAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="container"></param>
  /// <param name="name"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Element(this IAssertion assertion, XContainer container, XName name, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (container is null) throw new ArgumentNullException(nameof(container));
    if (name is null) throw new ArgumentNullException(nameof(name));

    return assertion.True(container.Elements(name).Any(), message);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="container"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Empty(this IAssertion assertion, XContainer container, string message = null) => container is not null ? assertion.Empty(container.Nodes(), message) : throw new ArgumentNullException(nameof(container));
}