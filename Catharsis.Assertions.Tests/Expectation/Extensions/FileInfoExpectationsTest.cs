using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="FileInfoExpectations"/>.</para>
/// </summary>
public sealed class FileInfoExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoExpectations.Length(IExpectation{FileInfo}, long)"/> method.</para>
  /// </summary>
  [Fact]
  public void Length_Method()
  {
    AssertionExtensions.Should(() => FileInfoExpectations.Length(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((FileInfo) null).Expect().Length(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    RandomFile.Expect().Length(int.MinValue).Result.Should().BeFalse();
    RandomFile.Expect().Length(int.MaxValue).Result.Should().BeFalse();
    RandomFile.Expect().Length(RandomFile.Length).Result.Should().BeTrue();
    RandomFile.Empty().Expect().Length(0).Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoExpectations.Empty(IExpectation{FileInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => FileInfoExpectations.Empty(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((FileInfo) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    RandomFile.Expect().Empty().Result.Should().BeFalse();
    RandomFile.Empty().Expect().Empty().Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoExpectations.ReadOnly(IExpectation{FileInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Method()
  {
    AssertionExtensions.Should(() => FileInfoExpectations.ReadOnly(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((FileInfo) null).Expect().ReadOnly()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    RandomFile.Expect().ReadOnly().Result.Should().BeFalse();
    RandomFile.AsReadOnly().Expect().ReadOnly().Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoExpectations.InDirectory(IExpectation{FileInfo}, DirectoryInfo)"/> method.</para>
  /// </summary>
  [Fact]
  public void InDirectory_Method()
  {
    AssertionExtensions.Should(() => FileInfoExpectations.InDirectory(null, RandomDirectory)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((FileInfo) null).Expect().InDirectory(RandomDirectory)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => RandomFile.Expect().InDirectory(null)).ThrowExactly<ArgumentNullException>().WithParameterName("directory");

    RandomFile.Expect().InDirectory(Environment.SystemDirectory.ToDirectory()).Result.Should().BeFalse();
    RandomFile.Expect().InDirectory(RandomFile.Directory).Result.Should().BeTrue();
  }
}