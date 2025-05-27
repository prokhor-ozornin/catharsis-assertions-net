using System.Text;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StreamReaderAssertions"/>.</para>
/// </summary>
public sealed class StreamReaderAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StreamReaderAssertions.Encoding(IAssertion, StreamReader, Encoding, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Encoding_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StreamReaderAssertions.Encoding(Assert.To, null, Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("reader");

      Stream.Null.ToStreamReader().With(reader => Test(true, reader, reader.CurrentEncoding));
      Test(false, Stream.Null.ToStreamReader(), null);
    }

    return;

    static void Test(bool result, StreamReader reader, Encoding encoding)
    {
      using (reader)
      {
        AssertionExtensions.Should(() => StreamReaderAssertions.Encoding(null, reader, Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

        if (result)
        {
          Assert.To.Encoding(reader, encoding).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Encoding(reader, encoding, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamReaderAssertions.End(IAssertion, StreamReader, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void End_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => Assert.To.End((StreamReader) null)).ThrowExactly<ArgumentNullException>().WithParameterName("reader");

      Test(true, Stream.Null.ToStreamReader());
      Test(true, Random.MemoryStream(short.MaxValue).ToStreamReader().With(reader => reader.ReadToEnd()));
      Test(false, Random.MemoryStream(short.MaxValue).ToStreamReader());
    }

    return;

    static void Test(bool result, StreamReader reader)
    {
      using (reader)
      {
        AssertionExtensions.Should(() => StreamReaderAssertions.End(null, reader)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

        if (result)
        {
          Assert.To.End(reader).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.End(reader, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }
}