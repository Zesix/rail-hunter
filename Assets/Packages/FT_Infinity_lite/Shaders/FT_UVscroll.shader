// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.34 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.34;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:33580,y:32526,varname:node_4795,prsc:2|emission-5684-OUT,alpha-6980-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:31852,y:32521,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-8916-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32021,y:32738,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9759,x:32589,y:32595,varname:node_9759,prsc:2|A-2053-RGB,B-9243-OUT,C-8951-U,D-6074-A,E-2053-A;n:type:ShaderForge.SFN_Multiply,id:669,x:32589,y:32790,varname:node_669,prsc:2|A-5354-OUT,B-2053-A;n:type:ShaderForge.SFN_SwitchProperty,id:9243,x:32252,y:32447,ptovrint:False,ptlb:Desaturate,ptin:_Desaturate,varname:node_9243,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-6074-RGB,B-4001-OUT;n:type:ShaderForge.SFN_Desaturate,id:4001,x:32046,y:32347,varname:node_4001,prsc:2|COL-6074-RGB;n:type:ShaderForge.SFN_TexCoord,id:8259,x:31066,y:32472,varname:node_8259,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:535,x:31305,y:32241,varname:node_535,prsc:2|A-8259-UVOUT,B-8618-OUT;n:type:ShaderForge.SFN_Add,id:8916,x:31663,y:32392,varname:node_8916,prsc:2|A-535-OUT,B-7782-OUT;n:type:ShaderForge.SFN_Tex2d,id:6684,x:32438,y:33395,ptovrint:False,ptlb:ClipTex,ptin:_ClipTex,varname:node_6684,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-6695-OUT;n:type:ShaderForge.SFN_Tex2d,id:9989,x:31677,y:33036,ptovrint:False,ptlb:Distortion Tex,ptin:_DistortionTex,varname:node_9989,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-7485-OUT;n:type:ShaderForge.SFN_TexCoord,id:2851,x:31877,y:33003,varname:node_2851,prsc:2,uv:0,uaff:True;n:type:ShaderForge.SFN_Add,id:6695,x:32185,y:33381,varname:node_6695,prsc:2|A-460-OUT,B-9071-OUT;n:type:ShaderForge.SFN_Multiply,id:2641,x:32892,y:32616,varname:node_2641,prsc:2|A-9759-OUT,B-4297-OUT;n:type:ShaderForge.SFN_Multiply,id:7468,x:32905,y:32789,varname:node_7468,prsc:2|A-669-OUT,B-4297-OUT;n:type:ShaderForge.SFN_Multiply,id:7782,x:31608,y:32638,varname:node_7782,prsc:2|A-9989-R,B-6057-Z;n:type:ShaderForge.SFN_Multiply,id:9071,x:31777,y:33317,varname:node_9071,prsc:2|A-9989-R,B-6057-Z;n:type:ShaderForge.SFN_Add,id:7485,x:31363,y:32615,varname:node_7485,prsc:2|A-8259-UVOUT,B-4597-OUT;n:type:ShaderForge.SFN_Multiply,id:4597,x:31027,y:32680,varname:node_4597,prsc:2|A-7121-OUT,B-927-W;n:type:ShaderForge.SFN_Power,id:2644,x:32615,y:33167,varname:node_2644,prsc:2|VAL-6684-R,EXP-3674-Z;n:type:ShaderForge.SFN_Vector1,id:2753,x:30842,y:32288,varname:node_2753,prsc:2,v1:0;n:type:ShaderForge.SFN_SwitchProperty,id:8618,x:31079,y:32304,ptovrint:False,ptlb:Scroll Distortion Only,ptin:_ScrollDistortionOnly,varname:node_8618,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-7121-OUT,B-2753-OUT;n:type:ShaderForge.SFN_TexCoord,id:8078,x:30314,y:32448,cmnt:UV Scroll Speed,varname:node_8078,prsc:2,uv:1,uaff:True;n:type:ShaderForge.SFN_TexCoord,id:927,x:30708,y:32813,cmnt:Distortion Speed Multiply,varname:node_927,prsc:2,uv:1,uaff:True;n:type:ShaderForge.SFN_TexCoord,id:6057,x:31043,y:32968,cmnt:Distortion Strength,varname:node_6057,prsc:2,uv:1,uaff:True;n:type:ShaderForge.SFN_TexCoord,id:3674,x:32394,y:33167,cmnt:Clip Strength,varname:node_3674,prsc:2,uv:2,uaff:True;n:type:ShaderForge.SFN_TexCoord,id:8951,x:32220,y:32881,cmnt:Emission,varname:node_8951,prsc:2,uv:2,uaff:True;n:type:ShaderForge.SFN_Clamp01,id:4297,x:32810,y:33016,varname:node_4297,prsc:2|IN-2644-OUT;n:type:ShaderForge.SFN_Append,id:460,x:32206,y:33130,varname:node_460,prsc:2|A-2851-Z,B-6460-OUT;n:type:ShaderForge.SFN_TexCoord,id:7716,x:31877,y:33179,cmnt:UV Offset Y,varname:node_7716,prsc:2,uv:2,uaff:True;n:type:ShaderForge.SFN_Add,id:6460,x:32057,y:33201,varname:node_6460,prsc:2|A-2851-W,B-7716-V;n:type:ShaderForge.SFN_Multiply,id:5684,x:33272,y:32616,varname:node_5684,prsc:2|A-2641-OUT,B-7859-OUT;n:type:ShaderForge.SFN_Multiply,id:6980,x:33272,y:32781,varname:node_6980,prsc:2|A-7468-OUT,B-7859-OUT;n:type:ShaderForge.SFN_FaceSign,id:9522,x:33062,y:32951,varname:node_9522,prsc:2,fstp:0;n:type:ShaderForge.SFN_ToggleProperty,id:3377,x:33079,y:33150,ptovrint:False,ptlb:DoubleSide,ptin:_DoubleSide,varname:node_3377,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False;n:type:ShaderForge.SFN_Add,id:7859,x:33272,y:32991,varname:node_7859,prsc:2|A-9522-VFACE,B-3377-OUT;n:type:ShaderForge.SFN_Append,id:7121,x:30736,y:32444,varname:node_7121,prsc:2|A-4676-OUT,B-7185-OUT;n:type:ShaderForge.SFN_Multiply,id:4676,x:30523,y:32391,varname:node_4676,prsc:2|A-8078-U,B-4284-T;n:type:ShaderForge.SFN_Multiply,id:7185,x:30521,y:32531,varname:node_7185,prsc:2|A-8078-V,B-4284-T;n:type:ShaderForge.SFN_Time,id:4284,x:30359,y:32616,varname:node_4284,prsc:2;n:type:ShaderForge.SFN_ToggleProperty,id:2474,x:32036,y:32680,ptovrint:False,ptlb:UseAlpha,ptin:_UseAlpha,varname:node_2474,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False;n:type:ShaderForge.SFN_Lerp,id:5354,x:32276,y:32646,varname:node_5354,prsc:2|A-4001-OUT,B-6074-A,T-2474-OUT;proporder:6074-6684-9989-9243-8618-3377-2474;pass:END;sub:END;*/

