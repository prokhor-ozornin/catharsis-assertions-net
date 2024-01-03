using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StreamAssertions"/>.</para>
/// </summary>
public sealed class StreamAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.Length(IAssertion, Stream, long, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Length_Method()
  {
    AssertionExtensions.Should(() => StreamAssertions.Length(null, Stream.Null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => StreamAssertions.Length(Assert.To, null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");

    AssertionExtensions.Should(() => Assert.To.Length(Stream.Null, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Length(Stream.Null, int.MaxValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Length(Stream.Null, Stream.Null.Length).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.Empty(IAssertion, Stream, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => StreamAssertions.Empty(null, Stream.Null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Empty((Stream) null)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");

    Assert.To.Empty(Stream.Null).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Empty(Attributes.RandomStream(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.Position(IAssertion, Stream, long, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Position_Method()
  {
    AssertionExtensions.Should(() => StreamAssertions.Position(null, Stream.Null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Position(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");

    AssertionExtensions.Should(() => Assert.To.Position(Stream.Null, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Position(Stream.Null, int.MaxValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Position(Stream.Null, Stream.Null.Position).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.End(IAssertion, Stream, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void End_Method()
  {
    AssertionExtensions.Should(() => StreamAssertions.End(null, Stream.Null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.End((Stream) null)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");

    Assert.To.End(Stream.Null).Should().NotBeNull().And.BeSameAs(Assert.To);
    
    Attributes.RandomStream().With(stream =>
    {
      AssertionExtensions.Should(() => Assert.To.End(stream, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.End(stream.MoveToEnd()).Should().NotBeNull().And.BeSameAs(Assert.To);
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.Readable(IAssertion, Stream, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Readable_Method()
  {
    AssertionExtensions.Should(() => StreamAssertions.Readable(null, Stream.Null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Readable((Stream) null)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");

    Assert.To.Readable(Stream.Null).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Readable(Stream.Null.AsWriteOnly(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Readable(Stream.Null.AsWriteOnlyForward(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.Writable(IAssertion, Stream, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Writable_Method()
  {
    AssertionExtensions.Should(() => StreamAssertions.Writable(null, Stream.Null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Writable((Stream) null)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");

    Assert.To.Writable(Stream.Null).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Writable(Stream.Null.AsReadOnly(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Writable(Stream.Null.AsReadOnlyForward(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.Seekable(IAssertion, Stream, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Seekable_Method()
  {
    AssertionExtensions.Should(() => StreamAssertions.Seekable(null, Stream.Null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Seekable(null)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");

    Assert.To.Seekable(Stream.Null).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Seekable(Stream.Null.AsReadOnlyForward(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Seekable(Stream.Null.AsWriteOnlyForward(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.ReadOnly(IAssertion, Stream, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Method()
  {
    AssertionExtensions.Should(() => StreamAssertions.ReadOnly(null, Stream.Null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ReadOnly((Stream) null)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");
    
    AssertionExtensions.Should(() => Assert.To.ReadOnly(Stream.Null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.ReadOnly(Stream.Null.AsReadOnly()).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.ReadOnly(Stream.Null.AsReadOnlyForward()).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.WriteOnly(IAssertion, Stream, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void WriteOnly_Method()
  {
    AssertionExtensions.Should(() => StreamAssertions.WriteOnly(null, Stream.Null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.WriteOnly((Stream) null)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");

    AssertionExtensions.Should(() => Assert.To.WriteOnly(Stream.Null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.WriteOnly(Stream.Null.AsWriteOnly()).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.WriteOnly(Stream.Null.AsWriteOnlyForward()).Should().NotBeNull().And.BeSameAs(Assert.To);
  }
}