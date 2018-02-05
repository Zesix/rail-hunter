// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.34 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.34;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:34086,y:32540,varname:node_4795,prsc:2|emission-4383-OUT,alpha-6869-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:31852,y:32521,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-8916-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32235,y:32772,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9759,x:32589,y:32595,varname:node_9759,prsc:2|A-2053-RGB,B-9243-OUT,C-2053-A,D-6074-A;n:type:ShaderForge.SFN_Multiply,id:669,x:32589,y:32790,varname:node_669,prsc:2|A-9731-OUT,B-2053-A;n:type:ShaderForge.SFN_SwitchProperty,id:9243,x:32320,y:32441,ptovrint:False,ptlb:Desaturate,ptin:_Desaturate,varname:node_9243,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-6074-RGB,B-4001-OUT;n:type:ShaderForge.SFN_Desaturate,id:4001,x:32134,y:32407,varname:node_4001,prsc:2|COL-6074-RGB;n:type:ShaderForge.SFN_TexCoord,id:8259,x:31049,y:32461,varname:node_8259,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:535,x:31305,y:32241,varname:node_535,prsc:2|A-8259-UVOUT,B-8618-OUT;n:type:ShaderForge.SFN_Fresnel,id:3589,x:33019,y:33236,varname:node_3589,prsc:2|EXP-5691-W;n:type:ShaderForge.SFN_Lerp,id:9914,x:33205,y:32596,varname:node_9914,prsc:2|A-5158-OUT,B-2641-OUT,T-2205-OUT;n:type:ShaderForge.SFN_Lerp,id:5363,x:33223,y:32786,varname:node_5363,prsc:2|A-5158-OUT,B-7468-OUT,T-2205-OUT;n:type:ShaderForge.SFN_Vector1,id:5158,x:32941,y:32498,varname:node_5158,prsc:2,v1:0;n:type:ShaderForge.SFN_OneMinus,id:2856,x:33397,y:33282,varname:node_2856,prsc:2|IN-6321-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:2205,x:33216,y:33090,ptovrint:False,ptlb:Fresnel Invert,ptin:_FresnelInvert,varname:node_2205,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-3589-OUT,B-853-OUT;n:type:ShaderForge.SFN_Power,id:6321,x:33216,y:33282,varname:node_6321,prsc:2|VAL-3589-OUT,EXP-598-OUT;n:type:ShaderForge.SFN_Vector1,id:598,x:33201,y:33436,varname:node_598,prsc:2,v1:4;n:type:ShaderForge.SFN_Add,id:8916,x:31663,y:32392,varname:node_8916,prsc:2|A-535-OUT,B-7782-OUT;n:type:ShaderForge.SFN_Tex2d,id:6684,x:32438,y:33335,ptovrint:False,ptlb:ClipTex,ptin:_ClipTex,varname:node_6684,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-6695-OUT;n:type:ShaderForge.SFN_Tex2d,id:9989,x:31621,y:33049,ptovrint:False,ptlb:Distortion Tex,ptin:_DistortionTex,varname:node_9989,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-7485-OUT;n:type:ShaderForge.SFN_TexCoord,id:2851,x:31848,y:33036,varname:node_2851,prsc:2,uv:0,uaff:True;n:type:ShaderForge.SFN_Add,id:6695,x:32244,y:33335,varname:node_6695,prsc:2|A-8583-OUT,B-9071-OUT;n:type:ShaderForge.SFN_Multiply,id:2641,x:32808,y:32614,varname:node_2641,prsc:2|A-9759-OUT,B-5276-OUT;n:type:ShaderForge.SFN_Multiply,id:7468,x:32808,y:32790,varname:node_7468,prsc:2|A-669-OUT,B-5276-OUT;n:type:ShaderForge.SFN_Multiply,id:7782,x:31608,y:32638,varname:node_7782,prsc:2|A-9989-R,B-5946-Z;n:type:ShaderForge.SFN_Multiply,id:9071,x:31817,y:33417,varname:node_9071,prsc:2|A-9989-R,B-5946-Z;n:type:ShaderForge.SFN_Add,id:7485,x:31344,y:32504,varname:node_7485,prsc:2|A-8259-UVOUT,B-4597-OUT;n:type:ShaderForge.SFN_Multiply,id:4597,x:31027,y:32680,varname:node_4597,prsc:2|A-1592-OUT,B-3915-W;n:type:ShaderForge.SFN_Power,id:2644,x:32600,y:33242,varname:node_2644,prsc:2|VAL-6684-R,EXP-445-Z;n:type:ShaderForge.SFN_Power,id:853,x:33592,y:33279,varname:node_853,prsc:2|VAL-2856-OUT,EXP-598-OUT;n:type:ShaderForge.SFN_Vector1,id:2753,x:30821,y:32191,varname:node_2753,prsc:2,v1:0;n:type:ShaderForge.SFN_SwitchProperty,id:8618,x:31080,y:32288,ptovrint:False,ptlb:Scroll Distortion Only,ptin:_ScrollDistortionOnly,varname:node_8618,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-1592-OUT,B-2753-OUT;n:type:ShaderForge.SFN_TexCoord,id:6564,x:33268,y:32435,cmnt:Emission,varname:node_6564,prsc:2,uv:2,uaff:True;n:type:ShaderForge.SFN_TexCoord,id:5691,x:32778,y:33328,cmnt:Fresnel Strength,varname:node_5691,prsc:2,uv:2,uaff:True;n:type:ShaderForge.SFN_TexCoord,id:445,x:32500,y:33055,cmnt:Clip Strength,varname:node_445,prsc:2,uv:2,uaff:True;n:type:ShaderForge.SFN_TexCoord,id:9311,x:30282,y:32506,cmnt:UV Scroll Speed,varname:node_9311,prsc:2,uv:1,uaff:False;n:type:ShaderForge.SFN_TexCoord,id:3915,x:30744,y:32802,cmnt:Distortion Speed Multiply,varname:node_3915,prsc:2,uv:1,uaff:True;n:type:ShaderForge.SFN_TexCoord,id:5946,x:31025,y:32976,cmnt:Distortion Strength,varname:node_5946,prsc:2,uv:1,uaff:True;n:type:ShaderForge.SFN_TexCoord,id:6496,x:31807,y:33244,cmnt:Offset Y,varname:node_6496,prsc:2,uv:2,uaff:True;n:type:ShaderForge.SFN_Add,id:1273,x:32014,y:33154,varname:node_1273,prsc:2|A-2851-W,B-6496-V;n:type:ShaderForge.SFN_Append,id:8583,x:32200,y:33090,varname:node_8583,prsc:2|A-2851-Z,B-1273-OUT;n:type:ShaderForge.SFN_FaceSign,id:4008,x:33584,y:32892,varname:node_4008,prsc:2,fstp:0;n:type:ShaderForge.SFN_ToggleProperty,id:88,x:33584,y:33081,ptovrint:False,ptlb:DoubleSide,ptin:_DoubleSide,varname:node_88,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False;n:type:ShaderForge.SFN_Add,id:2614,x:33771,y:32917,varname:node_2614,prsc:2|A-4008-VFACE,B-88-OUT;n:type:ShaderForge.SFN_Multiply,id:4383,x:33591,y:32597,varname:node_4383,prsc:2|A-6597-OUT,B-2614-OUT,C-6564-U;n:type:ShaderForge.SFN_Multiply,id:6869,x:33697,y:32751,varname:node_6869,prsc:2|A-7492-OUT,B-2614-OUT;n:type:ShaderForge.SFN_Append,id:1592,x:30715,y:32493,varname:node_1592,prsc:2|A-7857-OUT,B-5046-OUT;n:type:ShaderForge.SFN_Multiply,id:7857,x:30513,y:32408,varname:node_7857,prsc:2|A-9311-U,B-8005-T;n:type:ShaderForge.SFN_Multiply,id:5046,x:30513,y:32586,varname:node_5046,prsc:2|A-9311-V,B-8005-T;n:type:ShaderForge.SFN_Time,id:8005,x:30337,y:32685,varname:node_8005,prsc:2;n:type:ShaderForge.SFN_ToggleProperty,id:738,x:31988,y:32738,ptovrint:False,ptlb:UseAlpha,ptin:_UseAlpha,varname:node_738,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False;n:type:ShaderForge.SFN_Lerp,id:9731,x:32198,y:32609,varname:node_9731,prsc:2|A-4001-OUT,B-6074-A,T-738-OUT;n:type:ShaderForge.SFN_Clamp01,id:5276,x:32780,y:33026,varname:node_5276,prsc:2|IN-2644-OUT;n:type:ShaderForge.SFN_Clamp01,id:6597,x:33391,y:32597,varname:node_6597,prsc:2|IN-9914-OUT;n:type:ShaderForge.SFN_Clamp01,id:7492,x:33419,y:32769,varname:node_7492,prsc:2|IN-5363-OUT;proporder:6074-6684-9989-9243-88-2205-8618-738;pass:END;sub:END;*/

