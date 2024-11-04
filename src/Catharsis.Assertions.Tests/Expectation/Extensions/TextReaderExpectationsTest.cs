using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TextReaderExpectations.End(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((TextReader) null).Expect().End()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, Stream.Null.ToStreamReader());

      Attributes.RandomString().ToStringReader().With(reader =>
      {
        reader.ReadToEnd();
        Validate(true, reader);
      });

      Validate(true, string.Empty.ToStringReader());

      Attributes.RandomString().ToStringReader().With(reader =>
      {
        reader.ReadToEnd();
        Validate(true, reader);
      });
    }

    return;

    static void Validate(bool result, TextReader reader)
    {
      using (reader)
      {
        reader.Expect().End().Should().BeOfType<Expectation<TextReader>>().Which.Result.Should().Be(result);
      }
    }
  }
}