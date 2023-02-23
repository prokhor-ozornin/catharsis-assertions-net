﻿namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of protections for <see cref="BinaryWriter"/> type.</para>
/// </summary>
/// <seealso cref="BinaryWriter"/>
public static class BinaryWriterProtections
{
  /// <summary>
  ///   <para>Protects given binary writer from having an empty underlying stream.</para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="writer">Binary writer to protect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="writer"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static BinaryWriter Empty(this IProtection protection, BinaryWriter writer, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (writer is null) throw new ArgumentNullException(nameof(writer));

    protection.Truth(writer.BaseStream.Length == 0, error ?? nameof(writer));

    return writer;
  }
}