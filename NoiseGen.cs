class NoiseGen
{
    Random rnd;
    private float scale;
    private float[] dataPoints;

    public NoiseGen(float scale = 1.0f, int seed = 0)
    {
        this.scale = scale;
        rnd = new Random(seed);
        dataPoints = new float[32 * 32 * 32];
        
        for (int i = 0; i < dataPoints.Length; i++)
        {
            dataPoints[i] = (float)(rnd.NextDouble() * 2.0 - 1.0);
        }
    }

    public float perlinNoise(float x, float y, float z)
    {
        int x0 = (int)(x / scale) % 32;
        int x1 = (x0 + 1) % 32;
        int y0 = (int)(y / scale) % 32;
        int y1 = (y0 + 1) % 32;
        int z0 = (int)(z / scale) % 32;
        int z1 = (z0 + 1) % 32;

        float sx = (x / scale) - (int)(x / scale);
        float sy = (y / scale) - (int)(y / scale);
        float sz = (z / scale) - (int)(z / scale);

        float n0, n1, ix0, ix1, iy0, iy1, value;

        // Interpolate along x for z0 plane
        n0 = dataPoints[z0 * 32 * 32 + y0 * 32 + x0];
        n1 = dataPoints[z0 * 32 * 32 + y0 * 32 + x1];
        ix0 = interpolate(n0, n1, sx);

        n0 = dataPoints[z0 * 32 * 32 + y1 * 32 + x0];
        n1 = dataPoints[z0 * 32 * 32 + y1 * 32 + x1];
        ix1 = interpolate(n0, n1, sx);

        // Interpolate along y for z0 plane
        iy0 = interpolate(ix0, ix1, sy);

        // Interpolate along x for z1 plane
        n0 = dataPoints[z1 * 32 * 32 + y0 * 32 + x0];
        n1 = dataPoints[z1 * 32 * 32 + y0 * 32 + x1];
        ix0 = interpolate(n0, n1, sx);

        n0 = dataPoints[z1 * 32 * 32 + y1 * 32 + x0];
        n1 = dataPoints[z1 * 32 * 32 + y1 * 32 + x1];
        ix1 = interpolate(n0, n1, sx);

        // Interpolate along y for z1 plane
        iy1 = interpolate(ix0, ix1, sy);

        // Final interpolation along z
        value = interpolate(iy0, iy1, sz);
        return value;
    }

    public float interpolate(float a, float b, float t)
    {
        float ft = t * 3.1415927f;
        float f = (1 - (float)Math.Cos(ft)) * 0.5f;
        return a * (1 - f) + b * f;
    }
}