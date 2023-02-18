using System.Xml.Linq;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="XContainer"/> type.</para>
/// </summary>
/// <seealso cref="XContainer"/>
public static class XContainerAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="container"></param>
  /// <param name="name"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="container"/>, or <paramref name="name"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Element(this IAssertion assertion, XContainer container, XName name, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (container is null) throw new ArgumentNullException(nameof(container));
    if (name is null) throw new ArgumentNullException(nameof(name));

    return assertion.True(container.Elements(name).Any(), error);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="container"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="container"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Empty(this IAssertion assertion, XContainer container, string error = null) => container is not null ? assertion.Empty(container.Nodes(), error) : throw new ArgumentNullException(nameof(container));
}