using System.Globalization;
using System.Text;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StreamWriterAssertions"/>.</para>
/// </summary>
public sealed class StreamWriterAssertionsTest : UnitTest
{
  private StreamWriter Writer { get; } = Stream.Null.ToStreamWriter();

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamWriterAssertions.Encoding(IAssertion, System.IO.StreamWriter, Encoding, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Encoding_Method()
  {
    AssertionExtensions.Should(() => StreamWriterAssertions.Encoding(null, Writer, Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => StreamWriterAssertions.Encoding(Assert.To, null, Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("writer");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamWriterAssertions.Format(IAssertion, System.IO.StreamWriter, IFormatProvider, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Format_Method()
  {
    AssertionExtensions.Should(() => StreamWriterAssertions.Format(null, Writer, CultureInfo.CurrentCulture)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Format(null, CultureInfo.CurrentCulture)).ThrowExactly<ArgumentNullException>().WithParameterName("writer");

    throw new NotImplementedException();
  }

  public override void Dispose()
  {
    base.Dispose();
    Writer.Dispose();
  }
}