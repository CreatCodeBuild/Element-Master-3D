using UnityEngine;
using System.Collections;

public struct Level {
    public string name;
    public int[] electrons;

    public Level(string name, int[] electrons)
    {
        this.name = name;
        this.electrons = electrons;
    }
}
