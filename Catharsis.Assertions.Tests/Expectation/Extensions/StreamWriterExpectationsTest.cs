using System.Text;
using Catharsis.Extensions;
using FluentAssertions;
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
    AssertionExtensions.Should(() => StreamWriterExpectations.Encoding(null, Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((StreamWriter) null).Expect().Encoding(Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    RandomStream.ToStreamWriter().TryFinallyDispose(writer =>
    {
      writer.Expect().Encoding(null).Result.Should().BeFalse();
      writer.Expect().Encoding(writer.Encoding).Result.Should().BeTrue();
    });
  }
}