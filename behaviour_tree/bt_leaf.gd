@tool
@icon("res://addons/behaviour_toolkit/icons/BTLeaf.svg")
class_name BTLeaf extends BTBehaviour
## A leaf is where the actual logic that controlls the actor or other nodes
## is implemented.
##
## It is the base class for all leaves and can be extended to implement
## custom behaviours.[br]
## The [code]tick(actor: Node, blackboard: Blackboard)[/code] method is called
## every frame and should return the status.

@export var csharpImpl: BTLeafImpl

func _ready() -> void:
	# Don't run in editor
	if Engine.is_editor_hint():
		return
	
	if(csharpImpl != null):
		csharpImpl = csharpImpl.duplicate()
		csharpImpl._Init(self)

func tick(_delta: float, _actor: Node, _blackboard: Blackboard) -> BTStatus:
	if(csharpImpl != null):
		return csharpImpl._Tick(_delta, _actor, _blackboard.content)
	else:
		return BTStatus.SUCCESS


func _get_configuration_warnings() -> PackedStringArray:
	var warnings: Array = []

	var parent = get_parent()
	var children = get_children()

	if not parent is BTBehaviour and not parent is BTRoot:
		warnings.append("BTLeaf node must be a child of BTBehaviour or BTRoot node.")

	if children.size() > 0:
		warnings.append("BTLeaf node must not have any children.")

	return warnings
