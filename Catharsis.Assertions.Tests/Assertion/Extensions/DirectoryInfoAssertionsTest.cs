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
    AssertionExtensions.Should(() => DirectoryInfoAssertions.Empty(null, RandomDirectory)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => DirectoryInfoAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("directory");

    Assert.To.Empty(RandomDirectory).Should().NotBeNull().And.BeSameAs(Assert.To);

    RandomDirectory.TryFinallyClear(directory =>
    {
      Randomizer.BinaryFile(0, null, null, directory);
      AssertionExtensions.Should(() => Assert.To.Empty(directory, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    });

    RandomDirectory.TryFinallyClear(directory =>
    {
      Randomizer.Directory(directory);
      AssertionExtensions.Should(() => Assert.To.Empty(directory, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryInfoAssertions.InDirectory(IAssertion, DirectoryInfo, DirectoryInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void InDirectory_Method()
  {
    AssertionExtensions.Should(() => DirectoryInfoAssertions.InDirectory(null, RandomDirectory, RandomDirectory)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => DirectoryInfoAssertions.InDirectory(Assert.To, null, RandomDirectory)).ThrowExactly<ArgumentNullException>().WithParameterName("directory");
    AssertionExtensions.Should(() => Assert.To.InDirectory(RandomDirectory, null)).ThrowExactly<ArgumentNullException>().WithParameterName("parent");

    AssertionExtensions.Should(() => Assert.To.InDirectory(RandomDirectory, RandomDirectory, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.InDirectory(RandomDirectory, RandomDirectory.Parent).Should().NotBeNull().And.BeSameAs(Assert.To);
  }
}