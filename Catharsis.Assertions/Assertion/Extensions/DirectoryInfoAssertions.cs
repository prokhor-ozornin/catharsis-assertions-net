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
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="directory"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="directory"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Empty(this IAssertion assertion, DirectoryInfo directory, string error = null) => directory is not null ? assertion.Empty(directory.EnumerateFileSystemInfos(), error) : throw new ArgumentNullException(nameof(directory));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="directory"></param>
  /// <param name="parent"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="directory"/>, or <paramref name="parent"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion InDirectory(this IAssertion assertion, DirectoryInfo directory, DirectoryInfo parent, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (directory is null) throw new ArgumentNullException(nameof(directory));
    if (parent is null) throw new ArgumentNullException(nameof(parent));

    return assertion.Contain(parent.EnumerateDirectories("*", new EnumerationOptions { RecurseSubdirectories = true }).Select(directory => directory.FullName), directory.FullName, null, error);
  }
}