using Godot;
using Godot.Collections;
using System;

[GlobalClass]
public partial class FSMState_CS : Node
{
	public virtual void _OnEnter(Node actor, Dictionary blackboard) { GD.Print("_OnEnter()"); }
    public virtual void _OnUpdate(float delta, Node actor, Dictionary blackboard) { GD.Print("_OnUpdate(" + delta + ")"); }
    public virtual void _OnExit(Node actor, Dictionary blackboard) { GD.Print("_OnExit()"); }
}
