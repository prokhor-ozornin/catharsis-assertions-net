using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DirectoryInfoAssertions.Empty(null, Attributes.Random().DirectoryName().ToDirectory())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => DirectoryInfoAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("directory");

      Attributes.Random().Directory().TryFinallyDelete(directory => Validate(true, directory));

      Attributes.Random().Directory().TryFinallyDelete(directory =>
      {
        Attributes.Random().File(directory);
        Validate(false, directory);
      });

      Attributes.Random().Directory().TryFinallyDelete(directory =>
      {
        Attributes.Random().Directory(directory);
        Validate(false, directory);
      });
    }

    return;

    static void Validate(bool result, DirectoryInfo directory)
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
      AssertionExtensions.Should(() => DirectoryInfoAssertions.InDirectory(null, Attributes.Random().DirectoryName().ToDirectory(), Attributes.Random().DirectoryName().ToDirectory())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => DirectoryInfoAssertions.InDirectory(Assert.To, null, Attributes.Random().DirectoryName().ToDirectory())).ThrowExactly<ArgumentNullException>().WithParameterName("directory");
      AssertionExtensions.Should(() => Assert.To.InDirectory(Attributes.Random().DirectoryName().ToDirectory(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("parent");

      Attributes.Random().Directory().TryFinallyDelete(directory =>
      {
        Validate(true, directory, directory.Parent);
        Validate(false, directory, directory);
      });
    }

    return;

    static void Validate(bool result, DirectoryInfo directory, DirectoryInfo parent)
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