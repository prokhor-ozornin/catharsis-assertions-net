using FluentAssertions;
using Xunit;

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

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.Position(IAssertion, Stream, long, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Position_Method()
  {
    AssertionExtensions.Should(() => StreamAssertions.Position(null, Stream.Null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Position(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.Empty(IAssertion, Stream, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => StreamAssertions.Empty(null, Stream.Null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Empty((Stream) null)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.Readable(IAssertion, Stream, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Readable_Method()
  {
    AssertionExtensions.Should(() => StreamAssertions.Readable(null, Stream.Null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Readable((Stream) null)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.Writable(IAssertion, Stream, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Writable_Method()
  {
    AssertionExtensions.Should(() => StreamAssertions.Writable(null, Stream.Null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Writable((Stream) null)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.Seekable(IAssertion, Stream, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Seekable_Method()
  {
    AssertionExtensions.Should(() => StreamAssertions.Seekable(null, Stream.Null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Seekable(null)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.ReadOnly(IAssertion, Stream, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Method()
  {
    AssertionExtensions.Should(() => StreamAssertions.ReadOnly(null, Stream.Null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ReadOnly((Stream) null)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");
    
    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamAssertions.WriteOnly(IAssertion, Stream, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void WriteOnly_Method()
  {
    AssertionExtensions.Should(() => StreamAssertions.WriteOnly(null, Stream.Null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.WriteOnly((Stream) null)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");

    throw new NotImplementedException();
  }
}