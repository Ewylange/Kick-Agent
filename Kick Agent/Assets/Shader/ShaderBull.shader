// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:33631,y:32725,varname:node_3138,prsc:2|emission-354-RGB,alpha-9137-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:6507,x:30390,y:32820,varname:node_6507,prsc:2;n:type:ShaderForge.SFN_Slider,id:7267,x:31979,y:33189,ptovrint:False,ptlb:Largeur,ptin:_Largeur,varname:node_7267,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7483119,max:1;n:type:ShaderForge.SFN_Color,id:354,x:32268,y:32519,ptovrint:False,ptlb:m,ptin:_m,varname:node_354,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Distance,id:4144,x:31844,y:32612,varname:node_4144,prsc:2|A-3181-XYZ,B-6507-XYZ;n:type:ShaderForge.SFN_Floor,id:2562,x:32650,y:32871,varname:node_2562,prsc:2|IN-9948-OUT;n:type:ShaderForge.SFN_Multiply,id:9948,x:32439,y:33004,varname:node_9948,prsc:2|A-4144-OUT,B-7267-OUT;n:type:ShaderForge.SFN_Distance,id:6015,x:31740,y:33218,varname:node_6015,prsc:2|A-6507-XYZ,B-1476-XYZ;n:type:ShaderForge.SFN_Slider,id:9531,x:31814,y:33575,ptovrint:False,ptlb:Largeur2,ptin:_Largeur2,varname:node_9531,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5970751,max:1;n:type:ShaderForge.SFN_Multiply,id:5441,x:32236,y:33456,varname:node_5441,prsc:2|A-6015-OUT,B-9531-OUT;n:type:ShaderForge.SFN_Floor,id:2443,x:32631,y:33258,varname:node_2443,prsc:2|IN-5441-OUT;n:type:ShaderForge.SFN_Multiply,id:9137,x:33000,y:33519,varname:node_9137,prsc:2|A-2562-OUT,B-2443-OUT,C-563-OUT,D-8120-OUT,E-3499-OUT;n:type:ShaderForge.SFN_Vector4Property,id:1476,x:31301,y:33336,ptovrint:False,ptlb:node_1476,ptin:_node_1476,varname:node_1476,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1,v2:0,v3:2,v4:0;n:type:ShaderForge.SFN_Vector4Property,id:3181,x:31382,y:32654,ptovrint:False,ptlb:BulleCoin,ptin:_BulleCoin,varname:node_3181,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Vector4Property,id:9132,x:31045,y:33719,ptovrint:False,ptlb:node_9132,ptin:_node_9132,varname:node_9132,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Distance,id:2275,x:31472,y:33718,varname:node_2275,prsc:2|A-6507-XYZ,B-9132-XYZ;n:type:ShaderForge.SFN_Slider,id:7601,x:31318,y:34087,ptovrint:False,ptlb:node_7601,ptin:_node_7601,varname:node_7601,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2037906,max:1;n:type:ShaderForge.SFN_Multiply,id:4350,x:31813,y:33810,varname:node_4350,prsc:2|A-2275-OUT,B-7601-OUT;n:type:ShaderForge.SFN_Floor,id:563,x:32093,y:33800,varname:node_563,prsc:2|IN-4350-OUT;n:type:ShaderForge.SFN_Vector4Property,id:7535,x:30951,y:34343,ptovrint:False,ptlb:node_9132_copy,ptin:_node_9132_copy,varname:_node_9132_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Distance,id:195,x:31378,y:34342,varname:node_195,prsc:2|A-6507-XYZ,B-7535-XYZ;n:type:ShaderForge.SFN_Slider,id:8298,x:31224,y:34711,ptovrint:False,ptlb:node_7601_copy,ptin:_node_7601_copy,varname:_node_7601_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2037906,max:1;n:type:ShaderForge.SFN_Multiply,id:3565,x:31719,y:34434,varname:node_3565,prsc:2|A-195-OUT,B-8298-OUT;n:type:ShaderForge.SFN_Floor,id:8120,x:31999,y:34424,varname:node_8120,prsc:2|IN-3565-OUT;n:type:ShaderForge.SFN_Vector4Property,id:8807,x:30718,y:34918,ptovrint:False,ptlb:node_9132_copy_copy,ptin:_node_9132_copy_copy,varname:_node_9132_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Distance,id:7313,x:31157,y:34920,varname:node_7313,prsc:2|A-6507-XYZ,B-8807-XYZ;n:type:ShaderForge.SFN_Slider,id:4659,x:30991,y:35286,ptovrint:False,ptlb:node_7601_copy_copy,ptin:_node_7601_copy_copy,varname:_node_7601_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2037906,max:1;n:type:ShaderForge.SFN_Multiply,id:1838,x:31486,y:35009,varname:node_1838,prsc:2|A-7313-OUT,B-4659-OUT;n:type:ShaderForge.SFN_Floor,id:3499,x:31826,y:34958,varname:node_3499,prsc:2|IN-1838-OUT;proporder:7267-354-9531-1476-3181-9132-7601-7535-8298-8807-4659;pass:END;sub:END;*/

Shader "Shader Forge/ShaderBull" {
    Properties {
        _Largeur ("Largeur", Range(0, 1)) = 0.7483119
        _m ("m", Color) = (1,1,1,1)
        _Largeur2 ("Largeur2", Range(0, 1)) = 0.5970751
        _node_1476 ("node_1476", Vector) = (1,0,2,0)
        _BulleCoin ("BulleCoin", Vector) = (0,0,0,0)
        _node_9132 ("node_9132", Vector) = (0,0,0,0)
        _node_7601 ("node_7601", Range(0, 1)) = 0.2037906
        _node_9132_copy ("node_9132_copy", Vector) = (0,0,0,0)
        _node_7601_copy ("node_7601_copy", Range(0, 1)) = 0.2037906
        _node_9132_copy_copy ("node_9132_copy_copy", Vector) = (0,0,0,0)
        _node_7601_copy_copy ("node_7601_copy_copy", Range(0, 1)) = 0.2037906
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
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _Largeur;
            uniform float4 _m;
            uniform float _Largeur2;
            uniform float4 _node_1476;
            uniform float4 _BulleCoin;
            uniform float4 _node_9132;
            uniform float _node_7601;
            uniform float4 _node_9132_copy;
            uniform float _node_7601_copy;
            uniform float4 _node_9132_copy_copy;
            uniform float _node_7601_copy_copy;
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float3 emissive = _m.rgb;
                float3 finalColor = emissive;
                return fixed4(finalColor,(floor((distance(_BulleCoin.rgb,i.posWorld.rgb)*_Largeur))*floor((distance(i.posWorld.rgb,_node_1476.rgb)*_Largeur2))*floor((distance(i.posWorld.rgb,_node_9132.rgb)*_node_7601))*floor((distance(i.posWorld.rgb,_node_9132_copy.rgb)*_node_7601_copy))*floor((distance(i.posWorld.rgb,_node_9132_copy_copy.rgb)*_node_7601_copy_copy))));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
