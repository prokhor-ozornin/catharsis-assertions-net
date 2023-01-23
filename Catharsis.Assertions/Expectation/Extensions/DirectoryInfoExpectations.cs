namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class DirectoryInfoExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<DirectoryInfo> Empty(this IExpectation<DirectoryInfo> expectation) => expectation.HaveSubject().And().Expect(directory => !directory.EnumerateFileSystemInfos().Any());

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="parent"></param>
  /// <returns></returns>
  public static IExpectation<DirectoryInfo> InDirectory(this IExpectation<DirectoryInfo> expectation, DirectoryInfo parent) => expectation.HaveSubject().And().ThrowIfNull(parent, nameof(parent)).And().Expect(directory => parent.EnumerateDirectories("*", new EnumerationOptions { RecurseSubdirectories = true }).Contains(directory));
}