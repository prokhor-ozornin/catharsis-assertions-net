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
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DirectoryInfo> Empty(this IExpectation<DirectoryInfo> expectation) => expectation.HaveSubject().And().Expected(directory => !directory.EnumerateFileSystemInfos().Any());

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="parent"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DirectoryInfo> InDirectory(this IExpectation<DirectoryInfo> expectation, DirectoryInfo parent) => expectation.HaveSubject().And().ThrowIfNull(parent, nameof(parent)).And().Expected(directory => parent.EnumerateDirectories("*", new EnumerationOptions { RecurseSubdirectories = true }).Contains(directory));
}