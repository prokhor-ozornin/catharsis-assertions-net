namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of protections for <see cref="StreamWriter"/> type.</para>
/// </summary>
/// <seealso cref="StreamWriter"/>
public static class StreamWriterProtections
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="writer"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="writer"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static StreamWriter Empty(this IProtection protection, StreamWriter writer, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (writer is null) throw new ArgumentNullException(nameof(writer));

    protection.Truth(writer.BaseStream.Length == 0, error);

    return writer;
  }
}