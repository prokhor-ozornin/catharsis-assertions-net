using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StreamExpectations"/>.</para>
/// </summary>
public sealed class StreamExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StreamExpectations.Length(IExpectation{Stream}, long)"/> method.</para>
  /// </summary>
  [Fact]
  public void Length_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StreamExpectations.Length(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Stream) null).Expect().Length(0)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, Stream.Null, 0);
      Test(false, Stream.Null, int.MinValue);
      Test(false, Stream.Null, int.MaxValue);
    }

    return;

    static void Test(bool result, Stream stream, int length)
    {
      using (stream)
      {
        stream.Expect().Length(length).Should().BeOfType<Expectation<Stream>>().Which.Result.Should().Be(result);
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamExpectations.Empty(IExpectation{Stream})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StreamExpectations.Empty(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Stream) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, Stream.Null);
      Test(false, RandomStream);
    }

    return;

    static void Test(bool result, Stream stream)
    {
      using (stream)
      {
        stream.Expect().Empty().Should().BeOfType<Expectation<Stream>>().Which.Result.Should().Be(result);
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamExpectations.Position(IExpectation{Stream}, long)"/> method.</para>
  /// </summary>
  [Fact]
  public void Position_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StreamExpectations.Position(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Stream) null).Expect().Position(0)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(false, Stream.Null, int.MinValue);
      Test(false, Stream.Null, int.MaxValue);
      Test(true, Stream.Null, 0);
    }

    return;

    static void Test(bool result, Stream stream, long position)
    {
      using (stream)
      {
        stream.Expect().Position(position).Should().BeOfType<Expectation<Stream>>().Which.Result.Should().Be(result);
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamExpectations.End(IExpectation{Stream})"/> method.</para>
  /// </summary>
  [Fact]
  public void End_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StreamExpectations.End(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Stream) null).Expect().End()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, Stream.Null);
      Test(true, Random.MemoryStream(short.MaxValue).MoveToEnd());
      Test(false, Random.MemoryStream(short.MaxValue));
    }

    return;

    static void Test(bool result, Stream stream)
    {
      using (stream)
      {
        stream.Expect().End().Should().BeOfType<Expectation<Stream>>().Which.Result.Should().Be(result);
      }
    }
  }
  
  /// <summary>
  ///   <para>Performs testing of <see cref="StreamExpectations.Readable(IExpectation{Stream})"/> method.</para>
  /// </summary>
  [Fact]
  public void Readable_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StreamExpectations.Readable(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Stream) null).Expect().Readable()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

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
        stream.Expect().Readable().Should().BeOfType<Expectation<Stream>>().Which.Result.Should().Be(result);
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamExpectations.Writable(IExpectation{Stream})"/> method.</para>
  /// </summary>
  [Fact]
  public void Writable_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StreamExpectations.Writable(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Stream) null).Expect().Writable()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

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
        stream.Expect().Writable().Should().BeOfType<Expectation<Stream>>().Which.Result.Should().Be(result);
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamExpectations.Seekable(IExpectation{Stream})"/> method.</para>
  /// </summary>
  [Fact]
  public void Seekable_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StreamExpectations.Seekable(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Stream) null).Expect().Seekable()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

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
        stream.Expect().Seekable().Should().BeOfType<Expectation<Stream>>().Which.Result.Should().Be(result);
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamExpectations.ReadOnly(IExpectation{Stream})"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StreamExpectations.ReadOnly(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Stream) null).Expect().ReadOnly()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

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
        stream.Expect().ReadOnly().Should().BeOfType<Expectation<Stream>>().Which.Result.Should().Be(result);
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamExpectations.WriteOnly(IExpectation{Stream})"/> method.</para>
  /// </summary>
  [Fact]
  public void WriteOnly_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StreamExpectations.WriteOnly(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Stream) null).Expect().WriteOnly()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

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
        stream.Expect().WriteOnly().Should().BeOfType<Expectation<Stream>>().Which.Result.Should().Be(result);
      }
    }
  }
}