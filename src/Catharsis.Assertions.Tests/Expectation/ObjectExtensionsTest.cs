using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ObjectExtensions"/>.</para>
/// </summary>
/// <seealso cref="ObjectExtensions"/>
public sealed class ObjectExtensionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectExtensions.Expect{T}(T)"/> method.</para>
  /// </summary>
  [Fact]
  public void Expect_Method()
  {
    using (new AssertionScope())
    {
      Test<object>(null);
      Test(new object());
    }

    return;

    static void Test<T>(T subject)
    {
      var expectation = subject.Expect();

      expectation.Should().BeOfType<Expectation<T>>();
      expectation.GetFieldValue<bool>("state").Should().BeTrue();

      if (subject is not null)
      {
        expectation.GetFieldValue<object>("subject").Should().BeOfType<T>().And.BeSameAs(subject);
      }
      else
      {
        expectation.GetFieldValue<object>("subject").Should().BeNull();
      }
    }
  }
}