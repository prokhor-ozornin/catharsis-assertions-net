using System.Text;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StreamReaderExpectations.Encoding(null, Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((StreamReader) null).Expect().Encoding(Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Stream.Null.ToStreamReader().With(reader => Validate(true, reader, reader.CurrentEncoding));
      Validate(false, Stream.Null.ToStreamReader(), null);
    }

    return;

    static void Validate(bool result, StreamReader reader, Encoding encoding)
    {
      using (reader)
      {
        reader.Expect().Encoding(encoding).Should().BeOfType<Expectation<StreamReader>>().Which.Result.Should().Be(result);
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamReaderExpectations.End(IExpectation{StreamReader})"/> method.</para>
  /// </summary>
  [Fact]
  public void End_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StreamReaderExpectations.End(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((StreamReader) null).Expect().End()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, Stream.Null.ToStreamReader());
      Validate(true, Attributes.Random().MemoryStream(short.MaxValue).ToStreamReader().With(reader => reader.ReadToEnd()));
      Validate(false, Attributes.Random().MemoryStream(short.MaxValue).ToStreamReader());
    }

    return;

    static void Validate(bool result, StreamReader reader)
    {
      using (reader)
      {
        reader.Expect().End().Should().BeOfType<Expectation<StreamReader>>().Which.Result.Should().Be(result);
      }
    }
  }
}