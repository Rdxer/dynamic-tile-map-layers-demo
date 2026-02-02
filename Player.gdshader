shader_type canvas_item;

uniform float blue = 1.0;
uniform float offset1 = 0.0;
uniform float offset2 = 0.0;


uniform sampler2D screen_texture : hint_screen_texture, repeat_disable, filter_nearest;


void vertex() {
	// 对材质可见的每个顶点调用。 
	VERTEX += vec2(offset1, offset2);
	// VERTEX += vec2(cos(TIME)*100.0, sin(TIME)*100.0);
}

void fragment() {
	// 对材质可见的每个像素调用。
	// COLOR = vec4(0.4, 0.6, 0.9, 1.0);
	// COLOR = vec4(UV, 0.5, 1.0);
	// COLOR.b = 1.0;
	// COLOR = texture(TEXTURE, UV); // Read from texture again.
  	COLOR.b = blue; //set blue channel to 1.0
}

//void light() {
//	// 对影响 CanvasItem 的每个光源的每个像素调用。
//	// 取消注释以使用此函数替换默认的光照处理函数。
//}
