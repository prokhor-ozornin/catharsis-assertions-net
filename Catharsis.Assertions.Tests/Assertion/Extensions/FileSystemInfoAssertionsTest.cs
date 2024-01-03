using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="FileSystemInfoAssertions"/>.</para>
/// </summary>
public sealed class FileSystemInfoAssertionsTest : UnitTest
{
  private FileInfo RandomFakeFile { get; }
  private DirectoryInfo RandomFakeDirectory { get; }

  public FileSystemInfoAssertionsTest()
  {
    RandomFakeFile = Attributes.Random().FilePath().ToFile();
    RandomFakeDirectory = Attributes.Random().DirectoryPath().ToDirectory();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileSystemInfoAssertions.Exist(IAssertion, FileSystemInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Exist_Method()
  {
    AssertionExtensions.Should(() => FileSystemInfoAssertions.Exist(null, Attributes.TempFile().File)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Exist(null)).ThrowExactly<ArgumentNullException>().WithParameterName("info");

    Assert.To.Exist(Attributes.TempFile().File).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Exist(RandomFakeFile, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");

    Assert.To.Exist(Attributes.TempDirectory().Directory).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Exist(RandomFakeDirectory, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileSystemInfoAssertions.Attribute(IAssertion, FileSystemInfo, FileAttributes, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Attribute_Method()
  {
    AssertionExtensions.Should(() => FileSystemInfoAssertions.Attribute(null, Attributes.TempFile().File, FileAttributes.Normal)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Attribute(null, FileAttributes.Normal)).ThrowExactly<ArgumentNullException>().WithParameterName("info");

    Attributes.TempFile().File.With(file =>
    {
      Enum.GetValues<FileAttributes>().ForEach(attribute =>
      {
        if ((file.Attributes & attribute) == attribute)
        {
          Assert.To.Attribute(file, attribute).Should().NotBeNull().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Attribute(file, attribute, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      });

      Assert.To.Attribute(file.AsReadOnly(), FileAttributes.ReadOnly).Should().NotBeNull().And.BeSameAs(Assert.To);
    });
  }
}