Shader "FT/UVscroll" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _ClipTex ("ClipTex", 2D) = "white" {}
        _DistortionTex ("Distortion Tex", 2D) = "white" {}
        [MaterialToggle] _Desaturate ("Desaturate", Float ) = 0
        [MaterialToggle] _ScrollDistortionOnly ("Scroll Distortion Only", Float ) = 0
        [MaterialToggle] _DoubleSide ("DoubleSide", Float ) = 0
        [MaterialToggle] _UseAlpha ("UseAlpha", Float ) = 0
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
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles n3ds wiiu 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform fixed _Desaturate;
            uniform sampler2D _ClipTex; uniform float4 _ClipTex_ST;
            uniform sampler2D _DistortionTex; uniform float4 _DistortionTex_ST;
            uniform fixed _ScrollDistortionOnly;
            uniform fixed _DoubleSide;
            uniform fixed _UseAlpha;
            struct VertexInput {
                float4 vertex : POSITION;
                float4 texcoord0 : TEXCOORD0;
                float4 texcoord1 : TEXCOORD1;
                float4 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 uv0 : TEXCOORD0;
                float4 uv1 : TEXCOORD1;
                float4 uv2 : TEXCOORD2;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 node_4284 = _Time + _TimeEditor;
                float2 node_7121 = float2((i.uv1.r*node_4284.g),(i.uv1.g*node_4284.g));
                float2 node_7485 = (i.uv0+(node_7121*i.uv1.a));
                float4 _DistortionTex_var = tex2D(_DistortionTex,TRANSFORM_TEX(node_7485, _DistortionTex));
                float2 node_8916 = ((i.uv0+lerp( node_7121, 0.0, _ScrollDistortionOnly ))+(_DistortionTex_var.r*i.uv1.b));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_8916, _MainTex));
                float node_4001 = dot(_MainTex_var.rgb,float3(0.3,0.59,0.11));
                float2 node_6695 = (float2(i.uv0.b,(i.uv0.a+i.uv2.g))+(_DistortionTex_var.r*i.uv1.b));
                float4 _ClipTex_var = tex2D(_ClipTex,TRANSFORM_TEX(node_6695, _ClipTex));
                float node_4297 = saturate(pow(_ClipTex_var.r,i.uv2.b));
                float node_7859 = (isFrontFace+_DoubleSide);
                float3 emissive = (((i.vertexColor.rgb*lerp( _MainTex_var.rgb, node_4001, _Desaturate )*i.uv2.r*_MainTex_var.a*i.vertexColor.a)*node_4297)*node_7859);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,(((lerp(node_4001,_MainTex_var.a,_UseAlpha)*i.vertexColor.a)*node_4297)*node_7859));
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
