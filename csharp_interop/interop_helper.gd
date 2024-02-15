class_name InteropHelper

static func _find_cs_child(_node: Node, type) -> Node:
	var child = _node.get_child(0)
	if (is_instance_of(child, type)):
		return child
	else :
		return null
