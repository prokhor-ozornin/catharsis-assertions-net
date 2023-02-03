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
  /// <param name="protection"></param>
  /// <param name="file"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static FileInfo Empty(this IProtection protection, FileInfo file, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (file is null) throw new ArgumentNullException(nameof(file));

    protection.Truth(file.Length == 0, message);

    return file;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection"></param>
  /// <param name="directory"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static DirectoryInfo Empty(this IProtection protection, DirectoryInfo directory, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (directory is null) throw new ArgumentNullException(nameof(directory));

    protection.Truth(!directory.EnumerateFileSystemInfos().Any(), message);

    return directory;
  }
}