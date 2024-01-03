using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DirectoryInfoAssertions"/>.</para>
/// </summary>
public sealed class DirectoryInfoAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryInfoAssertions.Empty(IAssertion, DirectoryInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => DirectoryInfoAssertions.Empty(null, Attributes.TempDirectory().Directory)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => DirectoryInfoAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("directory");

    Assert.To.Empty(Attributes.TempDirectory().Directory).Should().NotBeNull().And.BeSameAs(Assert.To);

    Attributes.TempDirectory().Directory.TryFinallyClear(directory =>
    {
      Attributes.Random().File(directory);
      AssertionExtensions.Should(() => Assert.To.Empty(directory, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    });

    Attributes.TempDirectory().Directory.TryFinallyClear(directory =>
    {
      Attributes.Random().Directory(directory);
      AssertionExtensions.Should(() => Assert.To.Empty(directory, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryInfoAssertions.InDirectory(IAssertion, DirectoryInfo, DirectoryInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void InDirectory_Method()
  {
    AssertionExtensions.Should(() => DirectoryInfoAssertions.InDirectory(null, Attributes.TempDirectory().Directory, Attributes.TempDirectory().Directory)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => DirectoryInfoAssertions.InDirectory(Assert.To, null, Attributes.TempDirectory().Directory)).ThrowExactly<ArgumentNullException>().WithParameterName("directory");
    AssertionExtensions.Should(() => Assert.To.InDirectory(Attributes.TempDirectory().Directory, null)).ThrowExactly<ArgumentNullException>().WithParameterName("parent");

    AssertionExtensions.Should(() => Assert.To.InDirectory(Attributes.TempDirectory().Directory, Attributes.TempDirectory().Directory, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.InDirectory(Attributes.TempDirectory().Directory, Attributes.TempDirectory().Directory.Parent).Should().NotBeNull().And.BeSameAs(Assert.To);
  }
}