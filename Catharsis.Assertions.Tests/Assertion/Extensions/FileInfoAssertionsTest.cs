using Catharsis.Commons;
using Catharsis.Extensions;
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
      AssertionExtensions.Should(() => FileInfoAssertions.Length(null, Attributes.Random().FileName().ToFile(), default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => FileInfoAssertions.Length(Assert.To, null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("file");

      AssertionExtensions.Should(() => Assert.To.Length(Attributes.Random().FileName().ToFile(), int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      AssertionExtensions.Should(() => Assert.To.Length(Attributes.Random().FileName().ToFile(), int.MaxValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");

      Attributes.Random().File().TryFinallyDelete(file =>
      {
        Validate(true, file, file.Length);
        Validate(true, file.Empty(), 0);
        Validate(false, file, int.MinValue);
      });
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
      AssertionExtensions.Should(() => FileInfoAssertions.Empty(null, Attributes.Random().FileName().ToFile())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => FileInfoAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("file");

      Attributes.Random().BinaryFile(short.MaxValue).TryFinallyDelete(file =>
      {
        Validate(false, file);
        Validate(true, file.Empty());
      });
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
      AssertionExtensions.Should(() => FileInfoAssertions.ReadOnly(null, Attributes.Random().FileName().ToFile())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => FileInfoAssertions.ReadOnly(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("file");

      Attributes.Random().File().TryFinallyDelete(file =>
      {
        Validate(false, file);
        Validate(true, file.AsReadOnly());
      });
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
      AssertionExtensions.Should(() => FileInfoAssertions.InDirectory(null, Attributes.Random().FileName().ToFile(), Attributes.Random().DirectoryName().ToDirectory())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => FileInfoAssertions.InDirectory(Assert.To, null, Attributes.Random().DirectoryName().ToDirectory())).ThrowExactly<ArgumentNullException>().WithParameterName("file");
      AssertionExtensions.Should(() => Assert.To.InDirectory(Attributes.Random().FileName().ToFile(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("directory");

      Attributes.Random().File().TryFinallyDelete(file =>
      {
        Validate(true, file, file.Directory);
        Validate(false, file, Environment.SystemDirectory.ToDirectory());
      });
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