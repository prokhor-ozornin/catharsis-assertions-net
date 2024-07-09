using System.Security.Cryptography;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for <see cref="SymmetricAlgorithm"/> type.</para>
/// </summary>
/// <seealso cref="SymmetricAlgorithm"/>
public static class SymmetricAlgorithmExpectations
{
  /// <summary>
  ///   <para>Expects that a given algorithm has a specified block size in bits of cryptographic operations.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="size">Expected block size in bits.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<SymmetricAlgorithm> BlockSize(this IExpectation<SymmetricAlgorithm> expectation, int size) => expectation.HaveSubject().And().Expected(algorithm => algorithm.BlockSize == size);

  /// <summary>
  ///   <para>Expects that a given algorithm has a specified size in bits of the secret key.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="size">Expected key size in bits.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<SymmetricAlgorithm> KeySize(this IExpectation<SymmetricAlgorithm> expectation, int size) => expectation.HaveSubject().And().Expected(algorithm => algorithm.KeySize == size);
}