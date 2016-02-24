using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public static class Game {

    public static int currentLevel = 0;
    public static Atom atom;
    public static UserPartical userPartical;

    public static Level[] levels =
    {
        new Level("Hydrogen", new int[] {1}),
        new Level("Helium", new int[] {2}),
        new Level("Lithium", new int[] {2,1}),
        new Level("Beryllium", new int[] {2,2}),
        new Level("Baron", new int[] {2,3}),
        new Level("Carbon", new int[] {2,4}),
        new Level("Nitrogen", new int[] {2,5}),
        new Level("Oxygen", new int[] {2,6}),
        new Level("Fluorine", new int[] {2,7}),
        new Level("Neon", new int[] {2,8})
    };

    public static Level getCurrentLevel()
    {
        return levels[currentLevel];
    }

    public static void initLevel()
    {
        //remove things from last level
        atom.removeElectrons();

        userPartical.toStartingPosition();
        atom.initElectrons();
    }

    public static void goToNextLevel()
    {
        currentLevel++;
        if(currentLevel < levels.Length)
        {
            initLevel();
        }
        else
        {
            MonoBehaviour.print("Last Level!");
        }
    }

    //dead, reload scene
    public static void handleCollision()
    {
        currentLevel = 0;
        initLevel();
    }
}
