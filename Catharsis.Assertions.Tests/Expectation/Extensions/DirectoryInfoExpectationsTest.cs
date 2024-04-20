using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DirectoryInfoExpectations.Empty(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((DirectoryInfo) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

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

    static void Validate(bool result, DirectoryInfo directory) => directory.Expect().Empty().Should().BeOfType<Expectation<DirectoryInfo>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryInfoExpectations.InDirectory(IExpectation{DirectoryInfo}, DirectoryInfo)"/> method.</para>
  /// </summary>
  [Fact]
  public void InDirectory_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DirectoryInfoExpectations.InDirectory(null, Attributes.Random().DirectoryName().ToDirectory())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((DirectoryInfo) null).Expect().InDirectory(Attributes.Random().DirectoryName().ToDirectory())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => Attributes.Random().DirectoryName().ToDirectory().Expect().InDirectory(null)).ThrowExactly<ArgumentNullException>().WithParameterName("parent");

      Attributes.Random().Directory().TryFinallyDelete(directory =>
      {
        Validate(true, directory, directory.Parent);
        Validate(false, directory, directory);
      });
    }

    return;

    static void Validate(bool result, DirectoryInfo directory, DirectoryInfo parent) => directory.Expect().InDirectory(parent).Should().BeOfType<Expectation<DirectoryInfo>>().Which.Result.Should().Be(result);
  }
}