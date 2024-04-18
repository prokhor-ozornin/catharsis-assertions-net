using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DirectoryInfoProtections.Empty(null, Attributes.TempDirectory().Directory)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.Empty((DirectoryInfo) null)).ThrowExactly<ArgumentNullException>().WithParameterName("directory");

      Validate(true, Attributes.TempDirectory().With(directory => directory.Directory.CreateSubdirectory(Attributes.Random().DirectoryName())));
      Validate(false, Attributes.TempDirectory());
    }

    return;

    static void Validate(bool result, TempDirectory directory)
    {
      using (directory)
      {
        if (result)
        {
          Protect.From.Empty(directory.Directory).Should().BeOfType<DirectoryInfo>().And.BeSameAs(directory);
        }
        else
        {
          AssertionExtensions.Should(() => Protect.From.Empty(directory.Directory, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
        }
      }
    }
  }
}