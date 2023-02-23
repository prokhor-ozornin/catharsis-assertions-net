using System.Text;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of protections for <see cref="StringBuilder"/> type.</para>
/// </summary>
/// <seealso cref="StringBuilder"/>
public static class StringBuilderProtections
{
  /// <summary>
  ///   <para>Protects given string builder from being empty (containing no characters).</para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="builder">String builder to protect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="builder"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static StringBuilder Empty(this IProtection protection, StringBuilder builder, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (builder is null) throw new ArgumentNullException(nameof(builder));

    protection.Truth(builder.Length == 0, error);

    return builder;
  }
}