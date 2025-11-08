using UnityEngine;
using UnityEngine.SceneManagement;

public class WormHole : YamiMonoBehaviour
{
    protected string sceneName = "GalaxyDemo";
    protected virtual void OnMouseDown()
    {
        this.LoadGalaxy();
    }
    protected virtual void LoadGalaxy()
    {
        SceneManager.LoadScene(this.sceneName);
    }
}
