namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of protections for <see cref="Task"/> types.</para>
/// </summary>
/// <seealso cref="Task"/>
/// <seealso cref="Task{TResult}"/>
public static class TaskProtections
{
  /// <summary>
  ///   <para>Protects the given <see cref="Task"/> from being in a specific stage, ensuring that it doesn't have the specified status.</para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="task">Task to protect.</param>
  /// <param name="status">Task status.</param>
  /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="task"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  /// <seealso cref="Status{T}(IProtection, Task{T}, TaskStatus, string)"/>
  public static Task Status(this IProtection protection, Task task, TaskStatus status, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (task is null) throw new ArgumentNullException(nameof(task));

    protection.Truth(task.Status == status, error);
    
    return task;
  }

  /// <summary>
  ///   <para>Protects the given <see cref="Task"/> from being in a specific stage, ensuring that it doesn't have the specified status.</para>
  /// </summary>
  /// <typeparam name="T">Type of task result.</typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="task">Task to protect.</param>
  /// <param name="status">Task status.</param>
  /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="task"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  /// <see cref="Status(IProtection, Task, TaskStatus, string)"/>
  public static Task<T> Status<T>(this IProtection protection, Task<T> task, TaskStatus status, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (task is null) throw new ArgumentNullException(nameof(task));

    protection.Truth(task.Status == status, error);

    return task;
  }
}