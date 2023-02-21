namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="DirectoryInfo"/> type.</para>
/// </summary>
/// <seealso cref="DirectoryInfo"/>
public static class DirectoryInfoExpectations
{
  /// <summary>
  ///   <para>Expects that a given directory is empty (contains no files and/or subdirectories).</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<DirectoryInfo> Empty(this IExpectation<DirectoryInfo> expectation) => expectation.HaveSubject().And().Expected(directory => !directory.EnumerateFileSystemInfos().Any());

  /// <summary>
  ///   <para>Expects that a given directory is located in a specified parent directory.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="parent">Parent directory.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="parent"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<DirectoryInfo> InDirectory(this IExpectation<DirectoryInfo> expectation, DirectoryInfo parent) => expectation.HaveSubject().And().ThrowIfNull(parent, nameof(parent)).And().Expected(directory => parent.EnumerateDirectories("*", new EnumerationOptions { RecurseSubdirectories = true }).Select(directory => directory.FullName).Contains(directory.FullName));
}