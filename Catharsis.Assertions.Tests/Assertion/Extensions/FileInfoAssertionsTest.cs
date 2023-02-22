using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="FileInfoAssertions"/>.</para>
/// </summary>
public sealed class FileInfoAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoAssertions.Length(IAssertion, FileInfo, long, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Length_Method()
  {
    AssertionExtensions.Should(() => FileInfoAssertions.Length(null, RandomFile, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => FileInfoAssertions.Length(Assert.To, null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("file");

    AssertionExtensions.Should(() => Assert.To.Length(RandomFile, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Length(RandomFile, int.MaxValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");

    Assert.To.Length(RandomFile, RandomFile.Length).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.Length(RandomFile.Empty(), 0).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoAssertions.Empty(IAssertion, FileInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => FileInfoAssertions.Empty(null, RandomFile)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => FileInfoAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("file");

    AssertionExtensions.Should(() => Assert.To.Empty(RandomFile, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Empty(RandomFile.Empty()).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoAssertions.ReadOnly(IAssertion, FileInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Method()
  {
    AssertionExtensions.Should(() => FileInfoAssertions.ReadOnly(null, RandomFile)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => FileInfoAssertions.ReadOnly(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("file");

    AssertionExtensions.Should(() => Assert.To.ReadOnly(RandomFile, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.ReadOnly(RandomFile.AsReadOnly()).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoAssertions.InDirectory(IAssertion, FileInfo, DirectoryInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void InDirectory_Method()
  {
    AssertionExtensions.Should(() => FileInfoAssertions.InDirectory(null, RandomFile, RandomDirectory)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => FileInfoAssertions.InDirectory(Assert.To, null, RandomDirectory)).ThrowExactly<ArgumentNullException>().WithParameterName("file");
    AssertionExtensions.Should(() => Assert.To.InDirectory(RandomFile, null)).ThrowExactly<ArgumentNullException>().WithParameterName("directory");

    AssertionExtensions.Should(() => Assert.To.InDirectory(RandomFile, Environment.SystemDirectory.ToDirectory(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.InDirectory(RandomFile, RandomFile.Directory).Should().NotBeNull().And.BeSameAs(Assert.To);
  }
}