namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="BinaryReader"/>
/// <seealso cref="BinaryWriter"/>
public static class BinaryProtections
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="reader"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static BinaryReader Empty(this IProtection protection, BinaryReader reader, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (reader is null) throw new ArgumentNullException(nameof(reader));

    protection.Truth(reader.BaseStream.Length == 0, error);
    
    return reader;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="writer"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static BinaryWriter Empty(this IProtection protection, BinaryWriter writer, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (writer is null) throw new ArgumentNullException(nameof(writer));

    protection.Truth(writer.BaseStream.Length == 0, error);

    return writer;
  }
}