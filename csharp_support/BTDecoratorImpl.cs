using Godot;
using Godot.Collections;
using System;

[GlobalClass]
public abstract partial class BTDecoratorImpl : BTBehaviourImpl
{
    protected GodotObject leaf;

    protected override void _Init(GodotObject gdScript)
    {
        base._Init(gdScript);
        leaf = (GodotObject)gdScript.Get("leaf");
    }

    public virtual BTStatusEnum _TickChild(float delta, Node actor, Dictionary blackboard) 
    {
        return (BTStatusEnum)(int) leaf.Call("tick_from_csharp", delta, actor, blackboard);
    }
}
