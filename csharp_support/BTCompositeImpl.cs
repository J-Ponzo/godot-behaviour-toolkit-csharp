using Godot;
using Godot.Collections;
using System;

[GlobalClass]
public abstract partial class BTCompositeImpl : BTBehaviourImpl
{
    protected Array<GodotObject> leaves;

    protected override void _Init(GodotObject gdScript)
    {
        base._Init(gdScript);
        leaves = (Array<GodotObject>)gdScript.Get("leaves");
    }

    public virtual BTStatusEnum _TickChild(int childIdx, float delta, Node actor, Dictionary blackboard)
    {
        GodotObject leaf = leaves[childIdx];
        return (BTStatusEnum)(int)leaf.Call("tick_from_csharp", delta, actor, blackboard);
    }
}
