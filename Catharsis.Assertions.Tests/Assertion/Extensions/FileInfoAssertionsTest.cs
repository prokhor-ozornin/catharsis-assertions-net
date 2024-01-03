using Catharsis.Commons;
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
    AssertionExtensions.Should(() => FileInfoAssertions.Length(null, Attributes.TempFile().File, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => FileInfoAssertions.Length(Assert.To, null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("file");

    AssertionExtensions.Should(() => Assert.To.Length(Attributes.TempFile().File, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Length(Attributes.TempFile().File, int.MaxValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");

    Assert.To.Length(Attributes.TempFile().File, Attributes.TempFile().File.Length).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.Length(Attributes.TempFile().File.Empty(), 0).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoAssertions.Empty(IAssertion, FileInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => FileInfoAssertions.Empty(null, Attributes.TempFile().File)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => FileInfoAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("file");

    AssertionExtensions.Should(() => Assert.To.Empty(Attributes.TempFile().File, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Empty(Attributes.TempFile().File.Empty()).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoAssertions.ReadOnly(IAssertion, FileInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Method()
  {
    AssertionExtensions.Should(() => FileInfoAssertions.ReadOnly(null, Attributes.TempFile().File)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => FileInfoAssertions.ReadOnly(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("file");

    AssertionExtensions.Should(() => Assert.To.ReadOnly(Attributes.TempFile().File, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.ReadOnly(Attributes.TempFile().File.AsReadOnly()).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoAssertions.InDirectory(IAssertion, FileInfo, DirectoryInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void InDirectory_Method()
  {
    AssertionExtensions.Should(() => FileInfoAssertions.InDirectory(null, Attributes.TempFile().File, Attributes.TempDirectory().Directory)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => FileInfoAssertions.InDirectory(Assert.To, null, Attributes.TempDirectory().Directory)).ThrowExactly<ArgumentNullException>().WithParameterName("file");
    AssertionExtensions.Should(() => Assert.To.InDirectory(Attributes.TempFile().File, null)).ThrowExactly<ArgumentNullException>().WithParameterName("directory");

    AssertionExtensions.Should(() => Assert.To.InDirectory(Attributes.TempFile().File, Environment.SystemDirectory.ToDirectory(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.InDirectory(Attributes.TempFile().File, Attributes.TempDirectory().Directory).Should().NotBeNull().And.BeSameAs(Assert.To);
  }
}