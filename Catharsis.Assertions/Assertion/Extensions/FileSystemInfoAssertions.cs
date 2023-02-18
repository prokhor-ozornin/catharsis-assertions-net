namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="FileSystemInfo"/> type.</para>
/// </summary>
/// <seealso cref="FileSystemInfo"/>
public static class FileSystemInfoAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="info"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="info"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Exist(this IAssertion assertion, FileSystemInfo info, string error = null) => info is not null ? assertion.True(info.Exists, error) : throw new ArgumentNullException(nameof(info));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="info"></param>
  /// <param name="attribute"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="info"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Attribute(this IAssertion assertion, FileSystemInfo info, FileAttributes attribute, string error = null) => info is not null ? assertion.True((info.Attributes & attribute) == attribute, error) : throw new ArgumentNullException(nameof(info));
}