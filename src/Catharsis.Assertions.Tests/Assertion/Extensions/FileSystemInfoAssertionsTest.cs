using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="FileSystemInfoAssertions"/>.</para>
/// </summary>
public sealed class FileSystemInfoAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="FileSystemInfoAssertions.Exist(IAssertion, FileSystemInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Exist_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FileSystemInfoAssertions.Exist(null, Random.FileName().ToFile())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Exist(null)).ThrowExactly<ArgumentNullException>().WithParameterName("info");

      Random.File().TryFinallyDelete(file => Validate(true, file));
      Random.Directory().TryFinallyDelete(directory => Validate(true, directory));

      Validate(false, Random.FileName().ToFile());
      Validate(false, Random.DirectoryName().ToDirectory());
    }

    return;

    static void Validate(bool result, FileSystemInfo info)
    {
      if (result)
      {
        Assert.To.Exist(info).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Exist(info, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileSystemInfoAssertions.Attribute(IAssertion, FileSystemInfo, FileAttributes, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Attribute_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FileSystemInfoAssertions.Attribute(null, Random.FileName().ToFile(), FileAttributes.Normal)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Attribute(null, FileAttributes.Normal)).ThrowExactly<ArgumentNullException>().WithParameterName("info");

      Random.File().TryFinallyDelete(file =>
      {
        Validate(true, file.AsReadOnly(), FileAttributes.ReadOnly);
        Enum.GetValues<FileAttributes>().ForEach(attribute => Validate((file.Attributes & attribute) == attribute, file, attribute));
      });
    }

    return;

    static void Validate(bool result, FileSystemInfo info, FileAttributes attribute)
    {
      if (result)
      {
        Assert.To.Attribute(info, attribute).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Attribute(info, attribute, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}