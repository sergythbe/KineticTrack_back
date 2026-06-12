using System;
using System.Collections.Generic;
using System.Text;

namespace KineticTrack.Application.DTOs.Requests;

public class ChangePasswordRequest
{
    public string CurrentPassword { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
    public string ConfirmNewPassword { get; set; } = string.Empty;
}
