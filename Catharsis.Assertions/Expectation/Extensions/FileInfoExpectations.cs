﻿namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="FileInfo"/>
public static class FileInfoExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="length"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<FileInfo> Length(this IExpectation<FileInfo> expectation, long length) => expectation.HaveSubject().And().Expected(file => file.Length == length);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<FileInfo> Empty(this IExpectation<FileInfo> expectation) => expectation.Length(0);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<FileInfo> ReadOnly(this IExpectation<FileInfo> expectation) => expectation.HaveSubject().And().Expected(file => file.IsReadOnly);

  /// <summary>
  ///    <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="directory"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<FileInfo> InDirectory(this IExpectation<FileInfo> expectation, DirectoryInfo directory) => expectation.HaveSubject().And().ThrowIfNull(directory, nameof(directory)).And().Expected(file => directory.EnumerateFiles("*", new EnumerationOptions { RecurseSubdirectories = true }).Any(directoryFile => directoryFile.Name == file.Name));
}