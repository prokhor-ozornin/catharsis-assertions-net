using System.Globalization;
using System.Text;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests.Expectation.Extensions;

/// <summary>
///   <para>Tests set for class <see cref="StreamWriterExpectations"/>.</para>
/// </summary>
public sealed class StreamWriterExpectationsTest : UnitTest
{
  private StreamWriter Writer { get; } = Stream.Null.ToStreamWriter();

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamWriterExpectations.Encoding(IExpectation{StreamWriter}, Encoding)"/> method.</para>
  /// </summary>
  [Fact]
  public void Encoding_Method()
  {
    AssertionExtensions.Should(() => StreamWriterExpectations.Encoding(null, Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((StreamWriter) null).Expect().Encoding(Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamWriterExpectations.Format(IExpectation{StreamWriter}, IFormatProvider)"/> method.</para>
  /// </summary>
  [Fact]
  public void Format_Method()
  {
    AssertionExtensions.Should(() => StreamWriterExpectations.Format(null, CultureInfo.CurrentCulture)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((StreamWriter) null).Expect().Format(CultureInfo.CurrentCulture)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  public override void Dispose()
  {
    base.Dispose();
    Writer.Dispose();
  }
}