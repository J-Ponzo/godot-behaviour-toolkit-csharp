using Godot;
using Godot.Collections;
using System;


[GlobalClass]
public abstract partial class FSMStateImpl : BehaviourToolkitImpl
{
    public virtual void _OnEnter(Node actor, Dictionary blackboard){ }
    public virtual void _OnUpdate(float delta, Node actor, Dictionary blackboard){ }
    public virtual void _OnExit(Node actor, Dictionary blackboard) { }
}
