using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DirectoryInfoExpectations"/>.</para>
/// </summary>
public sealed class DirectoryInfoExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryInfoExpectations.Empty(IExpectation{DirectoryInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => DirectoryInfoExpectations.Empty(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((DirectoryInfo) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Attributes.TempDirectory().Directory.Expect().Empty().Result.Should().BeTrue();
    
    Attributes.TempDirectory().Directory.TryFinallyClear(directory =>
    {
      Attributes.Random().File(directory);
      directory.Expect().Empty().Result.Should().BeFalse();
    });

    Attributes.TempDirectory().Directory.TryFinallyClear(directory =>
    {
      Attributes.Random().Directory(directory);
      directory.Expect().Empty().Result.Should().BeFalse();
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryInfoExpectations.InDirectory(IExpectation{DirectoryInfo}, DirectoryInfo)"/> method.</para>
  /// </summary>
  [Fact]
  public void InDirectory_Method()
  {
    AssertionExtensions.Should(() => DirectoryInfoExpectations.InDirectory(null, Attributes.TempDirectory().Directory)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((DirectoryInfo) null).Expect().InDirectory(Attributes.TempDirectory().Directory)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Attributes.TempDirectory().Directory.Expect().InDirectory(null)).ThrowExactly<ArgumentNullException>().WithParameterName("parent");

    Attributes.TempDirectory().Directory.Expect().InDirectory(Attributes.TempDirectory().Directory).Result.Should().BeFalse();
    Attributes.TempDirectory().Directory.Expect().InDirectory(Attributes.TempDirectory().Directory.Parent).Result.Should().BeTrue();
  }
}