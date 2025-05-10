using System.Text;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StreamWriterAssertions"/>.</para>
/// </summary>
public sealed class StreamWriterAssertionsTest : Test
{
  private StreamWriter Writer { get; } = Stream.Null.ToStreamWriter();

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamWriterAssertions.Encoding(IAssertion, StreamWriter, Encoding, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Encoding_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StreamWriterAssertions.Encoding(null, Writer, Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => StreamWriterAssertions.Encoding(Assert.To, null, Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("writer");

      Stream.Null.ToStreamWriter().With(writer => Test(true, writer, writer.Encoding));
      Test(false, Stream.Null.ToStreamWriter(), null);
    }

    return;

    static void Test(bool result, StreamWriter writer, Encoding encoding)
    {
      using (writer)
      {
        if (result)
        {
          Assert.To.Encoding(writer, encoding).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Encoding(writer, encoding, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }
}