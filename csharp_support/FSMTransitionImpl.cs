using Godot;
using Godot.Collections;
using System;

[GlobalClass]
public abstract partial class FSMTransitionImpl : Resource
{
    public virtual void _OnTransition(float delta, Node actor, Dictionary blackboard) { }
    public virtual bool _IsValid(Node actor, Dictionary blackboard) { return false; }
}
