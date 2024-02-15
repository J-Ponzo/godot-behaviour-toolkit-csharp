using Godot;
using Godot.Collections;
using System;

[GlobalClass]
public abstract partial class BTLeafImpl : Resource
{
    public virtual BTStatusEnum _Tick(float delta, Node actor, Dictionary blackboard) { return BTStatusEnum.Success; }
}
