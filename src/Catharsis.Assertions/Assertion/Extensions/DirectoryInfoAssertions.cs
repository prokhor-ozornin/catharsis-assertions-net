namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="DirectoryInfo"/> type.</para>
/// </summary>
/// <seealso cref="DirectoryInfo"/>
public static class DirectoryInfoAssertions
{
  /// <summary>
  ///   <para>Asserts that the given <see cref="DirectoryInfo"/> is empty, meaning it contains no files or subdirectories.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="directory">Directory to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="directory"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Empty(this IAssertion assertion, DirectoryInfo directory, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (directory is null) throw new ArgumentNullException(nameof(directory));

    return assertion.Empty(directory.EnumerateFileSystemInfos(), error);
  }

  /// <summary>
  ///   <para>Asserts that the given <see cref="DirectoryInfo"/> is a subdirectory of a specified parent directory.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="directory">Directory to inspect.</param>
  /// <param name="parent">Asserted parent directory.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="directory"/>, or <paramref name="parent"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion InDirectory(this IAssertion assertion, DirectoryInfo directory, DirectoryInfo parent, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (directory is null) throw new ArgumentNullException(nameof(directory));
    if (parent is null) throw new ArgumentNullException(nameof(parent));

    return assertion.Contain(parent.EnumerateDirectories("*", new EnumerationOptions { RecurseSubdirectories = true }).Select(directory => directory.FullName), directory.FullName, null, error);
  }
}