// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.34 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.34;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0.4,fgcg:0.4235294,fgcb:0.4431373,fgca:0.6039216,fgde:0.001,fgrn:0,fgrf:600,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:36121,y:32529,varname:node_4795,prsc:2|emission-3015-OUT,alpha-7251-OUT;n:type:ShaderForge.SFN_VertexColor,id:3759,x:35411,y:32463,varname:node_3759,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3015,x:35828,y:32554,varname:node_3015,prsc:2|A-4976-RGB,B-3759-RGB,C-7971-U;n:type:ShaderForge.SFN_Multiply,id:7251,x:35799,y:32796,varname:node_7251,prsc:2|A-7859-A,B-3759-A;n:type:ShaderForge.SFN_Tex2d,id:7510,x:33883,y:32280,ptovrint:False,ptlb:DistortionTex,ptin:_DistortionTex,varname:_MaskTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-6675-OUT;n:type:ShaderForge.SFN_Tex2d,id:7859,x:34768,y:32317,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-381-OUT;n:type:ShaderForge.SFN_TexCoord,id:1527,x:33228,y:32213,cmnt:UV Random Offset,varname:node_1527,prsc:2,uv:3,uaff:True;n:type:ShaderForge.SFN_Append,id:4309,x:33409,y:32213,varname:node_4309,prsc:2|A-1527-U,B-1527-V;n:type:ShaderForge.SFN_TexCoord,id:5244,x:32952,y:31805,cmnt:UV Coord 02,varname:node_5244,prsc:2,uv:0,uaff:True;n:type:ShaderForge.SFN_Add,id:6675,x:33587,y:32093,varname:node_6675,prsc:2|A-4997-OUT,B-4309-OUT;n:type:ShaderForge.SFN_Desaturate,id:9444,x:34075,y:32280,varname:node_9444,prsc:2|COL-7510-RGB;n:type:ShaderForge.SFN_TexCoord,id:7971,x:35611,y:32389,cmnt:Emission,varname:node_7971,prsc:2,uv:2,uaff:True;n:type:ShaderForge.SFN_TexCoord,id:2579,x:34075,y:32065,cmnt:Distortion Texture Strength,varname:node_2579,prsc:2,uv:1,uaff:True;n:type:ShaderForge.SFN_TexCoord,id:1234,x:34881,y:32995,cmnt:Alpha Strength,varname:node_1234,prsc:2,uv:2,uaff:True;n:type:ShaderForge.SFN_Multiply,id:9471,x:35277,y:32870,varname:node_9471,prsc:2|A-7817-OUT,B-1234-V;n:type:ShaderForge.SFN_TexCoord,id:9143,x:34121,y:31828,cmnt:UV Coord 01,varname:node_9143,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:381,x:34574,y:32152,varname:node_381,prsc:2|A-9143-UVOUT,B-6608-OUT,C-4001-OUT;n:type:ShaderForge.SFN_Append,id:4918,x:33285,y:31838,varname:node_4918,prsc:2|A-5244-Z,B-5244-W;n:type:ShaderForge.SFN_Multiply,id:6608,x:34346,y:32186,varname:node_6608,prsc:2|A-2579-Z,B-9444-OUT;n:type:ShaderForge.SFN_Desaturate,id:7817,x:34993,y:32346,varname:node_7817,prsc:2|COL-7859-RGB;n:type:ShaderForge.SFN_Append,id:4167,x:33285,y:31998,varname:node_4167,prsc:2|A-1276-U,B-1276-V;n:type:ShaderForge.SFN_TexCoord,id:1276,x:32952,y:32000,cmnt:UV Scroll Speed,varname:node_1276,prsc:2,uv:1,uaff:True;n:type:ShaderForge.SFN_Add,id:4997,x:33469,y:31940,varname:node_4997,prsc:2|A-4918-OUT,B-4167-OUT;n:type:ShaderForge.SFN_Tex2d,id:4512,x:33797,y:32487,ptovrint:False,ptlb:SecondDistTex,ptin:_SecondDistTex,varname:node_4512,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-64-OUT;n:type:ShaderForge.SFN_Desaturate,id:4010,x:33999,y:32487,varname:node_4010,prsc:2|COL-4512-RGB;n:type:ShaderForge.SFN_Multiply,id:4001,x:34367,y:32410,varname:node_4001,prsc:2|A-4084-Z,B-4010-OUT;n:type:ShaderForge.SFN_TexCoord,id:4084,x:34076,y:32675,cmnt:Second Distortion Strength,varname:node_4084,prsc:2,uv:2,uaff:True;n:type:ShaderForge.SFN_TexCoord,id:1602,x:32969,y:32765,cmnt:UV Random Offset,varname:node_1602,prsc:2,uv:3,uaff:True;n:type:ShaderForge.SFN_Append,id:7952,x:33166,y:32765,varname:node_7952,prsc:2|A-1602-U,B-1602-V;n:type:ShaderForge.SFN_TexCoord,id:4400,x:32709,y:32357,cmnt:UV Coord 02,varname:node_4400,prsc:2,uv:0,uaff:True;n:type:ShaderForge.SFN_Add,id:64,x:33386,y:32604,varname:node_64,prsc:2|A-6940-OUT,B-7952-OUT;n:type:ShaderForge.SFN_Append,id:3889,x:33042,y:32390,varname:node_3889,prsc:2|A-4400-Z,B-4400-W;n:type:ShaderForge.SFN_Append,id:6897,x:33042,y:32550,varname:node_6897,prsc:2|A-8413-OUT,B-2692-OUT;n:type:ShaderForge.SFN_TexCoord,id:947,x:32584,y:32549,cmnt:UV Scroll Speed,varname:node_947,prsc:2,uv:1,uaff:True;n:type:ShaderForge.SFN_Add,id:6940,x:33226,y:32492,varname:node_6940,prsc:2|A-3889-OUT,B-6897-OUT;n:type:ShaderForge.SFN_Multiply,id:8413,x:32829,y:32549,varname:node_8413,prsc:2|A-947-U,B-2770-W;n:type:ShaderForge.SFN_Multiply,id:2692,x:32829,y:32684,varname:node_2692,prsc:2|A-947-V,B-2770-W;n:type:ShaderForge.SFN_TexCoord,id:2770,x:32482,y:32789,cmnt:Second Distortion Speed Multiply,varname:node_2770,prsc:2,uv:2,uaff:True;n:type:ShaderForge.SFN_TexCoord,id:4455,x:34804,y:32653,varname:node_4455,prsc:2,uv:1,uaff:True;n:type:ShaderForge.SFN_Append,id:4792,x:35035,y:32596,varname:node_4792,prsc:2|A-7817-OUT,B-4455-W;n:type:ShaderForge.SFN_RemapRange,id:9860,x:35246,y:32596,varname:node_9860,prsc:2,frmn:0,frmx:1,tomn:0.1,tomx:0.9|IN-4792-OUT;n:type:ShaderForge.SFN_Tex2d,id:4976,x:35429,y:32637,ptovrint:False,ptlb:RampMap,ptin:_RampMap,varname:node_4976,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4a9e7e0c7f875d142b6ff82ce4d575ef,ntxv:0,isnm:False|UVIN-9860-OUT;proporder:7510-7859-4512-4976;pass:END;sub:END;*/

