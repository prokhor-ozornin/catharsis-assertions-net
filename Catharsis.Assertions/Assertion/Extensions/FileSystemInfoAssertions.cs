namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class FileSystemInfoAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="info"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Exist(this IAssertion assertion, FileSystemInfo info, string message = null) => info is not null ? assertion.True(info.Exists, message) : throw new ArgumentNullException(nameof(info));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="info"></param>
  /// <param name="attribute"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Attribute(this IAssertion assertion, FileSystemInfo info, FileAttributes attribute, string message = null) => info is not null ? assertion.True((info.Attributes & attribute) == attribute, message) : throw new ArgumentNullException(nameof(info));
}