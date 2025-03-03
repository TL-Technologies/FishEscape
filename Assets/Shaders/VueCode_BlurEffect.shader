Shader "VueCode/BlurEffect"
{
  Properties
  {
    _MainTex ("", any) = "" {}
  }
  SubShader
  {
    Tags
    { 
    }
    Pass // ind: 1, name: 
    {
      Tags
      { 
      }
      ZTest Always
      ZWrite Off
      Cull Off
      // m_ProgramMask = 6
      CGPROGRAM
      //#pragma target 4.0
      
      #pragma vertex vert
      #pragma fragment frag
      
      #include "UnityCG.cginc"
      
      
      #define CODE_BLOCK_VERTEX
      //uniform float4x4 unity_ObjectToWorld;
      //uniform float4x4 unity_MatrixVP;
      uniform float4 _MainTex_TexelSize;
      uniform float4 _BlurOffsets;
      uniform sampler2D _MainTex;
      struct appdata_t
      {
          float4 vertex :POSITION0;
          float2 texcoord :TEXCOORD0;
      };
      
      struct OUT_Data_Vert
      {
          float2 texcoord :TEXCOORD0;
          float2 texcoord1 :TEXCOORD1;
          float2 texcoord2 :TEXCOORD2;
          float2 texcoord3 :TEXCOORD3;
          float2 texcoord4 :TEXCOORD4;
          float4 vertex :SV_POSITION;
      };
      
      struct v2f
      {
          float2 texcoord1 :TEXCOORD1;
          float2 texcoord2 :TEXCOORD2;
          float2 texcoord3 :TEXCOORD3;
          float2 texcoord4 :TEXCOORD4;
      };
      
      struct OUT_Data_Frag
      {
          float4 color :SV_Target0;
      };
      
      float4 u_xlat0;
      float4 u_xlat1;
      float2 u_xlat16_2;
      float2 u_xlat16_8;
      OUT_Data_Vert vert(appdata_t in_v)
      {
          OUT_Data_Vert out_v;
          out_v.vertex = UnityObjectToClipPos(in_v.vertex);
          u_xlat16_2.xy = float2((((-_BlurOffsets.xy) * _MainTex_TexelSize.xy) + in_v.texcoord.xy));
          out_v.texcoord.xy = float2(u_xlat16_2.xy);
          out_v.texcoord1.xy = float2(in_v.texcoord.xy);
          out_v.texcoord2.xy = float2((((-_BlurOffsets.xy) * _MainTex_TexelSize.xy) + u_xlat16_2.xy));
          u_xlat16_8.xy = float2((_MainTex_TexelSize.xy * _BlurOffsets.xy));
          out_v.texcoord3.xy = float2(((u_xlat16_8.xy * float2(1, (-1))) + u_xlat16_2.xy));
          out_v.texcoord4.xy = float2((((-u_xlat16_8.xy) * float2(1, (-1))) + u_xlat16_2.xy));
          return out_v;
      }
      
      #define CODE_BLOCK_FRAGMENT
      float4 u_xlat16_0;
      float4 u_xlat16_1;
      OUT_Data_Frag frag(v2f in_f)
      {
          OUT_Data_Frag out_f;
          u_xlat16_0 = tex2D(_MainTex, in_f.texcoord1.xy);
          u_xlat16_1 = tex2D(_MainTex, in_f.texcoord2.xy);
          u_xlat16_0 = (u_xlat16_0 + u_xlat16_1);
          u_xlat16_1 = tex2D(_MainTex, in_f.texcoord3.xy);
          u_xlat16_0 = (u_xlat16_0 + u_xlat16_1);
          u_xlat16_1 = tex2D(_MainTex, in_f.texcoord4.xy);
          u_xlat16_0 = (u_xlat16_0 + u_xlat16_1);
          out_f.color = (u_xlat16_0 * float4(0.25, 0.25, 0.25, 0.25));
          return out_f;
      }
      
      
      ENDCG
      
    } // end phase
  }
  FallBack Off
}
