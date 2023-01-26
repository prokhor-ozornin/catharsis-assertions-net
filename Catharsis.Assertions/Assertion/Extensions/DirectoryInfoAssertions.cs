namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="DirectoryInfo"/>
public static class DirectoryInfoAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="directory"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Empty(this IAssertion assertion, DirectoryInfo directory, string message = null) => directory is not null ? assertion.Empty(directory.EnumerateFileSystemInfos(), message) : throw new ArgumentNullException(nameof(directory));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="directory"></param>
  /// <param name="parent"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion InDirectory(this IAssertion assertion, DirectoryInfo directory, DirectoryInfo parent, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (directory is null) throw new ArgumentNullException(nameof(directory));
    if (parent is null) throw new ArgumentNullException(nameof(parent));

    return assertion.Contain(parent.EnumerateDirectories("*", new EnumerationOptions { RecurseSubdirectories = true }), directory, null, message);
  }
}