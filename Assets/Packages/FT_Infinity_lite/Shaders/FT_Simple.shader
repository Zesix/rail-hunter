// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.34 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.34;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0.4,fgcg:0.4235294,fgcb:0.4431373,fgca:0.6039216,fgde:0.001,fgrn:0,fgrf:600,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:35836,y:32515,varname:node_4795,prsc:2|emission-3015-OUT,alpha-7251-OUT;n:type:ShaderForge.SFN_VertexColor,id:3759,x:35164,y:32322,varname:node_3759,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3015,x:35556,y:32609,varname:node_3015,prsc:2|A-4669-OUT,B-3759-RGB,C-7971-U,D-3759-A,E-7859-A;n:type:ShaderForge.SFN_Multiply,id:7251,x:35556,y:32784,varname:node_7251,prsc:2|A-9471-OUT,B-3759-A;n:type:ShaderForge.SFN_Tex2d,id:7859,x:34663,y:32675,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_TexCoord,id:7971,x:35152,y:32492,cmnt:Emission,varname:node_7971,prsc:2,uv:2,uaff:True;n:type:ShaderForge.SFN_TexCoord,id:1234,x:35126,y:33096,cmnt:Alpha Strength,varname:node_1234,prsc:2,uv:2,uaff:True;n:type:ShaderForge.SFN_Multiply,id:9471,x:35373,y:32890,varname:node_9471,prsc:2|A-6339-OUT,B-1234-V;n:type:ShaderForge.SFN_Desaturate,id:9847,x:34897,y:32732,varname:node_9847,prsc:2|COL-7859-RGB;n:type:ShaderForge.SFN_Lerp,id:4669,x:35267,y:32633,varname:node_4669,prsc:2|A-7859-RGB,B-9847-OUT,T-3924-Z;n:type:ShaderForge.SFN_TexCoord,id:3924,x:34897,y:32519,cmnt:Desaturate,varname:node_3924,prsc:2,uv:2,uaff:True;n:type:ShaderForge.SFN_Lerp,id:6339,x:35155,y:32850,varname:node_6339,prsc:2|A-9847-OUT,B-7859-A,T-1942-W;n:type:ShaderForge.SFN_TexCoord,id:1942,x:34848,y:32968,cmnt:Use Texture Alpha,varname:node_1942,prsc:2,uv:2,uaff:True;proporder:7859;pass:END;sub:END;*/

Shader "FT/Simple" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
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
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles n3ds wiiu 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 uv2 : TEXCOORD1;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_9847 = dot(_MainTex_var.rgb,float3(0.3,0.59,0.11));
                float3 emissive = (lerp(_MainTex_var.rgb,float3(node_9847,node_9847,node_9847),i.uv2.b)*i.vertexColor.rgb*i.uv2.r*i.vertexColor.a*_MainTex_var.a);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,((lerp(node_9847,_MainTex_var.a,i.uv2.a)*i.uv2.g)*i.vertexColor.a));
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0.4,0.4235294,0.4431373,0.6039216));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
