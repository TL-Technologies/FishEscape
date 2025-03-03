Shader "VueCode/UnlitMod"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _Color ("Main Color", Color) = (1,1,1,1)
    _Cutoff ("Alpha cutoff", Range(0, 1)) = 0.5
    _Stroke ("Stroke Alpha", Range(0, 1)) = 0.1
    _StrokeColor ("Stroke Color", Color) = (1,1,1,1)
    _Stroke2 ("Stroke Alpha", Range(0, 1)) = 0.1
    _StrokeColor2 ("Stroke Color", Color) = (1,1,1,1)
  }
  SubShader
  {
    Tags
    { 
      "IGNOREPROJECTOR" = "true"
      "QUEUE" = "AlphaTest"
      "RenderType" = "TransparentCutout"
    }
    LOD 100
    Pass // ind: 1, name: 
    {
      Tags
      { 
        "IGNOREPROJECTOR" = "true"
        "QUEUE" = "AlphaTest"
        "RenderType" = "TransparentCutout"
      }
      LOD 100
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      
      
      #define CODE_BLOCK_VERTEX
      //uniform float4x4 unity_ObjectToWorld;
      //uniform float4x4 unity_MatrixVP;
      uniform float4 _MainTex_ST;
      uniform float _Cutoff;
      uniform float4 _Color;
      uniform float _Stroke;
      uniform float4 _StrokeColor;
      uniform sampler2D _MainTex;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float2 texcoord :TEXCOORD0;
      };
      
      struct OUT_Data_Vert
      {
          float2 texcoord :TEXCOORD0;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float2 texcoord :TEXCOORD0;
      };
      
      struct OUT_Data_Frag
      {
          float4 color :SV_Target0;
      };
      
      float4 u_xlat0;
      float4 u_xlat1;
      OUT_Data_Vert vert(appdata_t in_v)
      {
          OUT_Data_Vert out_v;
          out_v.vertex = UnityObjectToClipPos(in_v.vertex);
          u_xlat0.xy = float2(TRANSFORM_TEX(in_v.texcoord.xy, _MainTex));
          out_v.texcoord.xy = float2(u_xlat0.xy);
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float u_xlat0_d;
      int u_xlatb0;
      float u_xlat16_1;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat0_d = tex2D(_MainTex, in_f.texcoord.xy).w.x;
          u_xlat16_1 = (u_xlat0_d + (-_Cutoff));
          #ifdef UNITY_ADRENO_ES3
          if((u_xlat0_d<_Stroke))
          {
              u_xlatb0 = 1;
          }
          else
          {
              u_xlatb0 = 0;
          }
          #else
          if((u_xlat0_d<_Stroke))
          {
              u_xlatb0 = 1;
          }
          else
          {
              u_xlatb0 = 0;
          }
          #endif
          out_f.color = (int(u_xlatb0))?(_StrokeColor):(_Color);
          #ifdef UNITY_ADRENO_ES3
          if((u_xlat16_1<0))
          {
              u_xlatb0 = 1;
          }
          else
          {
              u_xlatb0 = 0;
          }
          #else
          if((u_xlat16_1<0))
          {
              u_xlatb0 = 1;
          }
          else
          {
              u_xlatb0 = 0;
          }
          #endif
          if(((int(u_xlatb0) * int(4294967295))!=0))
          {
              discard;
          }
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
