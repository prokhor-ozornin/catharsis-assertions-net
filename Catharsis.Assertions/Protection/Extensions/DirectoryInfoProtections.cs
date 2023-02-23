namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of protections for <see cref="DirectoryInfo"/> type.</para>
/// </summary>
/// <seealso cref="DirectoryInfo"/>
public static class DirectoryInfoProtections
{
  /// <summary>
  ///   <para>Protects given directory from being empty (containing no files and/or subdirectories).</para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="directory">Directory to protect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="directory"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static DirectoryInfo Empty(this IProtection protection, DirectoryInfo directory, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (directory is null) throw new ArgumentNullException(nameof(directory));

    protection.Truth(!directory.EnumerateFileSystemInfos().Any(), error);

    return directory;
  }
}