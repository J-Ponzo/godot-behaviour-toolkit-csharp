using Godot;
using Godot.Collections;
using System;

[GlobalClass]
public partial class FSMTransitionImpl : Resource
{
    public void _OnTransition(float delta, Node actor, Dictionary blackboard) { }
    public bool _IsValid(Node actor, Dictionary blackboard) { return false; }
}
