using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="FileSystemInfoAssertions"/>.</para>
/// </summary>
public sealed class FileSystemInfoAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="FileSystemInfoAssertions.Exist(IAssertion, FileSystemInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Exist_Method()
  {
    AssertionExtensions.Should(() => FileSystemInfoAssertions.Exist(null, RandomFile)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Exist(null)).ThrowExactly<ArgumentNullException>().WithParameterName("info");

    Assert.To.Exist(RandomFile).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Exist(RandomFakeFile, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    Assert.To.Exist(RandomDirectory).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Exist(RandomFakeDirectory, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileSystemInfoAssertions.Attribute(IAssertion, FileSystemInfo, FileAttributes, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Attribute_Method()
  {
    AssertionExtensions.Should(() => FileSystemInfoAssertions.Attribute(null, RandomFile, FileAttributes.Normal)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Attribute(null, FileAttributes.Normal)).ThrowExactly<ArgumentNullException>().WithParameterName("info");

    RandomFile.With(file =>
    {
      Enum.GetValues<FileAttributes>().ForEach(attribute =>
      {
        if ((file.Attributes & attribute) == attribute)
        {
          Assert.To.Attribute(file, attribute).Should().NotBeNull().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Attribute(file, attribute, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
        }
      });

      Assert.To.Attribute(file.AsReadOnly(), FileAttributes.ReadOnly).Should().NotBeNull().And.BeSameAs(Assert.To);
    });
  }
}