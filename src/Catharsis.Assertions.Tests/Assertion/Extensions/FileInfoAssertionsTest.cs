using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="FileInfoAssertions"/>.</para>
/// </summary>
/// <seealso cref="FileInfoAssertions"/>
public sealed class FileInfoAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="FileInfoAssertions.Length(IAssertion, FileInfo, long, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Length_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FileInfoAssertions.Length(null, Random.FileName().ToFile(), 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => FileInfoAssertions.Length(Assert.To, null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("file");

      Random.File().TryFinallyDelete(file =>
      {
        Test(true, file, file.Length);
        Test(true, file.Empty(), 0);
        Test(false, file, int.MinValue);
      });
    }

    return;

    static void Test(bool result, FileInfo file, long length)
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
      AssertionExtensions.Should(() => FileInfoAssertions.Empty(null, Random.FileName().ToFile())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => FileInfoAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("file");

      Random.BinaryFile(short.MaxValue).TryFinallyDelete(file =>
      {
        Test(false, file);
        Test(true, file.Empty());
      });
    }

    return;

    static void Test(bool result, FileInfo file)
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
      AssertionExtensions.Should(() => FileInfoAssertions.ReadOnly(null, Random.FileName().ToFile())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => FileInfoAssertions.ReadOnly(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("file");

      Random.File().TryFinallyDelete(file =>
      {
        Test(false, file);
        Test(true, file.AsReadOnly());
      });
    }

    return;

    static void Test(bool result, FileInfo file)
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
      AssertionExtensions.Should(() => FileInfoAssertions.InDirectory(null, Random.FileName().ToFile(), Random.DirectoryName().ToDirectory())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => FileInfoAssertions.InDirectory(Assert.To, null, Random.DirectoryName().ToDirectory())).ThrowExactly<ArgumentNullException>().WithParameterName("file");
      AssertionExtensions.Should(() => Assert.To.InDirectory(Random.FileName().ToFile(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("directory");

      Random.File().TryFinallyDelete(file =>
      {
        Test(true, file, file.Directory);
        Test(false, file, Environment.SystemDirectory.ToDirectory());
      });
    }

    return;

    static void Test(bool result, FileInfo file, DirectoryInfo directory)
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