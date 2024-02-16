using Godot;
using Godot.Collections;
using System;

public abstract partial class BTBehaviourImpl : BehaviourToolkitImpl
{
    public virtual BTStatusEnum _Tick(float delta, Node actor, Dictionary blackboard) { return BTStatusEnum.Success; }
}
