namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of protections for <see cref="StreamWriter"/> type.</para>
/// </summary>
/// <seealso cref="StreamWriter"/>
public static class StreamWriterProtections
{
  /// <summary>
  ///   <para>This function protects the given <see cref="StreamWriter"/> from being empty, ensuring that it has a non-empty underlying <see cref="Stream"/>.</para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="writer">Stream writer to protect.</param>
  /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="writer"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static StreamWriter Empty(this IProtection protection, StreamWriter writer, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (writer is null) throw new ArgumentNullException(nameof(writer));

    protection.Truth(writer.BaseStream.Length == 0, error);

    return writer;
  }
}