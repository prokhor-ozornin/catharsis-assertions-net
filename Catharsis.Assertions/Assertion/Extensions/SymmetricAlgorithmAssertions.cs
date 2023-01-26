using System.Security.Cryptography;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="SymmetricAlgorithm"/>
public static class SymmetricAlgorithmAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="algorithm"></param>
  /// <param name="size"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion BlockSize(this IAssertion assertion, SymmetricAlgorithm algorithm, int size, string message = null) => algorithm is not null ? assertion.True(algorithm.BlockSize == size, message) : throw new ArgumentNullException(nameof(algorithm));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="algorithm"></param>
  /// <param name="size"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion KeySize(this IAssertion assertion, SymmetricAlgorithm algorithm, int size, string message = null) => algorithm is not null ? assertion.True(algorithm.KeySize == size, message) : throw new ArgumentNullException(nameof(algorithm));
}