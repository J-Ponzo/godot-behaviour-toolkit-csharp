using Godot;
using Godot.Collections;
using System;


[GlobalClass]
public partial class FSMStateImpl : Resource
{
    public void _OnEnter(Node actor, Dictionary blackboard){ }
    public void _OnUpdate(float delta, Node actor, Dictionary blackboard){ }
    public void _OnExit(Node actor, Dictionary blackboard) { }
}
