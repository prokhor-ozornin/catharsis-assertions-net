using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="FileInfoProtections"/>.</para>
/// </summary>
public sealed class FileInfoProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoProtections.Empty(IProtection, FileInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => FileInfoProtections.Empty(null, Attributes.TempFile().File)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((FileInfo) null)).ThrowExactly<ArgumentNullException>().WithParameterName("file");

    Attributes.TempFile().File.TryFinallyDelete(file =>
    {
      Protect.From.Empty(file).Should().BeOfType<FileInfo>().And.BeSameAs(file);
      AssertionExtensions.Should(() => Protect.From.Empty(file.Empty(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    });
  }
}