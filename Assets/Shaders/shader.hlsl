void SpinEffect_float(
    float4 Color1,
    float4 Color2,
    float4 Color3,
    float2 ScreenCoords,
    float Time,
    out float4 OutColor
)
{
    // Configuration (identique à Shadertoy)
    const float SPIN_ROTATION = -2.0;
    const float SPIN_SPEED = 7.0;
    const float2 OFFSET = float2(0.0, 0.0);
    const float CONTRAST = 3.5;
    const float LIGTHING = 0.4;
    const float SPIN_AMOUNT = 0.25;
    const float PIXEL_FILTER = 745.0;
    const float SPIN_EASE = 1.0;
    const bool IS_ROTATE = false;
    const float2 ScreenSize = float2(1, 1);

    float pixel_size = length(ScreenSize) / PIXEL_FILTER;
    float2 uv = floor(ScreenCoords / pixel_size) * pixel_size;
    uv = (uv - 0.5 * ScreenSize) / length(ScreenSize) - OFFSET;
    
    float uv_len = length(uv);
    
    float speed = (SPIN_ROTATION * SPIN_EASE * 0.2);
    
    if (IS_ROTATE)
    {
        speed = Time * speed;
    }
    
    speed += 302.2;
    float new_pixel_angle = atan2(uv.y, uv.x) + speed - SPIN_EASE * 20.0 * (1.0 * SPIN_AMOUNT * uv_len + (1.0 - 1.0 * SPIN_AMOUNT));
    
    float2 mid = (ScreenSize.xy / length(ScreenSize.xy)) / 2.0;
    uv = (float2((uv_len * cos(new_pixel_angle) + mid.x), (uv_len * sin(new_pixel_angle) + mid.y)) - mid);
    
    uv *= 30.0;
    speed = Time * (SPIN_SPEED);
    
    float2 uv2 = float2(uv.x + uv.y, 0);
    
    [unroll]
    for (int i = 0; i < 5; i++)
    {
        uv2 += sin(max(uv.x, uv.y)) + uv;
        uv += 0.5 * float2(cos(5.1123314 + 0.353 * uv2.y + speed * 0.131121), sin(uv2.x - 0.113 * speed));
        uv -= 1.0 * cos(uv.x + uv.y) - 1.0 * sin(uv.x * 0.711 - uv.y);
    }
    
    float contrast_mod = (0.25 * CONTRAST + 0.5 * SPIN_AMOUNT + 1.2);
    float paint_res = min(2.0, max(0.0, length(uv) * (0.035) * contrast_mod));
    float c1p = max(0.0, 1.0 - contrast_mod * abs(1.0 - paint_res));
    float c2p = max(0.0, 1.0 - contrast_mod * abs(paint_res));
    float c3p = 1.0 - min(1.0, c1p + c2p);
    float light = (LIGTHING - 0.2) * max(c1p * 5.0 - 4.0, 0.0) + LIGTHING * max(c2p * 5.0 - 4.0, 0.0);
    OutColor = (0.3 / CONTRAST) * Color1 + (1.0 - 0.3 / CONTRAST) * (Color1 * c1p + Color2 * c2p + float4(c3p * Color3.rgb, c3p * Color1.a)) + light;
}