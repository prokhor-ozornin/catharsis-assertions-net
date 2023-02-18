using System.Security;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="SecureStringProtections"/>.</para>
/// </summary>
public sealed class SecureStringProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="SecureStringProtections.Empty(IProtection, SecureString, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => Protect.From.Empty((SecureString) null)).ThrowExactly<ArgumentNullException>().WithParameterName("secure");

    new SecureString().TryFinallyDispose(secure => AssertionExtensions.Should(() => Protect.From.Empty(secure, "error")).ThrowExactly<ArgumentException>().WithMessage("error"));
    
    new SecureString().TryFinallyDispose(secure =>
    {
      AssertionExtensions.Should(() => SecureStringProtections.Empty(null, secure)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

      secure.AppendChar(char.MinValue);
      Protect.From.Empty(secure).Should().NotBeNull().And.BeSameAs(secure);
    }); 
  }
}