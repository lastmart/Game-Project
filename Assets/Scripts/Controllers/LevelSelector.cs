using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelector : MonoBehaviour
{
    public void LoadScene(int index)
    {
        if (index is 3 or 5)
        {
            var menuMusic = GameObject.FindGameObjectWithTag("Menu_Music");
            Destroy(menuMusic);
        }
        SceneManager.LoadScene(index);
    }
}
