using Godot;
using Godot.Collections;
using System;

[GlobalClass]
public partial class FSMTransition_CS : Node
{
    public virtual void _OnTransition(float delta, Node actor, Dictionary blackboard) { GD.Print("_OnTransition()"); }
    public virtual bool _IsValid(Node actor, Dictionary blackboard) { return false; }
}
