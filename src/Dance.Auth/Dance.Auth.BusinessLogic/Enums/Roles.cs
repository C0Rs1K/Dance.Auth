using System.ComponentModel;

namespace Dance.Auth.BusinessLogic.Enums;

public enum Roles
{
    [Description("User")]
    User,
    [Description("Admin")]
    Admin,
    [Description("Trainer")]
    Trainer
}