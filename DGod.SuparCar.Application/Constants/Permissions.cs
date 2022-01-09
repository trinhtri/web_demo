using DGod.SuparCar.Application.Enums;

namespace DGod.SuparCar.Application.Constants
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsForModule(string module)
        {
            return new List<string>()
            {
                $"Permissions.{module}.{PermissionTypes.Create.ToString()}",
                $"Permissions.{module}.{PermissionTypes.View.ToString()}",
                $"Permissions.{module}.{PermissionTypes.Edit.ToString()}",
                $"Permissions.{module}.{PermissionTypes.Delete.ToString()}",
            };
        }
    }
}