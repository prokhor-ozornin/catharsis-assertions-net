namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class FileInfoAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="file"></param>
  /// <param name="length"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Length(this IAssertion assertion, FileInfo file, long length, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (file is null) throw new ArgumentNullException(nameof(file));

    if (assertion.Unconfirmed(file.Length == length))
    {
      throw new ArgumentException(message);
    }

    return assertion;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="file"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Empty(this IAssertion assertion, FileInfo file, string message = null) => assertion.Length(file, 0, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="file"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion ReadOnly(this IAssertion assertion, FileInfo file, string message = null) => file is not null ? assertion.True(file.IsReadOnly, message) : throw new ArgumentNullException(nameof(file));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="file"></param>
  /// <param name="directory"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion InDirectory(this IAssertion assertion, FileInfo file, DirectoryInfo directory, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (file is null) throw new ArgumentNullException(nameof(file));
    if (directory is null) throw new ArgumentNullException(nameof(directory));

    return assertion.Contain(directory.EnumerateFiles("*", new EnumerationOptions { RecurseSubdirectories = true }), file, null, message);
  }
}