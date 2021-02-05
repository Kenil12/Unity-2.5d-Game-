using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void BubbleBurster()
    {
        SceneManager.LoadScene("A4G");
    }

    public void PainterMan()
    {
        SceneManager.LoadScene("Fresh");
    }

    public void CubeNinja()
    {
        SceneManager.LoadScene("Cninja");
    }

    public void HighScores()
    {
        SceneManager.LoadScene("HScore");
    }
}
