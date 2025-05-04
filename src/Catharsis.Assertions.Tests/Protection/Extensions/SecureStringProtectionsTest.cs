using System.Security;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="SecureStringProtections"/>.</para>
/// </summary>
public sealed class SecureStringProtectionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="SecureStringProtections.Empty(IProtection, SecureString, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => Protect.From.Empty((SecureString) null)).ThrowExactly<ArgumentNullException>().WithParameterName("secure");

      Validate(true, new SecureString().With(char.MinValue));
      Validate(false, new SecureString());
    }

    return;

    static void Validate(bool result, SecureString secure)
    {
      using (secure)
      {
        if (result)
        {
          Protect.From.Empty(secure).Should().BeOfType<SecureString>().And.BeSameAs(secure);
        }
        else
        {
          AssertionExtensions.Should(() => Protect.From.Empty(secure, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
        }
      }
    }
  }
}