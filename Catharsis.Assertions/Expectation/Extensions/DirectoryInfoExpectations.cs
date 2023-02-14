namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="DirectoryInfo"/>
public static class DirectoryInfoExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DirectoryInfo> Empty(this IExpectation<DirectoryInfo> expectation) => expectation.HaveSubject().And().Expected(directory => !directory.EnumerateFileSystemInfos().Any());

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="parent"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DirectoryInfo> InDirectory(this IExpectation<DirectoryInfo> expectation, DirectoryInfo parent) => expectation.HaveSubject().And().ThrowIfNull(parent, nameof(parent)).And().Expected(directory => parent.EnumerateDirectories("*", new EnumerationOptions { RecurseSubdirectories = true }).Select(directory => directory.FullName).Contains(directory.FullName));
}