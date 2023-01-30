using FluentAssertions;
using Xunit;

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
    AssertionExtensions.Should(() => Protect.From.Empty((FileInfo) null, "error")).ThrowExactly<ArgumentNullException>().WithParameterName("error");
    
    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FilesystemProtections.Empty(IProtection, DirectoryInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_DirectoryInfo_Method()
  {
    AssertionExtensions.Should(() => FilesystemProtections.Empty(null, RandomDirectory)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((DirectoryInfo) null, "error")).ThrowExactly<ArgumentNullException>().WithParameterName("error");

    throw new NotImplementedException();
  }
}