namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of protections for <see cref="StreamReader"/> type.</para>
/// </summary>
/// <seealso cref="StreamReader"/>
public static class StreamReaderProtections
{
  /// <summary>
  ///   <para>Protects given stream reader from having an empty underlying stream.</para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="reader">Stream reader to protect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="reader"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static StreamReader Empty(this IProtection protection, StreamReader reader, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (reader is null) throw new ArgumentNullException(nameof(reader));

    protection.Truth(reader.BaseStream.Length == 0, error);

    return reader;
  }
}