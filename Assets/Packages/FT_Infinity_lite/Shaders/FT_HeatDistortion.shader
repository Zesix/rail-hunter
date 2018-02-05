// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.34 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.34;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0.4,fgcg:0.4235294,fgcb:0.4431373,fgca:0.6039216,fgde:0.001,fgrn:0,fgrf:600,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:33457,y:32639,varname:node_4795,prsc:2|normal-720-RGB,emission-9162-OUT,alpha-9162-OUT,refract-6777-OUT;n:type:ShaderForge.SFN_Tex2d,id:720,x:32756,y:32719,ptovrint:False,ptlb:NormalTex,ptin:_NormalTex,varname:node_720,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9e8cfdd48affcfc4a9be6ae7cc155775,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Vector1,id:9162,x:32970,y:32611,varname:node_9162,prsc:2,v1:0;n:type:ShaderForge.SFN_ComponentMask,id:8441,x:32981,y:32899,varname:node_8441,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-720-RGB;n:type:ShaderForge.SFN_Multiply,id:6777,x:33231,y:32947,varname:node_6777,prsc:2|A-8441-OUT,B-5660-OUT,C-7524-A,D-9-OUT,E-506-U;n:type:ShaderForge.SFN_VertexColor,id:7524,x:33034,y:32687,varname:node_7524,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:2810,x:32501,y:33100,varname:node_2810,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_RemapRange,id:8110,x:32671,y:33100,varname:node_8110,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-2810-UVOUT;n:type:ShaderForge.SFN_Length,id:5954,x:32848,y:33100,varname:node_5954,prsc:2|IN-8110-OUT;n:type:ShaderForge.SFN_OneMinus,id:5660,x:33020,y:33100,varname:node_5660,prsc:2|IN-5954-OUT;n:type:ShaderForge.SFN_Vector1,id:9,x:33057,y:33044,varname:node_9,prsc:2,v1:0.1;n:type:ShaderForge.SFN_TexCoord,id:506,x:32980,y:33291,cmnt:Strength,varname:node_506,prsc:2,uv:1,uaff:False;proporder:720;pass:END;sub:END;*/

Shader "FT/HeatDistortion" {
    Properties {
        _NormalTex ("NormalTex", 2D) = "bump" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform sampler2D _NormalTex; uniform float4 _NormalTex_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 screenPos : TEXCOORD5;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 _NormalTex_var = UnpackNormal(tex2D(_NormalTex,TRANSFORM_TEX(i.uv0, _NormalTex)));
                float3 normalLocal = _NormalTex_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + (_NormalTex_var.rgb.rg*(1.0 - length((i.uv0*2.0+-1.0)))*i.vertexColor.a*0.1*i.uv1.r);
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
////// Emissive:
                float node_9162 = 0.0;
                float3 emissive = float3(node_9162,node_9162,node_9162);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,node_9162),1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0.4,0.4235294,0.4431373,0.6039216));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
