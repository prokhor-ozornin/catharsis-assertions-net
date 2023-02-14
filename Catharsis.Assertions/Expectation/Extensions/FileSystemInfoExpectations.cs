namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="FileSystemInfo"/>
public static class FileSystemInfoExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<FileSystemInfo> Exist(this IExpectation<FileSystemInfo> expectation) => expectation.HaveSubject().And().Expected(info => info.Exists);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="attribute"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<FileSystemInfo> Attribute(this IExpectation<FileSystemInfo> expectation, FileAttributes attribute) => expectation.HaveSubject().And().Expected(info => (info.Attributes & attribute) == attribute);
}