using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DirectoryInfoExpectations"/>.</para>
/// </summary>
/// <seealso cref="DirectoryInfoExpectations"/>
public sealed class DirectoryInfoExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryInfoExpectations.Empty(IExpectation{DirectoryInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DirectoryInfoExpectations.Empty(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((DirectoryInfo) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

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

    static void Test(bool result, DirectoryInfo directory) => directory.Expect().Empty().Should().BeOfType<Expectation<DirectoryInfo>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryInfoExpectations.InDirectory(IExpectation{DirectoryInfo}, DirectoryInfo)"/> method.</para>
  /// </summary>
  [Fact]
  public void InDirectory_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DirectoryInfoExpectations.InDirectory(null, Random.DirectoryName().ToDirectory())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((DirectoryInfo) null).Expect().InDirectory(Random.DirectoryName().ToDirectory())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => Random.DirectoryName().ToDirectory().Expect().InDirectory(null)).ThrowExactly<ArgumentNullException>().WithParameterName("parent");

      Random.Directory().TryFinallyDelete(directory =>
      {
        Test(true, directory, directory.Parent);
        Test(false, directory, directory);
      });
    }

    return;

    static void Test(bool result, DirectoryInfo directory, DirectoryInfo parent) => directory.Expect().InDirectory(parent).Should().BeOfType<Expectation<DirectoryInfo>>().Which.Result.Should().Be(result);
  }
}