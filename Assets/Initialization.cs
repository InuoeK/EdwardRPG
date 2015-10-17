using UnityEngine;
using System.Collections;

// Collection of init functions

public class Initialization : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        loadData();

        // load the actual game once everything else is done
        loadMainGame();
    }

    void loadData()
    {
    }

    void loadMainGame()
    {
        Application.LoadLevel("GameScene");
    }
}
