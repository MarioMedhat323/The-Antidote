using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationController : MonoBehaviour
{
    public void GoToIntoScene()
    {
       Application.LoadLevel(0);
    }
    public void GoToGameOverScene()
    {
       Application.LoadLevel(1);
    }
    public void GoToVictoryScene()
    {
        Application.LoadLevel(2);
    }
    public void GoToLevelSelect()
    {
        Application.LoadLevel(3);
    }
    public void GoToNewGame()
    {
       Application.LoadLevel(4);
    }
    public void GoToLoneTwo()
    {
        Application.LoadLevel(5);
    }
    public void GoToLtwoOne()
    {
        Application.LoadLevel(6);
    }
    public void GoToLtwoTwo()
    {
        Application.LoadLevel(7);
    }
    public void GoToLthreeOne()
    {
        Application.LoadLevel(8);
    }
    public void GoToLthreeTwo()
    {
        Application.LoadLevel(9);
    }

    public void Quit()
    {
        Application.Quit();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}