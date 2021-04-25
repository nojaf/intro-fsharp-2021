using System.Collections.Generic;
using System.Linq;

public class Conference
{
    public string Name { get; }
    public bool IsActive { get; }
    public double TicketPrice { get; }

    public Conference(string name, bool isActive, double ticketPrice)
    {
        Name = name;
        IsActive = isActive;
        TicketPrice = ticketPrice;
    }
}

public class ConferenceInfo
{
    private Conference[] _conferences  = new[]
    {
        new Conference("Techorama", true, 500),
        new Conference("BuildStuff", false, 600),
        new Conference("NDC London", true, 1000),
    };

    public void Imperative()
    {
        var activeConferences = new List<Conference>(_conferences.Length);
        foreach (var conference in _conferences)
        {
            if (conference.IsActive)
            {
                activeConferences.Add(conference);
            }
        }

        var sum = 0.0;
        foreach (var activeConference in _conferences)
        {
            sum += activeConference.TicketPrice;
        }

        var average = sum / activeConferences.Count;
    }

    public void Declarative()
    {
        var average = _conferences.Where(c => c.IsActive).Average(c => c.TicketPrice);
    }
}
