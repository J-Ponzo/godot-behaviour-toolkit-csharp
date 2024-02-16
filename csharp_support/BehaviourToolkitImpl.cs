using Godot;
using System;

public abstract partial class BehaviourToolkitImpl : Resource
{
    protected GodotObject gdScript = null;

    protected virtual void _Init(GodotObject gdScript)
    {
        this.gdScript = gdScript;
    }
}
