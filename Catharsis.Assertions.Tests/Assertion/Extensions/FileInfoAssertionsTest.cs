using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FileInfoAssertions.Length(null, Attributes.TempFile().File, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => FileInfoAssertions.Length(Assert.To, null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("file");

      AssertionExtensions.Should(() => Assert.To.Length(Attributes.TempFile().File, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      AssertionExtensions.Should(() => Assert.To.Length(Attributes.TempFile().File, int.MaxValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    }

    return;

    static void Validate(bool result, FileInfo file, long length)
    {
      if (result)
      {
        Assert.To.Length(file, length).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Length(file, length, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoAssertions.Empty(IAssertion, FileInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FileInfoAssertions.Empty(null, Attributes.TempFile().File)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => FileInfoAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("file");
    }

    return;

    static void Validate(bool result, FileInfo file)
    {
      if (result)
      {
        Assert.To.Empty(file).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Empty(file, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoAssertions.ReadOnly(IAssertion, FileInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FileInfoAssertions.ReadOnly(null, Attributes.TempFile().File)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => FileInfoAssertions.ReadOnly(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("file");
    }

    return;

    static void Validate(bool result, FileInfo file)
    {
      if (result)
      {
        Assert.To.ReadOnly(file).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.ReadOnly(file, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoAssertions.InDirectory(IAssertion, FileInfo, DirectoryInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void InDirectory_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FileInfoAssertions.InDirectory(null, Attributes.TempFile().File, Attributes.TempDirectory().Directory)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => FileInfoAssertions.InDirectory(Assert.To, null, Attributes.TempDirectory().Directory)).ThrowExactly<ArgumentNullException>().WithParameterName("file");
      AssertionExtensions.Should(() => Assert.To.InDirectory(Attributes.TempFile().File, null)).ThrowExactly<ArgumentNullException>().WithParameterName("directory");
    }

    return;

    static void Validate(bool result, FileInfo file, DirectoryInfo directory)
    {
      if (result)
      {
        Assert.To.InDirectory(file, directory).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.InDirectory(file, directory, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}