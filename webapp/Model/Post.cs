using System;
using System.ComponentModel.DataAnnotations;

public class Post
{
    public int id { get; set; }

    [Required]
    public string title { get; set; }

    [Required]
    public string body { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }
}