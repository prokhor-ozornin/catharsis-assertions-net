using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StreamAssertions"/>.</para>
/// </summary>
/// <seealso cref="StreamAssertions"/>
public sealed class StreamAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.Length(IAssertion, Stream, long, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Length_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StreamAssertions.Length(null, Stream.Null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => StreamAssertions.Length(Assert.To, null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");

      Test(true, Stream.Null, 0);
      Test(false, Stream.Null, int.MinValue);
      Test(false, Stream.Null, int.MaxValue);
    }

    return;

    static void Test(bool result, Stream stream, int length)
    {
      using (stream)
      {
        if (result)
        {
          Assert.To.Length(stream, length).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Length(stream, length, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.Empty(IAssertion, Stream, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StreamAssertions.Empty(null, Stream.Null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Empty((Stream) null)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");

      Test(true, Stream.Null);
      Test(false, RandomStream);
    }

    return;

    static void Test(bool result, Stream stream)
    {
      using (stream)
      {
        if (result)
        {
          Assert.To.Empty(stream).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Empty(stream, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.Position(IAssertion, Stream, long, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Position_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StreamAssertions.Position(null, Stream.Null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Position(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");

      Test(false, Stream.Null, int.MinValue);
      Test(false, Stream.Null, int.MaxValue);
      Test(true, Stream.Null, 0);
    }

    return;

    static void Test(bool result, Stream stream, long position)
    {
      using (stream)
      {
        if (result)
        {
          Assert.To.Position(stream, position).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Position(stream, position, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.End(IAssertion, Stream, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void End_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StreamAssertions.End(null, Stream.Null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.End((Stream) null)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");

      Test(true, Stream.Null);
      Test(true, Random.MemoryStream(short.MaxValue).MoveToEnd());
      Test(false, Random.MemoryStream(short.MaxValue));
    }

    return;

    static void Test(bool result, Stream stream)
    {
      using (stream)
      {
        if (result)
        {
          Assert.To.End(stream).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.End(stream, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.Readable(IAssertion, Stream, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Readable_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StreamAssertions.Readable(null, Stream.Null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Readable((Stream) null)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");

      Test(true, Stream.Null);
      Test(true, Stream.Null.AsReadOnly());
      Test(true, Stream.Null.AsReadOnlyForward());
      Test(false, Stream.Null.AsWriteOnly());
      Test(false, Stream.Null.AsWriteOnlyForward());
    }

    return;

    static void Test(bool result, Stream stream)
    {
      using (stream)
      {
        if (result)
        {
          Assert.To.Readable(stream).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Readable(stream, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.Writable(IAssertion, Stream, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Writable_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StreamAssertions.Writable(null, Stream.Null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Writable((Stream) null)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");

      Test(true, Stream.Null);
      Test(true, Stream.Null.AsWriteOnly());
      Test(true, Stream.Null.AsWriteOnlyForward());
      Test(false, Stream.Null.AsReadOnly());
      Test(false, Stream.Null.AsReadOnlyForward());
    }

    return;

    static void Test(bool result, Stream stream)
    {
      using (stream)
      {
        if (result)
        {
          Assert.To.Writable(stream).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Writable(stream, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.Seekable(IAssertion, Stream, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Seekable_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StreamAssertions.Seekable(null, Stream.Null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Seekable(null)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");

      Test(true, Stream.Null);
      Test(true, Stream.Null.AsReadOnly());
      Test(true, Stream.Null.AsWriteOnly());
      Test(false, Stream.Null.AsReadOnlyForward());
      Test(false, Stream.Null.AsWriteOnlyForward());
    }

    return;

    static void Test(bool result, Stream stream)
    {
      using (stream)
      {
        if (result)
        {
          Assert.To.Seekable(stream).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Seekable(stream, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.ReadOnly(IAssertion, Stream, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StreamAssertions.ReadOnly(null, Stream.Null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.ReadOnly((Stream) null)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");

      Test(true, Stream.Null.AsReadOnly());
      Test(true, Stream.Null.AsReadOnlyForward());
      Test(false, Stream.Null);
      Test(false, Stream.Null.AsWriteOnly());
      Test(false, Stream.Null.AsWriteOnlyForward());
    }

    return;

    static void Test(bool result, Stream stream)
    {
      using (stream)
      {
        if (result)
        {
          Assert.To.ReadOnly(stream).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.ReadOnly(stream, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.WriteOnly(IAssertion, Stream, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void WriteOnly_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StreamAssertions.WriteOnly(null, Stream.Null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.WriteOnly((Stream) null)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");

      Test(true, Stream.Null.AsWriteOnly());
      Test(true, Stream.Null.AsWriteOnlyForward());
      Test(false, Stream.Null);
      Test(false, Stream.Null.AsReadOnly());
      Test(false, Stream.Null.AsReadOnlyForward());
    }

    return;

    static void Test(bool result, Stream stream)
    {
      using (stream)
      {
        if (result)
        {
          Assert.To.WriteOnly(stream).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.WriteOnly(stream, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }
}