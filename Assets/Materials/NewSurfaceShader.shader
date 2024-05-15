Shader "Custom/VelocityColorShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _Velocity ("Velocity", Float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Velocity;
        fixed4 _Color;

        // Function to convert HSV to RGB color
        fixed3 HSVtoRGB (fixed3 hsv)
        {
            fixed H = hsv.x * 6;
            fixed hi = floor(H);
            fixed f = H - hi;
            fixed p = hsv.z * (1 - hsv.y);
            fixed q = hsv.z * (1 - (hsv.y * f));
            fixed t = hsv.z * (1 - (hsv.y * (1 - f)));

            fixed3 rgb = fixed3(0, 0, 0);
            if (hi == 0) rgb = fixed3(hsv.z, t, p);
            if (hi == 1) rgb = fixed3(q, hsv.z, p);
            if (hi == 2) rgb = fixed3(p, hsv.z, t);
            if (hi == 3) rgb = fixed3(p, q, hsv.z);
            if (hi == 4) rgb = fixed3(t, p, hsv.z);
            if (hi == 5) rgb = fixed3(hsv.z, p, q);
            return rgb;
        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Calculate color based on velocity
            float speed = abs(_Velocity);
            // Example: Change hue based on velocity
            float hue = speed * 0.1; // Adjust this factor as needed
            o.Albedo = HSVtoRGB(fixed3(hue, 1, 1));
        }
        ENDCG
    }
    FallBack "Diffuse"
}
