using Godot;
using Godot.Collections;
using System;

[GlobalClass]
public partial class BTLeaf_CS : Node
{
    public virtual BTStatusEnum _Tick(float delta, Node actor, Dictionary blackboard) { GD.Print("_Tick()"); return BTStatusEnum.SUCCESS; }
}
