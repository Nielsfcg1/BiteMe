Shader "Custom/LeafShader" {
	Properties {
            _MainTex ("Base (RGB)", 2D) = "white" {}
            _Background ("Base (RGB)", 2D) = "white" {}
    }
    SubShader {
    	 Tags 
         { 
             "RenderType" = "Opaque" 
             "Queue" = "Transparent+1" 
         }
    
        Pass {
        	Blend SrcAlpha OneMinusSrcAlpha 
        
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag
            #pragma target 3.0

            #include "UnityCG.cginc"
            
            sampler2D _MainTex;
            sampler2D _Background;
            
            struct Fragment
            {
                 float4 pos : POSITION;
                 float2 uv_MainTex : TEXCOORD0;
                 float2 uv_pos : TEXCOORD1;
            };  

            Fragment vert(appdata_base v) { 
            	Fragment o;
            	
            	o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
            	o.uv_MainTex = v.texcoord.xy;
            	o.uv_pos = ComputeScreenPos(o.pos);
            
                return o;
            }

            fixed4 frag(Fragment IN, float2 sp:WPOS) : COLOR {
            	half4 c0 = tex2D(_MainTex, IN.uv_MainTex);
            	half4 c1 = tex2D(_Background, IN.uv_pos);
            	
                return float4(c1.rgb, c0.a);
            }

            ENDCG
        }
    }
}
