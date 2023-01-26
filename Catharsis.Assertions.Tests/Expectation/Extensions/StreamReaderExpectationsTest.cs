using System.Text;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StreamReaderExpectations"/>.</para>
/// </summary>
public sealed class StreamReaderExpectationsTest : UnitTest
{
  private StreamReader Reader { get; } = Stream.Null.ToStreamReader();

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamReaderExpectations.Encoding(IExpectation{StreamReader}, Encoding)"/> method.</para>
  /// </summary>
  [Fact]
  public void Encoding_Method()
  {
    AssertionExtensions.Should(() => StreamReaderExpectations.Encoding(null, Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((StreamReader) null).Expect().Encoding(Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamReaderExpectations.End(IExpectation{StreamReader})"/> method.</para>
  /// </summary>
  [Fact]
  public void End_Method()
  {
    AssertionExtensions.Should(() => StreamReaderExpectations.End(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((StreamReader) null).Expect().End()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  public override void Dispose()
  {
    base.Dispose();
    Reader.Dispose();
  }
}