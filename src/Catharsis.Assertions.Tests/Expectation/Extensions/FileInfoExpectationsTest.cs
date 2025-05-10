using AutoFixture;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="FileInfoExpectations"/>.</para>
/// </summary>
public sealed class FileInfoExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoExpectations.Length(IExpectation{FileInfo}, long)"/> method.</para>
  /// </summary>
  [Fact]
  public void Length_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FileInfoExpectations.Length(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((FileInfo) null).Expect().Length(0)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Random.File().TryFinallyDelete(file =>
      {
        Test(true, file, file.Length);
        Test(true, file.Empty(), 0);
        Test(false, file, int.MinValue);
      });
    }

    return;

    static void Test(bool result, FileInfo file, long length) => file.Expect().Length(length).Should().BeOfType<Expectation<FileInfo>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoExpectations.Empty(IExpectation{FileInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FileInfoExpectations.Empty(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((FileInfo) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Random.BinaryFile(short.MaxValue).TryFinallyDelete(file =>
      {
        Test(false, file);
        Test(true, file.Empty());
      });
    }

    return;

    static void Test(bool result, FileInfo file) => file.Expect().Empty().Should().BeOfType<Expectation<FileInfo>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoExpectations.ReadOnly(IExpectation{FileInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FileInfoExpectations.ReadOnly(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((FileInfo) null).Expect().ReadOnly()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Random.File().TryFinallyDelete(file =>
      {
        Test(false, file);
        Test(true, file.AsReadOnly());
      });
    }

    return;

    static void Test(bool result, FileInfo file) => file.Expect().ReadOnly().Should().BeOfType<Expectation<FileInfo>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoExpectations.InDirectory(IExpectation{FileInfo}, DirectoryInfo)"/> method.</para>
  /// </summary>
  [Fact]
  public void InDirectory_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FileInfoExpectations.InDirectory(null, Random.DirectoryName().ToDirectory())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((FileInfo) null).Expect().InDirectory(Random.DirectoryName().ToDirectory())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => Random.FileName().ToFile().Expect().InDirectory(null)).ThrowExactly<ArgumentNullException>().WithParameterName("directory");

      Random.File().TryFinallyDelete(file =>
      {
        Test(true, file, file.Directory);
        Test(false, file, Environment.SystemDirectory.ToDirectory());
      });
    }

    return;

    static void Test(bool result, FileInfo file, DirectoryInfo directory) => file.Expect().InDirectory(directory).Should().BeOfType<Expectation<FileInfo>>().Which.Result.Should().Be(result);
  }
}