Shader "FT/UVscroll_Fresnel" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _ClipTex ("ClipTex", 2D) = "white" {}
        _DistortionTex ("Distortion Tex", 2D) = "white" {}
        [MaterialToggle] _Desaturate ("Desaturate", Float ) = 0
        [MaterialToggle] _DoubleSide ("DoubleSide", Float ) = 0
        [MaterialToggle] _FresnelInvert ("Fresnel Invert", Float ) = 1
        [MaterialToggle] _ScrollDistortionOnly ("Scroll Distortion Only", Float ) = 0
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
            uniform fixed _FresnelInvert;
            uniform sampler2D _ClipTex; uniform float4 _ClipTex_ST;
            uniform sampler2D _DistortionTex; uniform float4 _DistortionTex_ST;
            uniform fixed _ScrollDistortionOnly;
            uniform fixed _DoubleSide;
            uniform fixed _UseAlpha;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
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
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float node_5158 = 0.0;
                float4 node_8005 = _Time + _TimeEditor;
                float2 node_1592 = float2((i.uv1.r*node_8005.g),(i.uv1.g*node_8005.g));
                float2 node_7485 = (i.uv0+(node_1592*i.uv1.a));
                float4 _DistortionTex_var = tex2D(_DistortionTex,TRANSFORM_TEX(node_7485, _DistortionTex));
                float2 node_8916 = ((i.uv0+lerp( node_1592, 0.0, _ScrollDistortionOnly ))+(_DistortionTex_var.r*i.uv1.b));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_8916, _MainTex));
                float node_4001 = dot(_MainTex_var.rgb,float3(0.3,0.59,0.11));
                float2 node_6695 = (float2(i.uv0.b,(i.uv0.a+i.uv2.g))+(_DistortionTex_var.r*i.uv1.b));
                float4 _ClipTex_var = tex2D(_ClipTex,TRANSFORM_TEX(node_6695, _ClipTex));
                float node_5276 = saturate(pow(_ClipTex_var.r,i.uv2.b));
                float node_3589 = pow(1.0-max(0,dot(normalDirection, viewDirection)),i.uv2.a);
                float node_598 = 4.0;
                float _FresnelInvert_var = lerp( node_3589, pow((1.0 - pow(node_3589,node_598)),node_598), _FresnelInvert );
                float node_2614 = (isFrontFace+_DoubleSide);
                float3 emissive = (saturate(lerp(float3(node_5158,node_5158,node_5158),((i.vertexColor.rgb*lerp( _MainTex_var.rgb, node_4001, _Desaturate )*i.vertexColor.a*_MainTex_var.a)*node_5276),_FresnelInvert_var))*node_2614*i.uv2.r);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,(saturate(lerp(node_5158,((lerp(node_4001,_MainTex_var.a,_UseAlpha)*i.vertexColor.a)*node_5276),_FresnelInvert_var))*node_2614));
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
