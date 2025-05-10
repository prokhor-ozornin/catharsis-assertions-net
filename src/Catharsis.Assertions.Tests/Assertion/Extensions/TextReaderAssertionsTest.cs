using AutoFixture;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TextReaderAssertions"/>.</para>
/// </summary>
public sealed class TextReaderAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TextReaderAssertions.End(IAssertion, TextReader, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void End_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TextReaderAssertions.End(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("reader");

      Test(true, Stream.Null.ToStreamReader());

      Fixture.Create<string>().ToStringReader().With(reader =>
      {
        reader.ReadToEnd();
        Test(true, reader);
      });

      Test(true, string.Empty.ToStringReader());

      Fixture.Create<string>().ToStringReader().With(reader =>
      {
        reader.ReadToEnd();
        Test(true, reader);
      });
    }

    return;

    static void Test(bool result, TextReader reader)
    {
      AssertionExtensions.Should(() => TextReaderAssertions.End(null, reader)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

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
}