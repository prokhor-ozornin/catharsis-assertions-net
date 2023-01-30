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
  /// <summary>
  ///   <para>Performs testing of <see cref="TextProtections.Empty(IProtection, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_String_Method()
  {
    AssertionExtensions.Should(() => TextProtections.Empty(null, string.Empty)) .ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    AssertionExtensions.Should(() => Protect.From.Empty((string) null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Protect.From.Empty(string.Empty, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    
    RandomString.With(text => Protect.From.Empty(text).Should().NotBeNull().And.BeSameAs(text));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TextProtections.Empty(IProtection, StringBuilder, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_StringBuilder_Method()
  {
    AssertionExtensions.Should(() => TextProtections.Empty(null, new StringBuilder())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((StringBuilder) null, "error")).ThrowExactly<ArgumentNullException>().WithParameterName("error");

    new StringBuilder().With(builder => AssertionExtensions.Should(() => Protect.From.Empty(builder, "error")).ThrowExactly<ArgumentException>().WithMessage("error"));
    new StringBuilder(RandomString).With(builder => Protect.From.Empty(builder).Should().NotBeNull().And.BeSameAs(builder));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TextProtections.Empty(IProtection, SecureString, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_SecureString_Method()
  {
    AssertionExtensions.Should(() => TextProtections.Empty(null, EmptySecureString)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((SecureString) null, "error")).ThrowExactly<ArgumentNullException>().WithParameterName("error");

    new SecureString().TryFinallyDispose(secure => AssertionExtensions.Should(() => Protect.From.Empty(secure, "error")).ThrowExactly<ArgumentException>().WithMessage("error"));
    
    new SecureString().TryFinallyDispose(secure =>
    {
      secure.AppendChar(char.MinValue);
      Protect.From.Empty(secure).Should().NotBeNull().And.BeSameAs(secure);
    }); 
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TextProtections.Empty(IProtection, StreamReader, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_StreamReader_Method()
  {
    Stream.Null.ToStreamReader().TryFinallyDispose(reader => AssertionExtensions.Should(() => TextProtections.Empty(null, reader)).ThrowExactly<ArgumentNullException>().WithParameterName("protection"));
    AssertionExtensions.Should(() => Protect.From.Empty((StreamReader) null)).ThrowExactly<ArgumentNullException>().WithParameterName("reader");
    
    void Validate(StreamReader reader)
    {
      AssertionExtensions.Should(() => Protect.From.Empty(reader.BaseStream.Empty(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      
      reader.BaseStream.WriteByte(byte.MinValue);
      
    }




    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TextProtections.Empty(IProtection, StreamWriter, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_StreamWriter_Method()
  {
    Stream.Null.ToStreamWriter().TryFinallyDispose(writer => AssertionExtensions.Should(() => TextProtections.Empty(null, writer)).ThrowExactly<ArgumentNullException>().WithParameterName("protection"));
    AssertionExtensions.Should(() => Protect.From.Empty((StreamWriter) null, "error")).ThrowExactly<ArgumentNullException>().WithParameterName("error");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TextProtections.WhiteSpace(IProtection, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void WhiteSpace_String_Method()
  {
    AssertionExtensions.Should(() => TextProtections.WhiteSpace(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    AssertionExtensions.Should(() => Protect.From.WhiteSpace(null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Protect.From.WhiteSpace(string.Empty, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Protect.From.WhiteSpace("\r\n\t", "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    RandomString.With(text => Protect.From.Empty(text).Should().NotBeNull().And.BeSameAs(text));
  }
}