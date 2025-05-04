using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="FileSystemInfoExpectations"/>.</para>
/// </summary>
public sealed class FileSystemInfoExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="FileSystemInfoExpectations.Exist(IExpectation{FileSystemInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Exist_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FileSystemInfoExpectations.Exist(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((FileInfo) null).Expect().Exist()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Random.File().TryFinallyDelete(file => Validate(true, file));
      Random.Directory().TryFinallyDelete(directory => Validate(true, directory));

      Validate(false, Random.FileName().ToFile());
      Validate(false, Random.DirectoryName().ToDirectory());
    }

    return;

    static void Validate(bool result, FileSystemInfo info) => info.Expect().Exist().Should().BeOfType<Expectation<FileSystemInfo>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileSystemInfoExpectations.Attribute(IExpectation{FileSystemInfo}, FileAttributes)"/> method.</para>
  /// </summary>
  [Fact]
  public void Attribute_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FileSystemInfoExpectations.Attribute(null, FileAttributes.Normal)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((FileInfo) null).Expect().Attribute(FileAttributes.Normal)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Random.File().TryFinallyDelete(file =>
      {
        Validate(true, file.AsReadOnly(), FileAttributes.ReadOnly);
        Enum.GetValues<FileAttributes>().ForEach(attribute => Validate((file.Attributes & attribute) == attribute, file, attribute));
      });
    }

    return;

    static void Validate(bool result, FileSystemInfo info, FileAttributes attribute) => info.Expect().Attribute(attribute).Should().BeOfType<Expectation<FileSystemInfo>>().Which.Result.Should().Be(result);
  }
}