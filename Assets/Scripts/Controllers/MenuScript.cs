using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class MenuScript : MonoBehaviour
    {
        public void LoadScene(int index) => SceneManager.LoadScene(index);
        
        public void ExitGame() => Application.Quit();
    }
}
