using Catharsis.Commons;
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

    Attributes.TempFile().File.Expect().Length(int.MinValue).Result.Should().BeFalse();
    Attributes.TempFile().File.Expect().Length(int.MaxValue).Result.Should().BeFalse();
    Attributes.TempFile().File.Expect().Length(Attributes.TempFile().File.Length).Result.Should().BeTrue();
    Attributes.TempFile().File.Empty().Expect().Length(0).Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoExpectations.Empty(IExpectation{FileInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => FileInfoExpectations.Empty(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((FileInfo) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Attributes.TempFile().File.Expect().Empty().Result.Should().BeFalse();
    Attributes.TempFile().File.Empty().Expect().Empty().Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoExpectations.ReadOnly(IExpectation{FileInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Method()
  {
    AssertionExtensions.Should(() => FileInfoExpectations.ReadOnly(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((FileInfo) null).Expect().ReadOnly()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Attributes.TempFile().File.Expect().ReadOnly().Result.Should().BeFalse();
    Attributes.TempFile().File.AsReadOnly().Expect().ReadOnly().Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoExpectations.InDirectory(IExpectation{FileInfo}, DirectoryInfo)"/> method.</para>
  /// </summary>
  [Fact]
  public void InDirectory_Method()
  {
    AssertionExtensions.Should(() => FileInfoExpectations.InDirectory(null, Attributes.TempDirectory().Directory)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((FileInfo) null).Expect().InDirectory(Attributes.TempDirectory().Directory)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Attributes.TempFile().File.Expect().InDirectory(null)).ThrowExactly<ArgumentNullException>().WithParameterName("directory");

    Attributes.TempFile().File.Expect().InDirectory(Environment.SystemDirectory.ToDirectory()).Result.Should().BeFalse();
    Attributes.TempFile().File.Expect().InDirectory(Attributes.TempDirectory().Directory).Result.Should().BeTrue();
  }
}