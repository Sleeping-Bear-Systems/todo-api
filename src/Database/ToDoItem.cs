using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SleepingBear.ToDo.Database;

/// <summary>
/// To-Do item model.
/// </summary>
[Table("todo-items")]
public sealed class ToDoItem
{
    /// <summary>
    /// ID.
    /// </summary>
    [Key, Column("id")]
    public Guid Id { get; set; }

    /// <summary>
    /// Name.
    /// </summary>
    [Required, Column("name"), MaxLength(128)]
    public string Name { get; set; } = string.Empty;
}