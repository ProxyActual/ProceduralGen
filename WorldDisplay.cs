using System;

class WorldDisplay
{
    private int width;
    private int height;
    private NoiseGen LargeHeight = new NoiseGen(scale: 100.0f);
    private NoiseGen MidHeight = new NoiseGen(scale: 50.0f);
    private NoiseGen SmallHeight = new NoiseGen(scale: 10.0f);
    public WorldDisplay(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public void displayWorld(float xOffset, float yOffset, float zOffset)
    {
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                float noiseValue = 
                    LargeHeight.perlinNoise(x + xOffset, y + yOffset, 0.0f + zOffset) * 0.5f +
                    MidHeight.perlinNoise(x + xOffset, y + yOffset, 0.0f + zOffset) * 0.3f +
                    SmallHeight.perlinNoise(x + xOffset, y + yOffset, 0.0f + zOffset) * 0.2f;
                char[] shades = { ' ', '.', ':', '-', '=', '+', '*', '#', '%', '@' };
                int shadeIndex = (int)((noiseValue + 1) / 2 * (shades.Length - 1));
                Console.Write(shades[shadeIndex]);
            }
            Console.WriteLine();
        }
    }
}