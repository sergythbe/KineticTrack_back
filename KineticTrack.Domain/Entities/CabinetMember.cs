using KineticTrack.Domain.Enums;

namespace KineticTrack.Domain.Entities;

public class CabinetMember
{
    public Guid UserId { get; private set; }
    public Guid CabinetId { get; private set; }
    public CabinetRole RoleAtCabinet { get; private set; }
    public bool IsOwner { get; private set; }

    // Navigation
    public User User { get; private set; } = null!;
    public Cabinet Cabinet { get; private set; } = null!;

    private CabinetMember() { } // EF Core

    public CabinetMember(Guid userId, Guid cabinetId, CabinetRole role, bool isOwner = false)
    {
        UserId = userId;
        CabinetId = cabinetId;
        RoleAtCabinet = role;
        IsOwner = isOwner;
    }
}