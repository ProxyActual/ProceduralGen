using System;

class WorldDisplay
{
    private int width;
    private int height;
    private NoiseGen LargeHeight = new NoiseGen(scale: 10.0f);
    private NoiseGen MidHeight = new NoiseGen(scale: 5.0f);
    private NoiseGen SmallHeight = new NoiseGen(scale: 1.0f);
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
                    LargeHeight.perlinNoise(x + xOffset, y + yOffset, 0.0f + zOffset) * 0.7f +
                    MidHeight.perlinNoise(x + xOffset, y + yOffset, 0.0f + zOffset) * 0.2f +
                    SmallHeight.perlinNoise(x + xOffset, y + yOffset, 0.0f + zOffset) * 0.1f;

                char[] shades = { ' ', ' ', ':', '-', '=', '+', '*', '#', '%', '@' };
                int shadeIndex = (int)((noiseValue + 1) / 2 * (shades.Length - 1));
                
                // Set color based on height
                if (shadeIndex < 3)
                    Console.ForegroundColor = ConsoleColor.Blue; // Water
                else if (shadeIndex < 5)
                    Console.ForegroundColor = ConsoleColor.Green; // Low land
                else if (shadeIndex < 7)
                    Console.ForegroundColor = ConsoleColor.Yellow; // Hills
                else
                    Console.ForegroundColor = ConsoleColor.White; // Mountains
                
                Console.Write(shades[shadeIndex]);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
}