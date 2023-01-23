using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DirectoryInfoAssertions"/>.</para>
/// </summary>
public sealed class DirectoryInfoAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryInfoAssertions.Empty(IAssertion, DirectoryInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => DirectoryInfoAssertions.Empty(null, RandomDirectory)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => DirectoryInfoAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("directory");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryInfoAssertions.InDirectory(IAssertion, DirectoryInfo, DirectoryInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void InDirectory_Method()
  {
    AssertionExtensions.Should(() => DirectoryInfoAssertions.InDirectory(null, RandomDirectory, RandomDirectory)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => DirectoryInfoAssertions.InDirectory(Assert.To, null, RandomDirectory)).ThrowExactly<ArgumentNullException>().WithParameterName("directory");
    AssertionExtensions.Should(() => Assert.To.InDirectory(RandomDirectory, null)).ThrowExactly<ArgumentNullException>().WithParameterName("parent");

    throw new NotImplementedException();
  }
}