namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class FileInfoExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="length"></param>
  /// <returns></returns>
  public static IExpectation<FileInfo> Length(this IExpectation<FileInfo> expectation, long length) => expectation.HaveSubject().And().Expect(file => file.Length == length);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<FileInfo> Empty(this IExpectation<FileInfo> expectation) => expectation.Length(0);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<FileInfo> ReadOnly(this IExpectation<FileInfo> expectation) => expectation.HaveSubject().And().Expect(file => file.IsReadOnly);

  /// <summary>
  ///    <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="directory"></param>
  /// <returns></returns>
  public static IExpectation<FileInfo> InDirectory(this IExpectation<FileInfo> expectation, DirectoryInfo directory) => expectation.HaveSubject().And().ThrowIfNull(directory, nameof(directory)).And().Expect(file => directory.EnumerateFiles("*", new EnumerationOptions { RecurseSubdirectories = true }).Contains(file));
}