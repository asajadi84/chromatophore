//////////////////////////////////////////////////////////////
/// Shadero Sprite: Sprite Shader Editor - by VETASOFT 2018 //
/// Shader generate with Shadero 1.9.3                      //
/// http://u3d.as/V7t #AssetStore                           //
/// http://www.shadero.com #Docs                            //
//////////////////////////////////////////////////////////////

Shader "Shadero Customs/BackgroundShader"
{
Properties
{
[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
AnimatedShakeUV_1_OffsetX_1("AnimatedShakeUV_1_OffsetX_1", Range(0, 0.05)) = 0.05
AnimatedShakeUV_1_OffsetY_1("AnimatedShakeUV_1_OffsetY_1", Range(0, 0.05)) = 0
AnimatedShakeUV_1_IntenseX_1("AnimatedShakeUV_1_IntenseX_1", Range(-3, 3)) = 3
AnimatedShakeUV_1_IntenseY_1("AnimatedShakeUV_1_IntenseY_1", Range(-3, 3)) = 1
AnimatedShakeUV_1_Speed_1("AnimatedShakeUV_1_Speed_1", Range(-1, 1)) = 0.001
_SpriteFade("SpriteFade", Range(0, 1)) = 1.0

// required for UI.Mask
[HideInInspector]_StencilComp("Stencil Comparison", Float) = 8
[HideInInspector]_Stencil("Stencil ID", Float) = 0
[HideInInspector]_StencilOp("Stencil Operation", Float) = 0
[HideInInspector]_StencilWriteMask("Stencil Write Mask", Float) = 255
[HideInInspector]_StencilReadMask("Stencil Read Mask", Float) = 255
[HideInInspector]_ColorMask("Color Mask", Float) = 15

}

SubShader
{

Tags {"Queue" = "Transparent" "IgnoreProjector" = "true" "RenderType" = "Transparent" "PreviewType"="Plane" "CanUseSpriteAtlas"="True" }
ZWrite Off Blend SrcAlpha OneMinusSrcAlpha Cull Off

// required for UI.Mask
Stencil
{
Ref [_Stencil]
Comp [_StencilComp]
Pass [_StencilOp]
ReadMask [_StencilReadMask]
WriteMask [_StencilWriteMask]
}

Pass
{

CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma fragmentoption ARB_precision_hint_fastest
#include "UnityCG.cginc"

struct appdata_t{
float4 vertex   : POSITION;
float4 color    : COLOR;
float2 texcoord : TEXCOORD0;
};

struct v2f
{
float2 texcoord  : TEXCOORD0;
float4 vertex   : SV_POSITION;
float4 color    : COLOR;
};

sampler2D _MainTex;
float _SpriteFade;
float AnimatedShakeUV_1_OffsetX_1;
float AnimatedShakeUV_1_OffsetY_1;
float AnimatedShakeUV_1_IntenseX_1;
float AnimatedShakeUV_1_IntenseY_1;
float AnimatedShakeUV_1_Speed_1;

v2f vert(appdata_t IN)
{
v2f OUT;
OUT.vertex = UnityObjectToClipPos(IN.vertex);
OUT.texcoord = IN.texcoord;
OUT.color = IN.color;
return OUT;
}


float2 AnimatedShakeUV(float2 uv, float offsetx, float offsety, float zoomx, float zoomy, float speed)
{
float time = sin(_Time * speed * 5000 * zoomx);
float time2 = sin(_Time * speed * 5000 * zoomy);
uv += float2(offsetx * time, offsety * time2);
return uv;
}
float4 frag (v2f i) : COLOR
{
float2 AnimatedShakeUV_1 = AnimatedShakeUV(i.texcoord,AnimatedShakeUV_1_OffsetX_1,AnimatedShakeUV_1_OffsetY_1,AnimatedShakeUV_1_IntenseX_1,AnimatedShakeUV_1_IntenseY_1,AnimatedShakeUV_1_Speed_1);
float4 _MainTex_1 = tex2D(_MainTex,AnimatedShakeUV_1);
float4 FinalResult = _MainTex_1;
FinalResult.rgb *= i.color.rgb;
FinalResult.a = FinalResult.a * _SpriteFade * i.color.a;
FinalResult.rgb *= FinalResult.a;
FinalResult.a = saturate(FinalResult.a);
return FinalResult;
}

ENDCG
}
}
Fallback "Sprites/Default"
}
