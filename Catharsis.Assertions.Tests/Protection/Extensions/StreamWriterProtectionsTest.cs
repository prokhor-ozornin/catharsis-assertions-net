using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
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
    using (new AssertionScope())
    {
      Stream.Null.ToStreamWriter().TryFinallyDispose(writer => AssertionExtensions.Should(() => StreamWriterProtections.Empty(null, writer)).ThrowExactly<ArgumentNullException>().WithParameterName("protection"));
      AssertionExtensions.Should(() => Protect.From.Empty((StreamWriter) null)).ThrowExactly<ArgumentNullException>().WithParameterName("writer");

      Validate(true, Attributes.RandomStream().ToStreamWriter());
      Validate(false, Stream.Null.ToStreamWriter());
    }

    return;

    static void Validate(bool result, StreamWriter writer)
    {
      using (writer)
      {
        if (result)
        {
          Protect.From.Empty(writer).Should().BeOfType<StreamWriter>().And.BeSameAs(writer);
        }
        else
        {
          AssertionExtensions.Should(() => Protect.From.Empty(writer, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
        }
      }
    }
  }
}