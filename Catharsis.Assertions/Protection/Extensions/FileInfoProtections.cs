namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of protections for <see cref="FileInfo"/> type.</para>
/// </summary>
/// <seealso cref="FileInfo"/>
public static class FileInfoProtections
{
  /// <summary>
  ///   <para>This function protects the given <see cref="FileInfo"/> from being empty, ensuring that its size is not zero.</para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="file">File to protect.</param>
  /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="file"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static FileInfo Empty(this IProtection protection, FileInfo file, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (file is null) throw new ArgumentNullException(nameof(file));

    protection.Truth(file.Length == 0, error);

    return file;
  }
}