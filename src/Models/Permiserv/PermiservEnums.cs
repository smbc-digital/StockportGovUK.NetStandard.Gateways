public enum PermitType {
    Unknown,
    StandardPermit, 
    RelocationPermit, 
    GroupPermit, 
    RemoteDeliveryPermit
}

public enum PermitState {
    Unknown,
    ReadyToPrint, 
    Printed, 
    Packing, 
    Dispatched,
    Quarantined,
    Unscanned
}

public static class PermiserveEnumExtensions {
    
    public static string ToString(this PermitState permitType)
    {    
        switch(permitType)
        {
            case PermitState.ReadyToPrint:
                return "Ready To Print";
            case PermitState.Printed:
                return "Printed";
            case PermitState.Packing:
                return "Packing";
            case PermitState.Dispatched:
                return "Dispatched";
            case PermitState.Quarantined:
                return "Quarantined";
            case PermitState.Unscanned :
                return "Unscanned";
            default:
                return string.Empty;
        }
    }
    public static string ToString(this PermitType permitType)
    {    
        switch(permitType)
        {
            case PermitType.StandardPermit:
                return "Standard Permit";
            case PermitType.RelocationPermit:
                return "Relocation Permit";
            case PermitType.GroupPermit:
                return "Group Permit";
            case PermitType.RemoteDeliveryPermit:
                return "RemoteDeliveryPermit";
            default:
                return string.Empty;
        }
    }
}