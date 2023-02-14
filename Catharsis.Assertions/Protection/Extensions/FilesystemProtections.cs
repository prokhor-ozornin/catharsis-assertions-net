namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="FileInfo"/>
/// <seealso cref="DirectoryInfo"/>
public static class FilesystemProtections
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="file"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="Empty(IProtection, DirectoryInfo, string)"/>
  public static FileInfo Empty(this IProtection protection, FileInfo file, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (file is null) throw new ArgumentNullException(nameof(file));

    protection.Truth(file.Length == 0, error);

    return file;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="directory"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="Empty(IProtection, FileInfo, string)"/>
  public static DirectoryInfo Empty(this IProtection protection, DirectoryInfo directory, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (directory is null) throw new ArgumentNullException(nameof(directory));

    protection.Truth(!directory.EnumerateFileSystemInfos().Any(), error);

    return directory;
  }
}