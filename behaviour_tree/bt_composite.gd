@tool
@icon("res://addons/behaviour_toolkit/icons/BTComposite.svg")
class_name BTComposite extends BTBehaviour
## Base class to build composite behaviour nodes.
##
## Composites can hold multiple behaviour nodes and evalute/execute them
## based on custom logic based on their return values.


## The leaves under the composite node.
@onready var leaves: Array = get_children()

# The C# child node implementing the BTComposite
var csChild: BTComposite_CS

func _ready() -> void:
	# Don't run in editor
	if Engine.is_editor_hint():
		return
			
	csChild = InteropHelper._find_cs_child(self, BTComposite_CS)

func _get_configuration_warnings() -> PackedStringArray:
	var warnings: Array = []
	
	var parent = get_parent()
	var children = get_children()

	if not parent is BTComposite and not parent is BTRoot and not parent is BTDecorator:
		warnings.append("BTComposite node must be a child of BTComposite or BTRoot node.")
	
	if children.size() == 0:
		warnings.append("BTComposite node must have at least one child.")
	
	if children.size() == 1:
		warnings.append("BTComposite node should have more than one child.")

	return warnings
