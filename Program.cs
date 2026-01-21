Console.WriteLine("Hello, World!");

// Display the world

WorldDisplay world = new WorldDisplay(50, 300);

for(float z = 0; z < 1.0f; z += 1.0f)
{
    Console.Clear();
    world.displayWorld(0.0f, 0.0f, z);
    System.Threading.Thread.Sleep(100);
}