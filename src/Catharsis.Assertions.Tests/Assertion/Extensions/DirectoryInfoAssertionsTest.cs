using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DirectoryInfoAssertions"/>.</para>
/// </summary>
/// <seealso cref="DirectoryInfoAssertions"/>
public sealed class DirectoryInfoAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryInfoAssertions.Empty(IAssertion, DirectoryInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DirectoryInfoAssertions.Empty(null, Random.DirectoryName().ToDirectory())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => DirectoryInfoAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("directory");

      Random.Directory().TryFinallyDelete(directory => Test(true, directory));

      Random.Directory().TryFinallyDelete(directory =>
      {
        Random.File(directory);
        Test(false, directory);
      });

      Random.Directory().TryFinallyDelete(directory =>
      {
        Random.Directory(directory);
        Test(false, directory);
      });
    }

    return;

    static void Test(bool result, DirectoryInfo directory)
    {
      if (result)
      {
        Assert.To.Empty(directory).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Empty(directory, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryInfoAssertions.InDirectory(IAssertion, DirectoryInfo, DirectoryInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void InDirectory_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DirectoryInfoAssertions.InDirectory(null, Random.DirectoryName().ToDirectory(), Random.DirectoryName().ToDirectory())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => DirectoryInfoAssertions.InDirectory(Assert.To, null, Random.DirectoryName().ToDirectory())).ThrowExactly<ArgumentNullException>().WithParameterName("directory");
      AssertionExtensions.Should(() => Assert.To.InDirectory(Random.DirectoryName().ToDirectory(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("parent");

      Random.Directory().TryFinallyDelete(directory =>
      {
        Test(true, directory, directory.Parent);
        Test(false, directory, directory);
      });
    }

    return;

    static void Test(bool result, DirectoryInfo directory, DirectoryInfo parent)
    {
      if (result)
      {
        Assert.To.InDirectory(directory, parent).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.InDirectory(directory, parent, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}