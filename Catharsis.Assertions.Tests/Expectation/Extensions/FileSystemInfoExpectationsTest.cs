using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="FileSystemInfoExpectations"/>.</para>
/// </summary>
public sealed class FileSystemInfoExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="FileSystemInfoExpectations.Exist(IExpectation{FileSystemInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Exist_Method()
  {
    AssertionExtensions.Should(() => FileSystemInfoExpectations.Exist(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((FileInfo) null).Expect().Exist()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Assert.To.Exist(RandomFile).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Exist(RandomFakeFile, "error")).ThrowExactly<ArgumentException>("error");

    Assert.To.Exist(RandomDirectory).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Exist(RandomFakeDirectory, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileSystemInfoExpectations.Attribute(IExpectation{FileSystemInfo}, FileAttributes)"/> method.</para>
  /// </summary>
  [Fact]
  public void Attribute_Method()
  {
    AssertionExtensions.Should(() => FileSystemInfoExpectations.Attribute(null, FileAttributes.Normal)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((FileInfo) null).Expect().Attribute(FileAttributes.Normal)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    RandomFile.With(file =>
    {
      Enum.GetValues<FileAttributes>().ForEach(attribute => file.Expect().Attribute(attribute).Result.Should().Be((file.Attributes & attribute) == attribute));
      file.AsReadOnly().Expect().Attribute(FileAttributes.ReadOnly).Result.Should().BeTrue();
    });
  }
}