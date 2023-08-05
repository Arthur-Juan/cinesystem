using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Movie : Entity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public TimeSpan? Duration { get; set; }
    public List<Category>? Categories { get; set; }
    public float Stars { get; set; }
}

public class Category : Entity
{
    public string? Name { get; set; }
    public List<Movie>? Movies { get; set; }
}
