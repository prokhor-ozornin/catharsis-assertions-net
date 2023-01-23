using System.Security;
using System.Text;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TextProtections"/>.</para>
/// </summary>
public sealed class TextProtectionsTest : UnitTest
{
  private SecureString SecureString { get; } = new();
  private StreamReader StreamReader { get; } = Stream.Null.ToStreamReader();
  protected StreamWriter StreamWriter { get; } = Stream.Null.ToStreamWriter();

  /// <summary>
  ///   <para>Performs testing of <see cref="TextProtections.Empty(IProtection, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_String_Method()
  {
    AssertionExtensions.Should(() => TextProtections.Empty(null, string.Empty)) .ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((string) null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TextProtections.Empty(IProtection, StringBuilder, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_StringBuilder_Method()
  {
    AssertionExtensions.Should(() => TextProtections.Empty(null, new StringBuilder())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((StringBuilder) null)).ThrowExactly<ArgumentNullException>().WithParameterName("builder");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TextProtections.Empty(IProtection, System.Security.SecureString, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_SecureString_Method()
  {
    AssertionExtensions.Should(() => TextProtections.Empty(null, SecureString)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((SecureString) null)).ThrowExactly<ArgumentNullException>().WithParameterName("secure");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TextProtections.Empty(IProtection, System.IO.StreamReader, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_StreamReader_Method()
  {
    AssertionExtensions.Should(() => TextProtections.Empty(null, StreamReader)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((StreamReader) null)).ThrowExactly<ArgumentNullException>().WithParameterName("reader");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TextProtections.Empty(IProtection, System.IO.StreamWriter, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_StreamWriter_Method()
  {
    AssertionExtensions.Should(() => TextProtections.Empty(null, StreamWriter)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((StreamWriter) null)).ThrowExactly<ArgumentNullException>().WithParameterName("writer");

    throw new NotImplementedException();
  }

  public override void Dispose()
  {
    base.Dispose();
    SecureString.Dispose();
    StreamReader.Dispose();
    StreamWriter.Dispose();
  }
}