using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests.Expectation.Extensions;

/// <summary>
///   <para>Tests set for class <see cref="FileSystemInfoExpectations"/>.</para>
/// </summary>
public sealed class FileSystemInfoExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="FileSystemInfoExpectations.Exist(IExpectation{FileSystemInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Exist_Method()
  {
    AssertionExtensions.Should(() => FileSystemInfoExpectations.Exist(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((FileInfo) null).Expect().Exist()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileSystemInfoExpectations.Attribute(IExpectation{FileSystemInfo}, FileAttributes)"/> method.</para>
  /// </summary>
  [Fact]
  public void Attribute_Method()
  {
    AssertionExtensions.Should(() => FileSystemInfoExpectations.Attribute(null, FileAttributes.Normal)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((FileInfo) null).Expect().Attribute(FileAttributes.Normal)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }
}