using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TextReaderAssertions"/>.</para>
/// </summary>
public sealed class TextReaderAssertionsTest : UnitTest
{
  private TextReader Reader { get; } = new StringReader(string.Empty);

  /// <summary>
  ///   <para>Performs testing of <see cref="TextReaderAssertions.End(IAssertion, TextReader, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void End_Method()
  {
    AssertionExtensions.Should(() => TextReaderAssertions.End(null, Reader)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => TextReaderAssertions.End(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("reader");

    Stream.Null.ToStreamReader().TryFinallyDispose(reader => Assert.To.End(reader).Should().NotBeNull().And.BeSameAs(Assert.To));
    RandomStream.ToStreamReader().TryFinallyDispose(reader =>
    {
      AssertionExtensions.Should(() => Assert.To.End(reader, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      reader.ReadToEnd();
      Assert.To.End(reader).Should().NotBeNull().And.BeSameAs(Assert.To);
    });

    new StringReader(string.Empty).TryFinallyDispose(reader => reader.Expect().End().Result.Should().BeTrue());
    new StringReader(RandomString).TryFinallyDispose(reader =>
    {
      AssertionExtensions.Should(() => Assert.To.End(reader, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      reader.ReadToEnd();
      Assert.To.End(reader).Should().NotBeNull().And.BeSameAs(Assert.To);
    });
  }

  public override void Dispose()
  {
    base.Dispose();
    Reader.Dispose();
  }
}