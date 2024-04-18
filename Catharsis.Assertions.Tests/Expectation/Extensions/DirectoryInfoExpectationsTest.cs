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

      Validate(true, Attributes.TempDirectory());
      
      Attributes.TempDirectory().With(directory =>
      {
        Attributes.Random().File(directory.Directory);
        Validate(false, directory);
      });

      Attributes.TempDirectory().With(directory =>
      {
        Attributes.Random().Directory(directory.Directory);
        Validate(false, directory);
      });
    }

    return;

    static void Validate(bool result, TempDirectory directory)
    {
      using (directory)
      {
        directory.Directory.Expect().Empty().Should().BeOfType<Expectation<DirectoryInfo>>().Which.Result.Should().Be(result);
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryInfoExpectations.InDirectory(IExpectation{DirectoryInfo}, DirectoryInfo)"/> method.</para>
  /// </summary>
  [Fact]
  public void InDirectory_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DirectoryInfoExpectations.InDirectory(null, Attributes.TempDirectory().Directory)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((DirectoryInfo) null).Expect().InDirectory(Attributes.TempDirectory().Directory)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => Attributes.TempDirectory().Directory.Expect().InDirectory(null)).ThrowExactly<ArgumentNullException>().WithParameterName("parent");

      Attributes.TempDirectory().With(directory => Validate(true, directory, directory.Directory.Parent));
      Attributes.TempDirectory().With(directory => Validate(false, directory, directory.Directory));
    }

    return;

    static void Validate(bool result, TempDirectory directory, DirectoryInfo parent)
    {
      using (directory)
      {
        directory.Directory.Expect().InDirectory(parent).Should().BeOfType<Expectation<DirectoryInfo>>().Which.Result.Should().Be(result);
      }
    }
  }
}