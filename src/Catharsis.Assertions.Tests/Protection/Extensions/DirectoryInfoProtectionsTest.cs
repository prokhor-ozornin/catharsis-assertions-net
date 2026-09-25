using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DirectoryInfoProtections"/>.</para>
/// </summary>
/// <seealso cref="DirectoryInfoProtections"/>
public sealed class DirectoryInfoProtectionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryInfoProtections.Empty(IProtection, DirectoryInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DirectoryInfoProtections.Empty(null, Random.ToDirectoryName().ToDirectory())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.Empty((DirectoryInfo) null)).ThrowExactly<ArgumentNullException>().WithParameterName("directory");

      Random.ToDirectory().TryFinallyDelete(directory =>
      {
        Random.ToFile(directory);
        Test(true, directory);
      });

      Random.ToDirectory().TryFinallyDelete(directory =>
      {
        Random.ToDirectory(directory);
        Test(true, directory);
      });

      Random.ToDirectory().TryFinallyDelete(directory => Test(false, directory));
    }

    return;

    static void Test(bool result, DirectoryInfo directory)
    {
      if (result)
      {
        Protect.From.Empty(directory).Should().BeOfType<DirectoryInfo>().And.BeSameAs(directory);
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Empty(directory, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    }
  }
}