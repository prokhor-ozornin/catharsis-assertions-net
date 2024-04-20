using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ObjectExtensions"/>.</para>
/// </summary>
public sealed class ObjectExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectExtensions.Expect{T}(T)"/> method.</para>
  /// </summary>
  [Fact]
  public void Expect_Method()
  {
    using (new AssertionScope())
    {
      object subject = null;
      var expectation = subject.Expect();
      
      expectation.Should().NotBeNull().Should().BeOfType<Expectation<object>>().And.NotBeSameAs(subject.Expect());
      expectation.GetFieldValue<object>("subject").Should().BeOfType<object>().And.BeSameAs(subject);
    }

    return;

    static void Validate()
    {

    }
  }
}