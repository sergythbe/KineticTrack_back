using System;
using System.Collections.Generic;
using System.Text;

namespace KineticTrack.Domain.Entities;

public class Cabinet
{
    public Guid CabinetId { get; private set; }
    public string Name { get; private set; }
    public string Address { get; private set; }

    // Navigation
    public ICollection<CabinetMember> Members { get; private set; } = new List<CabinetMember>();

    private Cabinet() { } // EF Core

    public Cabinet(Guid cabinetId, string name, string address)
    {
        CabinetId = cabinetId;
        Name = name;
        Address = address;
    }
}
