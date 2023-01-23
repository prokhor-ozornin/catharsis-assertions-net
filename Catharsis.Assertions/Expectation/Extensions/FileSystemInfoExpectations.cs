namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class FileSystemInfoExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<FileSystemInfo> Exist(this IExpectation<FileSystemInfo> expectation) => expectation.HaveSubject().And().Expect(info => info.Exists);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="attribute"></param>
  /// <returns></returns>
  public static IExpectation<FileSystemInfo> Attribute(this IExpectation<FileSystemInfo> expectation, FileAttributes attribute) => expectation.HaveSubject().And().Expect(info => (info.Attributes & attribute) == attribute);
}