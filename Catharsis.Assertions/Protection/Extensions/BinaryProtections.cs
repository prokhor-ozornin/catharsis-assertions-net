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
  /// <param name="protection"></param>
  /// <param name="reader"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static BinaryReader Empty(this IProtection protection, BinaryReader reader, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (reader is null) throw new ArgumentNullException(message);

    if (reader.BaseStream.Length == 0)
    {
      throw new ArgumentException(message);
    }

    return reader;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection"></param>
  /// <param name="writer"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static BinaryWriter Empty(this IProtection protection, BinaryWriter writer, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (writer is null) throw new ArgumentNullException(message);

    if (writer.BaseStream.Length == 0)
    {
      throw new ArgumentException(message);
    }

    return writer;
  }
}