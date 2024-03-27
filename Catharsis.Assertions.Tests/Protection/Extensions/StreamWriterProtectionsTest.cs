using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StreamWriterProtections"/>.</para>
/// </summary>
public sealed class StreamWriterProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StreamWriterProtections.Empty(IProtection, StreamWriter, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    Stream.Null.ToStreamWriter().TryFinallyDispose(writer => AssertionExtensions.Should(() => StreamWriterProtections.Empty(null, writer)).ThrowExactly<ArgumentNullException>().WithParameterName("protection"));
    AssertionExtensions.Should(() => Protect.From.Empty((StreamWriter) null)).ThrowExactly<ArgumentNullException>().WithParameterName("writer");

    Stream.Null.ToStreamWriter().TryFinallyDispose(writer => AssertionExtensions.Should(() => Protect.From.Empty(writer, "error")).ThrowExactly<ArgumentException>().WithMessage("error"));
    Attributes.RandomStream().ToStreamWriter().TryFinallyDispose(writer => Protect.From.Empty(writer).Should().BeOfType<StreamWriter>().And.BeSameAs(writer));
  }
}