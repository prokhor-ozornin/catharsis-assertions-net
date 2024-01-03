using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DirectoryInfoProtections"/>.</para>
/// </summary>
public sealed class DirectoryInfoProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryInfoProtections.Empty(IProtection, DirectoryInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => DirectoryInfoProtections.Empty(null, Attributes.TempDirectory().Directory)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((DirectoryInfo) null)).ThrowExactly<ArgumentNullException>().WithParameterName("directory");

    Attributes.TempDirectory().Directory.TryFinallyDelete(directory =>
    {
      AssertionExtensions.Should(() => Protect.From.Empty(directory, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      directory.CreateSubdirectory(Attributes.Random().DirectoryName()).TryFinallyDelete(_ => Protect.From.Empty(directory).Should().NotBeNull().And.BeSameAs(directory));
      Attributes.Random().BinaryFile(0, null, null, directory).TryFinallyDelete(_ => Protect.From.Empty(directory).Should().NotBeNull().And.BeSameAs(directory));
    });
  }
}