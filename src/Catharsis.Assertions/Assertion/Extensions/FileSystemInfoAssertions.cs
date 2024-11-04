namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="FileSystemInfo"/> type.</para>
/// </summary>
/// <seealso cref="FileSystemInfo"/>
public static class FileSystemInfoAssertions
{
  /// <summary>
  ///   <para>Asserts that the given <see cref="FileSystemInfo"/> exists.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="info">Filesystem object to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="info"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Exist(this IAssertion assertion, FileSystemInfo info, string error = null) => info is not null ? assertion.True(info.Exists, error) : throw new ArgumentNullException(nameof(info));

  /// <summary>
  ///   <para>Asserts that the given <see cref="FileSystemInfo"/> has a specific attribute.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="info">Filesystem object to inspect.</param>
  /// <param name="attribute">Asserted attribute.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="info"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Attribute(this IAssertion assertion, FileSystemInfo info, FileAttributes attribute, string error = null) => info is not null ? assertion.True((info.Attributes & attribute) == attribute, error) : throw new ArgumentNullException(nameof(info));
}