Shader "FT/DoubleDistortionRamp" {
    Properties {
        _DistortionTex ("DistortionTex", 2D) = "white" {}
        _MainTex ("MainTex", 2D) = "white" {}
        _SecondDistTex ("SecondDistTex", 2D) = "white" {}
        _RampMap ("RampMap", 2D) = "white" {}
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
            Blend SrcAlpha OneMinusSrcAlpha
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
            uniform sampler2D _DistortionTex; uniform float4 _DistortionTex_ST;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _SecondDistTex; uniform float4 _SecondDistTex_ST;
            uniform sampler2D _RampMap; uniform float4 _RampMap_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float4 texcoord0 : TEXCOORD0;
                float4 texcoord1 : TEXCOORD1;
                float4 texcoord2 : TEXCOORD2;
                float4 texcoord3 : TEXCOORD3;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 uv0 : TEXCOORD0;
                float4 uv1 : TEXCOORD1;
                float4 uv2 : TEXCOORD2;
                float4 uv3 : TEXCOORD3;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.uv3 = v.texcoord3;
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
                float2 node_6675 = ((float2(i.uv0.b,i.uv0.a)+float2(i.uv1.r,i.uv1.g))+float2(i.uv3.r,i.uv3.g));
                float4 _DistortionTex_var = tex2D(_DistortionTex,TRANSFORM_TEX(node_6675, _DistortionTex));
                float2 node_64 = ((float2(i.uv0.b,i.uv0.a)+float2((i.uv1.r*i.uv2.a),(i.uv1.g*i.uv2.a)))+float2(i.uv3.r,i.uv3.g));
                float4 _SecondDistTex_var = tex2D(_SecondDistTex,TRANSFORM_TEX(node_64, _SecondDistTex));
                float2 node_381 = (i.uv0+(i.uv1.b*dot(_DistortionTex_var.rgb,float3(0.3,0.59,0.11)))+(i.uv2.b*dot(_SecondDistTex_var.rgb,float3(0.3,0.59,0.11))));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_381, _MainTex));
                float node_7817 = dot(_MainTex_var.rgb,float3(0.3,0.59,0.11));
                float2 node_9860 = (float2(node_7817,i.uv1.a)*0.8+0.1);
                float4 _RampMap_var = tex2D(_RampMap,TRANSFORM_TEX(node_9860, _RampMap));
                float3 emissive = (_RampMap_var.rgb*i.vertexColor.rgb*i.uv2.r);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,(_MainTex_var.a*i.vertexColor.a));
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0.4,0.4235294,0.4431373,0.6039216));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
