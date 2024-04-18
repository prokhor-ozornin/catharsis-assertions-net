using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TextReaderAssertions.End(null, Reader)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => TextReaderAssertions.End(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("reader");

      Attributes.RandomStream().ToStreamReader().TryFinallyDispose(reader =>
      {
        AssertionExtensions.Should(() => Assert.To.End(reader, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        reader.ReadToEnd();
        Assert.To.End(reader).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      });

      new StringReader(string.Empty).TryFinallyDispose(reader => reader.Expect().End().Result.Should().BeTrue());
      new StringReader(Attributes.RandomString()).TryFinallyDispose(reader =>
      {
        AssertionExtensions.Should(() => Assert.To.End(reader, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        reader.ReadToEnd();
        Assert.To.End(reader).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      });
    }

    return;

    static void Validate(bool result, TextReader reader)
    {
      using (reader)
      {
        if (result)
        {
          Assert.To.End(reader).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.End(reader, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }

  public override void Dispose()
  {
    base.Dispose();
    Reader.Dispose();
  }
}