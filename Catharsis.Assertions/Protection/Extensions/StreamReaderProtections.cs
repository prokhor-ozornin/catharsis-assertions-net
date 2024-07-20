namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of protections for <see cref="StreamReader"/> type.</para>
/// </summary>
/// <seealso cref="StreamReader"/>
public static class StreamReaderProtections
{
  /// <summary>
  ///   <para>Protects the given <see cref="StreamReader"/> from being empty, ensuring that it has a non-empty underlying <see cref="Stream"/>.</para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="reader">Stream reader to protect.</param>
  /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="reader"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static StreamReader Empty(this IProtection protection, StreamReader reader, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (reader is null) throw new ArgumentNullException(nameof(reader));

    protection.Truth(reader.BaseStream.Length == 0, error);

    return reader;
  }
}