using Godot;
using Godot.Collections;
using System;

[GlobalClass]
public partial class BTLeafImpl : Resource
{
    public BTStatusEnum _Tick(float delta, Node actor, Dictionary blackboard) { return BTStatusEnum.Success; }
}
