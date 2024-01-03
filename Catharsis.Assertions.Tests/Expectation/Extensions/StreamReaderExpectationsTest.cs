using System.Text;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StreamReaderExpectations"/>.</para>
/// </summary>
public sealed class StreamReaderExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StreamReaderExpectations.Encoding(IExpectation{StreamReader}, Encoding)"/> method.</para>
  /// </summary>
  [Fact]
  public void Encoding_Method()
  {
    AssertionExtensions.Should(() => StreamReaderExpectations.Encoding(null, Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((StreamReader) null).Expect().Encoding(Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Attributes.RandomStream().ToStreamReader().TryFinallyDispose(reader =>
    {
      reader.Expect().Encoding(null).Result.Should().BeFalse();
      reader.Expect().Encoding(reader.CurrentEncoding).Result.Should().BeTrue();
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamReaderExpectations.End(IExpectation{StreamReader})"/> method.</para>
  /// </summary>
  [Fact]
  public void End_Method()
  {
    AssertionExtensions.Should(() => StreamReaderExpectations.End(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((StreamReader) null).Expect().End()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Stream.Null.ToStreamReader().TryFinallyDispose(reader => reader.Expect().End().Result.Should().BeTrue());

    Attributes.RandomStream().ToStreamReader().TryFinallyDispose(reader =>
    {
      reader.Expect().End().Result.Should().BeFalse();
      reader.ReadToEnd();
      reader.Expect().End().Result.Should().BeTrue();
    });
  }
}