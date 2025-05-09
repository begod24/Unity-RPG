using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    public void LoadScene(string name) => SceneManager.LoadScene(name);
    public void Quit() => Application.Quit();
}