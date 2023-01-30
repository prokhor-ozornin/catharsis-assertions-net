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



    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryInfoExpectations.InDirectory(IExpectation{DirectoryInfo}, DirectoryInfo)"/> method.</para>
  /// </summary>
  [Fact]
  public void InDirectory_Method()
  {
    AssertionExtensions.Should(() => DirectoryInfoExpectations.InDirectory(null, RandomDirectory)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((DirectoryInfo) null).Expect().InDirectory(RandomDirectory)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => RandomDirectory.Expect().InDirectory(null)).ThrowExactly<ArgumentNullException>().WithParameterName("directory");

    throw new NotImplementedException();
  }
}