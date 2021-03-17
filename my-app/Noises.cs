using static System.Math;
using static Structs;
using System;
using System.Diagnostics;
static class Noises
{
    public static int OpenSimplex(Vector2 p, int i, int j, OpenSimplexNoise opSplx)
    {
        float x = p.x + i / 100f;
        float y = p.y + j / 100f;
        float noise = (1f+(float)opSplx.Evaluate(x, y))/2f;
        return ((int)Round(255 * Abs(noise), 0));
    }
    public static int ClampedSimple(Vector2 p, int i, int j, OpenSimplexNoise opSplx)
    {
        float x = p.x + i / 100f;
        float y = p.y + j / 100f;
        float noise = (1f+(float)opSplx.Evaluate(x, y))/2f;
        float mod = 0.05f;
        noise = noise - noise%mod;
        if (noise >= 1-10*mod) { noise = 1f; }
        else if (noise <= 10*mod) { noise = 0f; }
        return ((int)Round(255 * Abs(noise), 0));
    }
    public static int ClampedFractal3C(Vector2 p, int i, int j, OpenSimplexNoise opSplx)
    {
        int count = 5;
        float mult = 0.39f;
        float x = i*mult;
        float y = j*mult;
        float m = 1f;
        float noise = (1f+(float)opSplx.Evaluate(p.x + x,p.y + y))/2f;
        float max = m;

        for (int k=0; k<count; k++){
          x /= 2;
          y /= 2;
          m *= 2.1f;
          noise += m*(1f+(float)opSplx.Evaluate(p.x + x,p.y + y))/2f;
          max += m;
        }

        noise /= max;

        float mod = 0.05f;
        noise = noise - noise%mod;
        if (noise >= 1-8*mod) { noise = 1f; }
        else if (noise <= 8*mod) { noise = 0f; }
        else { noise = 0.5f; }
        return ((int)Round(255 * Abs(noise), 0));
    }
    public static int ClampedFractal2C(Vector2 p, int i, int j, OpenSimplexNoise opSplx)
    {
        int count = 5;
        float mult = 0.39f;
        float x = i*mult;
        float y = j*mult;
        float m = 1f;
        float noise = (1f+(float)opSplx.Evaluate(p.x + x,p.y + y))/2f;
        float max = m;

        for (int k=0; k<count; k++){
          x /= 2;
          y /= 2;
          m *= 2.1f;
          noise += m*(1f+(float)opSplx.Evaluate(p.x + x,p.y + y))/2f;
          max += m;
        }

        noise /= max;

        float mod = 0.05f;
        noise = noise - noise%mod;
        if (noise >= 1-10*mod) { noise = 1f; }
        else if (noise <= 10*mod) { noise = 0f; }
        return ((int)Round(255 * Abs(noise), 0));
    }
    public static int RidgedNoise(Vector2 p, int i, int j, OpenSimplexNoise opSplx)
    {
        int count = 4;
        float mult = 0.39f;
        float x = i*mult;
        float y = j*mult;
        float m = 1f;
        float noise = (1f+(float)opSplx.Evaluate(p.x + x,p.y + y))/2f;
        float max = m;

        for (int k=0; k<count; k++){
          x /= 2.8f;
          y /= 2.8f;
          m *= 3.4f;
          noise += m*(1f+(float)opSplx.Evaluate(p.x + x,p.y + y))/2f;
          max += m;
        }

        noise = Abs(noise/max - 0.5f)*2f;

        return ((int)Round(255 * noise, 0));
    }
    public static float RidgedNoise(Vector2 p, int i, int j, OpenSimplexNoise opSplx, int n, float v1_multiplier, float m_multiplier)
    {
        float mult = 0.39f;
        float x = i*mult;
        float y = j*mult;
        float m = 1f;
        float noise = (1f+(float)opSplx.Evaluate(p.x + x,p.y + y))/2f;
        float max = m;

        for (int k=0; k<n; k++){
          x /= v1_multiplier;
          y /= v1_multiplier;
          m *= m_multiplier;
          noise += m*(1f+(float)opSplx.Evaluate(p.x + x,p.y + y))/2f;
          max += m;
        }

        noise = Abs(noise/max - 0.5f)*2f;

        return noise;
    }
    public static int FractalNoise(Vector2 p, int i, int j, OpenSimplexNoise opSplx)
    {
        int count = 5;
        float mult = 0.39f;
        float x = i*mult;
        float y = j*mult;
        float m = 1f;
        float noise = (1f+(float)opSplx.Evaluate(p.x + x,p.y + y))/2f;
        float max = m;

        for (int k=0; k<count; k++){
          x /= 2;
          y /= 2;
          m *= 2.1f;
          noise += m*(1f+(float)opSplx.Evaluate(p.x + x,p.y + y))/2f;
          max += m;
        }

        noise /= max;

        return ((int)Round(255 * Abs(noise), 0));
    }
    public static float FractalNoise(Vector2 p, int i, int j, OpenSimplexNoise opSplx, int n, float v1_multiplier, float m_multiplier)
    {
        float mult = 0.39f;
        float x = i*mult;
        float y = j*mult;
        float m = 1f;
        float noise = (1f+(float)opSplx.Evaluate(p.x + x,p.y + y))/2f;
        float max = m;

        for (int k=0; k<n; k++){
          x /= v1_multiplier;
          y /= v1_multiplier;
          m *= m_multiplier;
          noise += m*(1f+(float)opSplx.Evaluate(p.x + x,p.y + y))/2f;
          max += m;
        }

        noise /= max;

        return noise;
    }
    
    public static int CombinedNoise1(Vector2 p1, Vector2 p2, int i, int j, OpenSimplexNoise opSplx, int size)
    {
        float noise = 0f;
        float dist = (float)Pow( (Pow(i - size/2f,2f) + Pow(j - size/2f,2f)) , 0.5f);
        if (dist< size/2.4f)
        {
            float dist_multiplier = (float)Pow(Min(1f, (size/2.4f - dist)/100f),2f);

            float noise1 = (float)Pow(1f - RidgedNoise(p1, i, j, opSplx, 4, 2.8f, 3.4f), 2f);

            float noise2 = FractalNoise(p2, i, j, opSplx, 4, 3.4f, 3f);

            noise = noise1*(0.3f + 0.7f*noise2);
            if (noise < 0.2f) { noise = (float)Pow(noise - 0.2f,2f)*2.5f; }
            else { noise = 0.7f*(float)Pow(noise - 0.2f,2f)/0.64f; }

            noise *= dist_multiplier;
        }

        return ((int)Round(Max(0,Min(255,255 - 255 * noise)), 0));
    }
}
