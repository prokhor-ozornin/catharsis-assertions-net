using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="FileSystemInfoAssertions"/>.</para>
/// </summary>
public sealed class FileSystemInfoAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="FileSystemInfoAssertions.Exist(IAssertion, FileSystemInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Exist_Method()
  {
    AssertionExtensions.Should(() => FileSystemInfoAssertions.Exist(null, RandomFile)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Exist(null)).ThrowExactly<ArgumentNullException>().WithParameterName("info");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileSystemInfoAssertions.Attribute(IAssertion, FileSystemInfo, FileAttributes, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Attribute_Method()
  {
    AssertionExtensions.Should(() => FileSystemInfoAssertions.Attribute(null, RandomFile, FileAttributes.Normal)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Attribute(null, FileAttributes.Normal)).ThrowExactly<ArgumentNullException>().WithParameterName("info");

    throw new NotImplementedException();
  }
}