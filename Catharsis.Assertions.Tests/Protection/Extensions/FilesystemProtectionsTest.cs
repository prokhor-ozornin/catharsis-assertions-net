using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="FilesystemProtections"/>.</para>
/// </summary>
public sealed class FilesystemProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="FilesystemProtections.Empty(IProtection, FileInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_FileInfo_Method()
  {
    AssertionExtensions.Should(() => FilesystemProtections.Empty(null, RandomFile)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((FileInfo) null)).ThrowExactly<ArgumentNullException>().WithParameterName("file");

    RandomFile.TryFinallyDelete(file =>
    {
      Protect.From.Empty(file).Should().NotBeNull().And.BeSameAs(file);
      AssertionExtensions.Should(() => Protect.From.Empty(file.Empty(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FilesystemProtections.Empty(IProtection, DirectoryInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_DirectoryInfo_Method()
  {
    AssertionExtensions.Should(() => FilesystemProtections.Empty(null, RandomDirectory)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((DirectoryInfo) null)).ThrowExactly<ArgumentNullException>().WithParameterName("directory");

    RandomDirectory.TryFinallyDelete(directory =>
    {
      AssertionExtensions.Should(() => Protect.From.Empty(directory, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      directory.CreateSubdirectory(Randomizer.DirectoryName()).TryFinallyDelete(_ => Protect.From.Empty(directory).Should().NotBeNull().And.BeSameAs(directory));
      Randomizer.BinaryFile(0, null, null, directory).TryFinallyDelete(_ => Protect.From.Empty(directory).Should().NotBeNull().And.BeSameAs(directory));
    });
  }
}