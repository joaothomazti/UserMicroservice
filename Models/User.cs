using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public int id { get; set; }

    public string? name { get; set; }

    [EmailAddress]
    public string? email { get; set; }
}