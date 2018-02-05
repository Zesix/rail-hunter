// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.34 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.34;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.4,fgcg:0.4235294,fgcb:0.4431373,fgca:0.6039216,fgde:0.001,fgrn:0,fgrf:600,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:33441,y:32715,varname:node_4795,prsc:2|emission-3086-OUT,clip-9170-OUT;n:type:ShaderForge.SFN_TexCoord,id:7347,x:31937,y:32886,cmnt:Dissolve Animation,varname:node_7347,prsc:2,uv:2,uaff:True;n:type:ShaderForge.SFN_RemapRange,id:8264,x:32292,y:32882,varname:node_8264,prsc:2,frmn:0,frmx:1,tomn:-0.5,tomx:0.5|IN-7347-V;n:type:ShaderForge.SFN_Tex2d,id:6202,x:32127,y:33121,ptovrint:False,ptlb:ClipTex,ptin:_ClipTex,varname:node_6202,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-3468-OUT;n:type:ShaderForge.SFN_Add,id:2063,x:32645,y:33063,varname:node_2063,prsc:2|A-8264-OUT,B-1714-OUT;n:type:ShaderForge.SFN_Desaturate,id:1714,x:32311,y:33115,varname:node_1714,prsc:2|COL-6202-RGB;n:type:ShaderForge.SFN_Tex2d,id:4109,x:32417,y:32676,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_4109,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4306-UVOUT;n:type:ShaderForge.SFN_Multiply,id:9170,x:33184,y:32957,varname:node_9170,prsc:2|A-1872-A,B-2063-OUT,C-9216-OUT;n:type:ShaderForge.SFN_TexCoord,id:5405,x:31436,y:33061,cmnt:UV Coord02,varname:node_5405,prsc:2,uv:0,uaff:True;n:type:ShaderForge.SFN_Append,id:3468,x:31960,y:33137,varname:node_3468,prsc:2|A-8272-OUT,B-6384-OUT;n:type:ShaderForge.SFN_TexCoord,id:4306,x:32155,y:32659,cmnt:UV Coord01,varname:node_4306,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_TexCoord,id:4036,x:31436,y:33297,cmnt:Random Offset UV,varname:node_4036,prsc:2,uv:3,uaff:False;n:type:ShaderForge.SFN_Add,id:8272,x:31692,y:33107,varname:node_8272,prsc:2|A-5405-Z,B-4036-U;n:type:ShaderForge.SFN_Add,id:6384,x:31692,y:33252,varname:node_6384,prsc:2|A-5405-W,B-4036-V;n:type:ShaderForge.SFN_Multiply,id:3086,x:33139,y:32563,varname:node_3086,prsc:2|A-8028-OUT,B-1872-RGB,C-1005-U;n:type:ShaderForge.SFN_VertexColor,id:1872,x:32630,y:32403,varname:node_1872,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:1005,x:32443,y:32482,cmnt:Emission,varname:node_1005,prsc:2,uv:2,uaff:False;n:type:ShaderForge.SFN_Desaturate,id:3605,x:32633,y:32706,varname:node_3605,prsc:2|COL-4109-RGB;n:type:ShaderForge.SFN_Lerp,id:8028,x:32944,y:32658,varname:node_8028,prsc:2|A-4109-RGB,B-3605-OUT,T-2166-Z;n:type:ShaderForge.SFN_TexCoord,id:2166,x:32772,y:32748,varname:node_2166,prsc:2,uv:2,uaff:True;n:type:ShaderForge.SFN_TexCoord,id:9805,x:32645,y:32912,varname:node_9805,prsc:2,uv:2,uaff:True;n:type:ShaderForge.SFN_Lerp,id:9216,x:32925,y:32952,varname:node_9216,prsc:2|A-3605-OUT,B-4109-A,T-9805-W;proporder:4109-6202;pass:END;sub:END;*/

Shader "FT/DissolveSimple" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _ClipTex ("ClipTex", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _ClipTex; uniform float4 _ClipTex_ST;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float4 texcoord0 : TEXCOORD0;
                float4 texcoord2 : TEXCOORD2;
                float2 texcoord3 : TEXCOORD3;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 uv0 : TEXCOORD0;
                float4 uv2 : TEXCOORD1;
                float2 uv3 : TEXCOORD2;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv2 = v.texcoord2;
                o.uv3 = v.texcoord3;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float2 node_3468 = float2((i.uv0.b+i.uv3.r),(i.uv0.a+i.uv3.g));
                float4 _ClipTex_var = tex2D(_ClipTex,TRANSFORM_TEX(node_3468, _ClipTex));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_3605 = dot(_MainTex_var.rgb,float3(0.3,0.59,0.11));
                clip((i.vertexColor.a*((i.uv2.g*1.0+-0.5)+dot(_ClipTex_var.rgb,float3(0.3,0.59,0.11)))*lerp(node_3605,_MainTex_var.a,i.uv2.a)) - 0.5);
////// Lighting:
////// Emissive:
                float3 emissive = (lerp(_MainTex_var.rgb,float3(node_3605,node_3605,node_3605),i.uv2.b)*i.vertexColor.rgb*i.uv2.r);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
