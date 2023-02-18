namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="FileSystemInfo"/> type.</para>
/// </summary>
/// <seealso cref="FileSystemInfo"/>
public static class FileSystemInfoExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<FileSystemInfo> Exist(this IExpectation<FileSystemInfo> expectation) => expectation.HaveSubject().And().Expected(info => info.Exists);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="attribute"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<FileSystemInfo> Attribute(this IExpectation<FileSystemInfo> expectation, FileAttributes attribute) => expectation.HaveSubject().And().Expected(info => (info.Attributes & attribute) == attribute);
}