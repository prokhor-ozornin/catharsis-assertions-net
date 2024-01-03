using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="FileSystemInfoExpectations"/>.</para>
/// </summary>
public sealed class FileSystemInfoExpectationsTest : UnitTest
{
  private FileInfo RandomFakeFile { get; }
  private DirectoryInfo RandomFakeDirectory { get; }

  public FileSystemInfoExpectationsTest()
  {
    RandomFakeFile = Attributes.Random().FilePath().ToFile();
    RandomFakeDirectory = Attributes.Random().DirectoryPath().ToDirectory();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileSystemInfoExpectations.Exist(IExpectation{FileSystemInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Exist_Method()
  {
    AssertionExtensions.Should(() => FileSystemInfoExpectations.Exist(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((FileInfo) null).Expect().Exist()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Assert.To.Exist(Attributes.TempFile().File).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Exist(RandomFakeFile, "error")).ThrowExactly<InvalidOperationException>("error");

    Assert.To.Exist(Attributes.TempDirectory().Directory).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Exist(RandomFakeDirectory, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileSystemInfoExpectations.Attribute(IExpectation{FileSystemInfo}, FileAttributes)"/> method.</para>
  /// </summary>
  [Fact]
  public void Attribute_Method()
  {
    AssertionExtensions.Should(() => FileSystemInfoExpectations.Attribute(null, FileAttributes.Normal)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((FileInfo) null).Expect().Attribute(FileAttributes.Normal)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Attributes.TempFile().File.With(file =>
    {
      Enum.GetValues<FileAttributes>().ForEach(attribute => file.Expect().Attribute(attribute).Result.Should().Be((file.Attributes & attribute) == attribute));
      file.AsReadOnly().Expect().Attribute(FileAttributes.ReadOnly).Result.Should().BeTrue();
    });
  }
}