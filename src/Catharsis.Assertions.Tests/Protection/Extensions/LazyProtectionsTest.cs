using FluentAssertions;
using Xunit;
using FluentAssertions.Execution;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="LazyProtections"/>.</para>
/// </summary>
public sealed class LazyProtectionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="LazyProtections.Null{T}(IProtection, Lazy{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Null_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => LazyProtections.Null(null, new Lazy<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

      Validate(true, new Lazy<object>(new object()));
      
      Validate(false, new Lazy<object>((object) null));
      Validate(false, new Lazy<object>());
    }

    return;

    static void Validate<T>(bool result, Lazy<T> instance)
    {
      if (result)
      {
        Protect.From.Null(instance).Should().BeOfType<Lazy<T>>().And.BeSameAs(instance);
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Null(instance, "error")).ThrowExactly<ArgumentNullException>().WithParameterName("error");
      }
    }
  }
}