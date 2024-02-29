using Godot;
using Godot.Collections;
using System;

public class BTToolkitUtils
{
    private const string GDSCRIPT_FSM_CLASS_NAME = "FiniteStateMachine";
    private const string GDSCRIPT_BTROOT_CLASS_NAME = "BTRoot";

    public static bool IsActive(Node node)
    {
        if (!(node.GetScript().Obj is GDScript))
        {
            GD.PrintErr("BTToolkitUtils.IsActive(" + node + ") failed because " + node + " script is not a GDScript. (false will be returned but should not be trusted)");
            return false;
        }

        GDScript script = (GDScript)node.GetScript().Obj;
        if (script.GetGlobalName() != GDSCRIPT_FSM_CLASS_NAME
            && script.GetGlobalName() != GDSCRIPT_BTROOT_CLASS_NAME) {
            GD.PrintErr("BTToolkitUtils.IsActive(" + node + ") failed because " + node + " script is neither a " + GDSCRIPT_FSM_CLASS_NAME + " nor a " + GDSCRIPT_BTROOT_CLASS_NAME + "(false will be returned but should not be trusted)");
            return false;
        }

        return (bool)node.Get("active");
    }

    public static bool SetActive(Node node, bool active)
    {
        if (!(node.GetScript().Obj is GDScript))
        {
            GD.PrintErr("BTToolkitUtils.SetActive(" + node + ", " + active + ") failed because " + node + " script is not a GDScript");
            return false;
        }

        GDScript script = (GDScript)node.GetScript().Obj;
        if (script.GetGlobalName() == GDSCRIPT_FSM_CLASS_NAME) return SetFSMActive(node, active);
        else if (script.GetGlobalName() == GDSCRIPT_BTROOT_CLASS_NAME) return SetBTActive(node, active);

        GD.PrintErr("BTToolkitUtils.SetActive(" + node + ") failed because " + node + " script is neither a " + GDSCRIPT_FSM_CLASS_NAME + " nor a " + GDSCRIPT_BTROOT_CLASS_NAME);
        return false;
    }

    private static bool SetBTActive(Node btRoot, bool active)
    {
        bool isActive = (bool)btRoot.Get("active");

        if (isActive == active)
        {
            GD.PrintErr("BTToolkitUtils.SetBTActive(" + btRoot + ", " + active + ") failed because " + btRoot + " was already active = " + active);
            return false;
        }

        btRoot.Set("active", true);
        return true;
    }

    private static bool SetFSMActive(Node fsm, bool active)
    {
        bool isActive = (bool)fsm.Get("active");

        if (isActive == active)
        {
            GD.PrintErr("BTToolkitUtils.SetFSMActive(" + fsm + ", " + active + ") failed because " + fsm + " was already active = " + active);
            return false;
        }

        if (active == true) fsm.Call("start");
        else fsm.Set("active", false);

        return true;
    }

    public static Variant GetBlackboardValue(Node node, StringName key)
    {
        if (!(node.GetScript().Obj is GDScript))
        {
            GD.PrintErr("BTToolkitUtils.GetBlackboardValue(" + node + ", " + key + ") failed because " + node + " script is not a GDScript. (default(Variant) will be returned but should not be trusted)");
            return default(Variant);
        }

        GDScript script = (GDScript)node.GetScript().Obj;
        if (script.GetGlobalName() != GDSCRIPT_FSM_CLASS_NAME
            && script.GetGlobalName() != GDSCRIPT_BTROOT_CLASS_NAME)
        {
            GD.PrintErr("BTToolkitUtils.GetBlackboardValue(" + node + ", " + key + ") failed because " + node + " script is neither a " + GDSCRIPT_FSM_CLASS_NAME + " nor a " + GDSCRIPT_BTROOT_CLASS_NAME + "(default(Variant) will be returned but should not be trusted)");
            return default(Variant);
        }

        Dictionary blackboard = (Dictionary)node.Call("get_blackboard_from_csharp");
        return blackboard[key];
    }

    public static bool SetBlackboardValue(Node node, StringName key, Variant value)
    {
        if (!(node.GetScript().Obj is GDScript))
        {
            GD.PrintErr("BTToolkitUtils.GetBlackboardValue(" + node + ", " + key + ") failed because " + node + " script is not a GDScript.");
            return false;
        }

        GDScript script = (GDScript)node.GetScript().Obj;
        if (script.GetGlobalName() != GDSCRIPT_FSM_CLASS_NAME
            && script.GetGlobalName() != GDSCRIPT_BTROOT_CLASS_NAME)
        {
            GD.PrintErr("BTToolkitUtils.GetBlackboardValue(" + node + ", " + key + ") failed because " + node + " script is neither a " + GDSCRIPT_FSM_CLASS_NAME + " nor a " + GDSCRIPT_BTROOT_CLASS_NAME);
            return false;
        }

        Dictionary blackboard = (Dictionary)node.Call("get_blackboard_from_csharp");
        blackboard[key] = value;

        node.Call("set_blackboard_from_csharp", blackboard);
        return true;
    }
}
