extends CharacterBody2D

const WALK_FORCE = 600
const WALK_MAX_SPEED = 200
const STOP_FORCE = 1300
const JUMP_SPEED = 200

@onready var gravity = ProjectSettings.get_setting("physics/2d/default_gravity")

func _physics_process(delta):
	# 水平移动代码。首先，获取玩家的输入。
	var walk = WALK_FORCE * (Input.get_axis(&"move_left", &"move_right"))
	# 如果玩家没有尝试移动，则减慢玩家速度。
	if abs(walk) < WALK_FORCE * 0.2:
		# 速度稍微减慢，然后重新分配。
		velocity.x = move_toward(velocity.x, 0, STOP_FORCE * delta)
	else:
		velocity.x += walk * delta
	# 限制最大水平移动速度。
	velocity.x = clamp(velocity.x, -WALK_MAX_SPEED, WALK_MAX_SPEED)

	# 垂直移动代码。应用重力。
	velocity.y += gravity * delta

	# 根据速度移动并吸附到地面。
	# TODO: 这些信息应该设置为 CharacterBody 属性，而不是参数：snap, Vector2.DOWN, Vector2.UP
	# TODO: 在脚本的其余部分将 velocity 重命名为 linear_velocity。
	move_and_slide()

	# 检查跳跃。is_on_floor() 必须在移动代码后调用。
	if is_on_floor() and Input.is_action_just_pressed(&"jump"):
		velocity.y = -JUMP_SPEED
