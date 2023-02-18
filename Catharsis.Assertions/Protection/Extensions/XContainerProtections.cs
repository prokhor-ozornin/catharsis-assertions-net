using System.Xml.Linq;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of protections for <see cref="XContainer"/> type.</para>
/// </summary>
/// <seealso cref="XContainer"/>
public static class XContainerProtections
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="container"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="container"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static XContainer Empty(this IProtection protection, XContainer container, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (container is null) throw new ArgumentNullException(nameof(container));

    protection.Truth(!container.Nodes().Any(), error);

    return container;
  }
}