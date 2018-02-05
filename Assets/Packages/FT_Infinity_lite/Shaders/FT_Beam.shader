// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.34 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.34;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:32998,y:32602,varname:node_4795,prsc:2|emission-9546-OUT,alpha-5207-OUT;n:type:ShaderForge.SFN_Tex2d,id:2467,x:32260,y:32764,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_2467,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-6283-OUT;n:type:ShaderForge.SFN_VertexColor,id:8366,x:32260,y:32586,varname:node_8366,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9546,x:32711,y:32529,varname:node_9546,prsc:2|A-8366-RGB,B-2303-OUT,C-4596-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4596,x:32504,y:32504,ptovrint:False,ptlb:Emission,ptin:_Emission,varname:node_4596,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_TexCoord,id:3918,x:30943,y:32548,varname:node_3918,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Append,id:3595,x:31458,y:32565,varname:node_3595,prsc:2|A-6231-OUT,B-3918-V;n:type:ShaderForge.SFN_Multiply,id:9794,x:30943,y:32791,varname:node_9794,prsc:2|A-636-OUT,B-2083-T;n:type:ShaderForge.SFN_Time,id:2083,x:30768,y:32888,varname:node_2083,prsc:2;n:type:ShaderForge.SFN_Add,id:6231,x:31249,y:32671,varname:node_6231,prsc:2|A-3918-U,B-9794-OUT;n:type:ShaderForge.SFN_ValueProperty,id:636,x:30768,y:32778,ptovrint:False,ptlb:UVspeed,ptin:_UVspeed,varname:node_636,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:5207,x:32709,y:33003,varname:node_5207,prsc:2|A-8366-A,B-2467-A,C-2467-R;n:type:ShaderForge.SFN_Desaturate,id:7235,x:32478,y:32807,varname:node_7235,prsc:2|COL-2467-RGB;n:type:ShaderForge.SFN_Lerp,id:2303,x:32735,y:32721,varname:node_2303,prsc:2|A-2467-RGB,B-7235-OUT,T-7258-OUT;n:type:ShaderForge.SFN_ToggleProperty,id:7258,x:32620,y:32922,ptovrint:False,ptlb:Desaturate,ptin:_Desaturate,varname:node_7258,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False;n:type:ShaderForge.SFN_Tex2d,id:2178,x:31774,y:32932,ptovrint:False,ptlb:DistortionTex,ptin:_DistortionTex,varname:node_2178,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-2487-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5792,x:31803,y:33177,ptovrint:False,ptlb:Distortion Strength,ptin:_DistortionStrength,varname:node_5792,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:5209,x:31987,y:32932,varname:node_5209,prsc:2|A-2178-R,B-5792-OUT;n:type:ShaderForge.SFN_Add,id:6283,x:32063,y:32734,varname:node_6283,prsc:2|A-3595-OUT,B-5209-OUT;n:type:ShaderForge.SFN_Multiply,id:5777,x:31113,y:32945,varname:node_5777,prsc:2|A-9794-OUT,B-8484-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8484,x:30848,y:33096,ptovrint:False,ptlb:DistortionSpeedMultiply,ptin:_DistortionSpeedMultiply,varname:node_8484,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Append,id:2487,x:31485,y:32810,varname:node_2487,prsc:2|A-1084-OUT,B-3918-V;n:type:ShaderForge.SFN_Add,id:1084,x:31292,y:32854,varname:node_1084,prsc:2|A-3918-U,B-5777-OUT;proporder:2467-2178-7258-4596-636-5792-8484;pass:END;sub:END;*/

Shader "FT/Beam" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _DistortionTex ("DistortionTex", 2D) = "white" {}
        [MaterialToggle] _Desaturate ("Desaturate", Float ) = 0
        _Emission ("Emission", Float ) = 1
        _UVspeed ("UVspeed", Float ) = 1
        _DistortionStrength ("Distortion Strength", Float ) = 1
        _DistortionSpeedMultiply ("DistortionSpeedMultiply", Float ) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal n3ds wiiu 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Emission;
            uniform float _UVspeed;
            uniform fixed _Desaturate;
            uniform sampler2D _DistortionTex; uniform float4 _DistortionTex_ST;
            uniform float _DistortionStrength;
            uniform float _DistortionSpeedMultiply;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_2083 = _Time + _TimeEditor;
                float node_9794 = (_UVspeed*node_2083.g);
                float2 node_2487 = float2((i.uv0.r+(node_9794*_DistortionSpeedMultiply)),i.uv0.g);
                float4 _DistortionTex_var = tex2D(_DistortionTex,TRANSFORM_TEX(node_2487, _DistortionTex));
                float2 node_6283 = (float2((i.uv0.r+node_9794),i.uv0.g)+(_DistortionTex_var.r*_DistortionStrength));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_6283, _MainTex));
                float node_7235 = dot(_MainTex_var.rgb,float3(0.3,0.59,0.11));
                float3 emissive = (i.vertexColor.rgb*lerp(_MainTex_var.rgb,float3(node_7235,node_7235,node_7235),_Desaturate)*_Emission);
                float3 finalColor = emissive;
                return fixed4(finalColor,(i.vertexColor.a*_MainTex_var.a*_MainTex_var.r));
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
