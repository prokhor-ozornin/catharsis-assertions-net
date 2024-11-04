namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="FileSystemInfo"/> type.</para>
/// </summary>
/// <seealso cref="FileSystemInfo"/>
public static class FileSystemInfoExpectations
{
  /// <summary>
  ///   <para>Expects that the given <see cref="FileSystemInfo"/> exists.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<FileSystemInfo> Exist(this IExpectation<FileSystemInfo> expectation) => expectation.HaveSubject().And().Expected(info => info.Exists);

  /// <summary>
  ///   <para>Expects that the given <see cref="FileSystemInfo"/> has a specific attribute.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="attribute">Expected attribute.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<FileSystemInfo> Attribute(this IExpectation<FileSystemInfo> expectation, FileAttributes attribute) => expectation.HaveSubject().And().Expected(info => (info.Attributes & attribute) == attribute);
}