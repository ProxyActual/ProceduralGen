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
                    LargeHeight.perlinNoise(x + xOffset, y + yOffset, 0.0f + zOffset) * 0.7f +
                    MidHeight.perlinNoise(x + xOffset, y + yOffset, 0.0f + zOffset) * 0.2f +
                    SmallHeight.perlinNoise(x + xOffset, y + yOffset, 0.0f + zOffset) * 0.1f;

                printPosition(noiseValue);
            }
            Console.WriteLine();
        }
    }

    private void printPosition(float heightValue)
    {
        float heightScale = (heightValue + 1) / 2.0f;
        ConsoleColor [] colors = {
            ConsoleColor.DarkBlue,
            ConsoleColor.Blue,
            ConsoleColor.Yellow,
            ConsoleColor.Green,
            ConsoleColor.DarkGreen,
            ConsoleColor.DarkGray,
            ConsoleColor.Gray,
            ConsoleColor.White
        };
        char[] shades = {' ', '.', ':', '-', '=', '+', '*', '#', '%', '@'};
        int colorIndex = (int)(heightScale * (colors.Length - 1));
        int nextColorIndex = Math.Min(colorIndex + 1, colors.Length - 1);
        float colorBlend = (heightScale * (colors.Length - 1)) - colorIndex;
        Console.ForegroundColor = colors[colorIndex];
        Console.BackgroundColor = colors[nextColorIndex];
        int shadeIndex = (int)((1.0f - colorBlend) * (shades.Length));
        Console.Write(shades[shadeIndex]);
        Console.ResetColor();
    }
}