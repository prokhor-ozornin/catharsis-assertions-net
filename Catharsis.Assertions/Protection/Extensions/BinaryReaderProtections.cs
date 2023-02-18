namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of protections for <see cref="BinaryReader"/> type.</para>
/// </summary>
/// <seealso cref="BinaryReader"/>
public static class BinaryReaderProtections
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="reader"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="reader"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static BinaryReader Empty(this IProtection protection, BinaryReader reader, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (reader is null) throw new ArgumentNullException(nameof(reader));

    protection.Truth(reader.BaseStream.Length == 0, error ?? nameof(reader));
    
    return reader;
  }
}