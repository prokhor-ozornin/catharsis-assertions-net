using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TextReaderExpectations"/>.</para>
/// </summary>
public sealed class TextReaderExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TextReaderExpectations.End(IExpectation{TextReader})"/> method.</para>
  /// </summary>
  [Fact]
  public void End_Method()
  {
    AssertionExtensions.Should(() => TextReaderExpectations.End(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((TextReader) null).Expect().End()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Stream.Null.ToStreamReader().TryFinallyDispose(reader => reader.Expect().End().Result.Should().BeTrue());
    RandomStream.ToStreamReader().TryFinallyDispose(reader =>
    {
      reader.Expect().End().Result.Should().BeFalse();
      reader.ReadToEnd();
      reader.Expect().End().Result.Should().BeTrue();
    });
    
    new StringReader(string.Empty).TryFinallyDispose(reader => reader.Expect().End().Result.Should().BeTrue());
    new StringReader(RandomString).TryFinallyDispose(reader =>
    {
      reader.Expect().End().Result.Should().BeFalse();
      reader.ReadToEnd();
      reader.Expect().End().Result.Should().BeTrue();
    });
  }
}