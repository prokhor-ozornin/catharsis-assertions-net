namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="FileInfo"/> type.</para>
/// </summary>
/// <seealso cref="FileInfo"/>
public static class FileInfoAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="file"></param>
  /// <param name="length"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="file"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Length(this IAssertion assertion, FileInfo file, long length, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (file is null) throw new ArgumentNullException(nameof(file));

    if (assertion.Invalid(file.Length == length))
    {
      throw new ArgumentException(error);
    }

    return assertion;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="file"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="file"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Empty(this IAssertion assertion, FileInfo file, string error = null) => assertion.Length(file, 0, error);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="file"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="file"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ReadOnly(this IAssertion assertion, FileInfo file, string error = null) => file is not null ? assertion.True(file.IsReadOnly, error) : throw new ArgumentNullException(nameof(file));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="file"></param>
  /// <param name="directory"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="file"/>, or <paramref name="directory"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion InDirectory(this IAssertion assertion, FileInfo file, DirectoryInfo directory, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (file is null) throw new ArgumentNullException(nameof(file));
    if (directory is null) throw new ArgumentNullException(nameof(directory));

    return assertion.True(directory.EnumerateFiles("*", new EnumerationOptions { RecurseSubdirectories = true }).Any(directoryFile => directoryFile.Name == file.Name), error);
  }
}