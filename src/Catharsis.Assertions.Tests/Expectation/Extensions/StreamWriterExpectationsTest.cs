using System.Text;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StreamWriterExpectations"/>.</para>
/// </summary>
public sealed class StreamWriterExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StreamWriterExpectations.Encoding(IExpectation{StreamWriter}, Encoding)"/> method.</para>
  /// </summary>
  [Fact]
  public void Encoding_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StreamWriterExpectations.Encoding(null, Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((StreamWriter) null).Expect().Encoding(Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Stream.Null.ToStreamWriter().With(writer => Validate(true, writer, writer.Encoding));
      Validate(false, Stream.Null.ToStreamWriter(), null);
    }

    return;

    static void Validate(bool result, StreamWriter writer, Encoding encoding)
    {
      using (writer)
      {
        writer.Expect().Encoding(encoding).Should().BeOfType<Expectation<StreamWriter>>().Which.Result.Should().Be(result);
      }
    }
  }
}