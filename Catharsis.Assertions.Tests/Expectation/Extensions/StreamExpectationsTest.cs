using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StreamExpectations"/>.</para>
/// </summary>
public sealed class StreamExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StreamExpectations.Length(IExpectation{Stream}, long)"/> method.</para>
  /// </summary>
  [Fact]
  public void Length_Method()
  {
    AssertionExtensions.Should(() => StreamExpectations.Length(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Stream) null).Expect().Length(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Stream.Null.Expect().Length(int.MinValue).Result.Should().BeFalse();
    Stream.Null.Expect().Length(int.MaxValue).Result.Should().BeFalse();
    Stream.Null.Expect().Length(Stream.Null.Length).Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamExpectations.Empty(IExpectation{Stream})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => StreamExpectations.Empty(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Stream) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Stream.Null.Expect().Empty().Result.Should().BeTrue();
    Attributes.RandomStream().Expect().Empty().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamExpectations.Position(IExpectation{Stream}, long)"/> method.</para>
  /// </summary>
  [Fact]
  public void Position_Method()
  {
    AssertionExtensions.Should(() => StreamExpectations.Position(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Stream) null).Expect().Position(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Stream.Null.Expect().Position(int.MinValue).Result.Should().BeFalse();
    Stream.Null.Expect().Position(int.MaxValue).Result.Should().BeFalse();
    Stream.Null.Expect().Position(Stream.Null.Position).Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamExpectations.End(IExpectation{Stream})"/> method.</para>
  /// </summary>
  [Fact]
  public void End_Method()
  {
    AssertionExtensions.Should(() => StreamExpectations.End(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Stream) null).Expect().End()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Stream.Null.Expect().End().Result.Should().BeTrue();
    
    Attributes.RandomStream().With(stream =>
    {
      stream.Expect().End().Result.Should().BeFalse();
      stream.MoveToEnd().Expect().Result.Should().BeTrue();
    });
  }
  
  /// <summary>
  ///   <para>Performs testing of <see cref="StreamExpectations.Readable(IExpectation{Stream})"/> method.</para>
  /// </summary>
  [Fact]
  public void Readable_Method()
  {
    AssertionExtensions.Should(() => StreamExpectations.Readable(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Stream) null).Expect().Readable()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Stream.Null.Expect().Readable().Result.Should().BeTrue();
    Stream.Null.AsWriteOnly().Expect().Readable().Result.Should().BeFalse();
    Stream.Null.AsWriteOnlyForward().Expect().Readable().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamExpectations.Writable(IExpectation{Stream})"/> method.</para>
  /// </summary>
  [Fact]
  public void Writable_Method()
  {
    AssertionExtensions.Should(() => StreamExpectations.Writable(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Stream) null).Expect().Writable()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Stream.Null.Expect().Writable().Result.Should().BeTrue();
    Stream.Null.AsReadOnly().Expect().Writable().Result.Should().BeFalse();
    Stream.Null.AsReadOnlyForward().Expect().Writable().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamExpectations.Seekable(IExpectation{Stream})"/> method.</para>
  /// </summary>
  [Fact]
  public void Seekable_Method()
  {
    AssertionExtensions.Should(() => StreamExpectations.Seekable(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Stream) null).Expect().Seekable()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Stream.Null.Expect().Seekable().Result.Should().BeTrue();
    Stream.Null.AsReadOnlyForward().Expect().Seekable().Result.Should().BeFalse();
    Stream.Null.AsWriteOnlyForward().Expect().Seekable().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamExpectations.ReadOnly(IExpectation{Stream})"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Method()
  {
    AssertionExtensions.Should(() => StreamExpectations.ReadOnly(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Stream) null).Expect().ReadOnly()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Stream.Null.Expect().ReadOnly().Result.Should().BeFalse();
    Stream.Null.AsReadOnly().Expect().ReadOnly().Result.Should().BeTrue();
    Stream.Null.AsReadOnlyForward().Expect().ReadOnly().Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamExpectations.WriteOnly(IExpectation{Stream})"/> method.</para>
  /// </summary>
  [Fact]
  public void WriteOnly_Method()
  {
    AssertionExtensions.Should(() => StreamExpectations.WriteOnly(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Stream) null).Expect().WriteOnly()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    
    Stream.Null.Expect().WriteOnly().Result.Should().BeFalse();
    Stream.Null.AsWriteOnly().Expect().WriteOnly().Result.Should().BeTrue();
    Stream.Null.AsWriteOnlyForward().Expect().WriteOnly().Result.Should().BeTrue();
  }
}