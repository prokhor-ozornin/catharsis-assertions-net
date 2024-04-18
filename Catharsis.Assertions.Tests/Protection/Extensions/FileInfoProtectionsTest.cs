using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FileInfoProtections.Empty(null, Attributes.TempFile().File)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.Empty((FileInfo) null)).ThrowExactly<ArgumentNullException>().WithParameterName("file");

      Validate(true, Attributes.TempFile());
      Validate(false, Attributes.TempFile());
    }

    return;

    static void Validate(bool result, TempFile file)
    {
      using (file)
      {
        if (result)
        {
          Protect.From.Empty(file.File).Should().BeOfType<FileInfo>().And.BeSameAs(file);
        }
        else
        {
          AssertionExtensions.Should(() => Protect.From.Empty(file.File.Empty(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
        }
      }
    }
  }
}