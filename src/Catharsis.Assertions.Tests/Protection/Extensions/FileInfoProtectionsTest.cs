using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="FileInfoProtections"/>.</para>
/// </summary>
public sealed class FileInfoProtectionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoProtections.Empty(IProtection, FileInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FileInfoProtections.Empty(null, Random.FileName().ToFile())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.Empty((FileInfo) null)).ThrowExactly<ArgumentNullException>().WithParameterName("file");

      Random.BinaryFile(short.MaxValue).TryFinallyDelete(file =>
      {
        Test(true, file);
        Test(false, file.Empty());
      });
    }

    return;

    static void Test(bool result, FileInfo file)
    {
      if (result)
      {
        Protect.From.Empty(file).Should().BeOfType<FileInfo>().And.BeSameAs(file);
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Empty(file, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    }
  }
}