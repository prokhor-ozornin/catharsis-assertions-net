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

    RandomDirectory.Expect().Empty().Result.Should().BeTrue();
    
    RandomDirectory.TryFinallyClear(directory =>
    {
      Randomizer.BinaryFile(0, null, null, directory);
      directory.Expect().Empty().Result.Should().BeFalse();
    });

    RandomDirectory.TryFinallyClear(directory =>
    {
      Randomizer.Directory(directory);
      directory.Expect().Empty().Result.Should().BeFalse();
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryInfoExpectations.InDirectory(IExpectation{DirectoryInfo}, DirectoryInfo)"/> method.</para>
  /// </summary>
  [Fact]
  public void InDirectory_Method()
  {
    AssertionExtensions.Should(() => DirectoryInfoExpectations.InDirectory(null, RandomDirectory)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((DirectoryInfo) null).Expect().InDirectory(RandomDirectory)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => RandomDirectory.Expect().InDirectory(null)).ThrowExactly<ArgumentNullException>().WithParameterName("parent");

    RandomDirectory.Expect().InDirectory(RandomDirectory).Result.Should().BeFalse();
    RandomDirectory.Expect().InDirectory(RandomDirectory.Parent).Result.Should().BeTrue();
  }
}