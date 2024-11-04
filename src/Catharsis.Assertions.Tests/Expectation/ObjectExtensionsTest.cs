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
      Validate((object) null);
      Validate(new object());
    }

    return;

    static void Validate<T>(T subject)
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