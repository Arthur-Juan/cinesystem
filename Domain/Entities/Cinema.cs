using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Cinema : Entity 
{
    public string? Name { get; set; }
    public List<Room>? Rooms { get; set; }

}

public class Room : Entity 
{
    public List<Session>? Sessions { get; set; }
    public int Number { get; set; }
    public List<Chair>? Chairs { get; set; }

}

public class Chair : Entity
{
    public int Number { get; set; }
}

public class Session : Entity 
{ 
    public Movie? Movie { get; set; }    
    public Interval? Interval { get; set; }
    public List<Ticket>? PossibleTickets { get; set; }
}


public class Ticket : Entity
{
    public decimal Price { get; set; }
    public Session? Session { get; set; }
    public User? UserOwn { get; set; }
    public Chair? Chair { get; set; }
}

public class  Interval 
{
    public TimeOnly? Start { get; set; }
    public TimeOnly? End { get; set; }
}

    
