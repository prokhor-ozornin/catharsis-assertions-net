using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="FileInfoExpectations"/>.</para>
/// </summary>
public sealed class FileInfoExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoExpectations.Length(IExpectation{FileInfo}, long)"/> method.</para>
  /// </summary>
  [Fact]
  public void Length_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FileInfoExpectations.Length(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((FileInfo) null).Expect().Length(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Attributes.Random().File().TryFinallyDelete(file =>
      {
        Validate(true, file, file.Length);
        Validate(true, file.Empty(), 0);
        Validate(false, file, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, FileInfo file, long length) => file.Expect().Length(length).Should().BeOfType<Expectation<FileInfo>>().Which.Result.Should().Be(result);
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

      Attributes.Random().BinaryFile(short.MaxValue).TryFinallyDelete(file =>
      {
        Validate(false, file);
        Validate(true, file.Empty());
      });
    }

    return;

    static void Validate(bool result, FileInfo file) => file.Expect().Empty().Should().BeOfType<Expectation<FileInfo>>().Which.Result.Should().Be(result);
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

      Attributes.Random().File().TryFinallyDelete(file =>
      {
        Validate(false, file);
        Validate(true, file.AsReadOnly());
      });
    }

    return;

    static void Validate(bool result, FileInfo file) => file.Expect().ReadOnly().Should().BeOfType<Expectation<FileInfo>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoExpectations.InDirectory(IExpectation{FileInfo}, DirectoryInfo)"/> method.</para>
  /// </summary>
  [Fact]
  public void InDirectory_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FileInfoExpectations.InDirectory(null, Attributes.Random().DirectoryName().ToDirectory())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((FileInfo) null).Expect().InDirectory(Attributes.Random().DirectoryName().ToDirectory())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => Attributes.Random().FileName().ToFile().Expect().InDirectory(null)).ThrowExactly<ArgumentNullException>().WithParameterName("directory");

      Attributes.Random().File().TryFinallyDelete(file =>
      {
        Validate(true, file, file.Directory);
        Validate(false, file, Environment.SystemDirectory.ToDirectory());
      });
    }

    return;

    static void Validate(bool result, FileInfo file, DirectoryInfo directory) => file.Expect().InDirectory(directory).Should().BeOfType<Expectation<FileInfo>>().Which.Result.Should().Be(result);
  }
}