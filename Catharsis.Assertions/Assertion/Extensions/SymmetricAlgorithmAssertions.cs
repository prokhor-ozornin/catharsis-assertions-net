using System.Security.Cryptography;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="SymmetricAlgorithm"/> type.</para>
/// </summary>
/// <seealso cref="SymmetricAlgorithm"/>
public static class SymmetricAlgorithmAssertions
{
  /// <summary>
  ///   <para>Asserts that a given algorithm has a specified block size in bits of cryptographic operations.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="algorithm">Cryptographic algorithm to inspect.</param>
  /// <param name="size">Block size in bits.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="algorithm"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion BlockSize(this IAssertion assertion, SymmetricAlgorithm algorithm, int size, string error = null) => algorithm is not null ? assertion.True(algorithm.BlockSize == size, error) : throw new ArgumentNullException(nameof(algorithm));

  /// <summary>
  ///   <para>Asserts that a given algorithm has a specified size in bits of the secret key.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="algorithm">Cryptographic algorithm to inspect.</param>
  /// <param name="size">Key size in bits.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="algorithm"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion KeySize(this IAssertion assertion, SymmetricAlgorithm algorithm, int size, string error = null) => algorithm is not null ? assertion.True(algorithm.KeySize == size, error) : throw new ArgumentNullException(nameof(algorithm));
}