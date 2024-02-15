@tool
@icon("res://addons/behaviour_toolkit/icons/BTDecoratorNot.svg")
class_name BTInverter extends BTDecorator
## The result of the leaf is inverted.


func tick(delta: float, actor: Node, blackboard: Blackboard):
	var response = leaf.tick(delta, actor, blackboard)

	if response == BTStatus.SUCCESS:
		return BTStatus.FAILURE
	
	if response == BTStatus.FAILURE:
		return BTStatus.SUCCESS

	return BTStatus.RUNNING

# Prevent display of the csharpImpl parent class exported property
func _validate_property(property):
	if property.name == "csharpImpl":
		property.usage = 0 
