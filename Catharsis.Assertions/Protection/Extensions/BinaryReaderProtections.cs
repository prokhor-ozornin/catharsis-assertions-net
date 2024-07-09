namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of protections for <see cref="BinaryReader"/> type.</para>
/// </summary>
/// <seealso cref="BinaryReader"/>
public static class BinaryReaderProtections
{
  /// <summary>
  ///   <para>Protects given binary reader from having an empty underlying stream.</para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="reader">Binary reader to protect.</param>
  /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="reader"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static BinaryReader Empty(this IProtection protection, BinaryReader reader, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (reader is null) throw new ArgumentNullException(nameof(reader));

    protection.Truth(reader.BaseStream.Length == 0, error ?? nameof(reader));
    
    return reader;
  }
}