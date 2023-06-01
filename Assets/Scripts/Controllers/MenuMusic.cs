using UnityEngine;

namespace Controllers
{
    public class MenuMusic : MonoBehaviour
    {
        /*[Header("Tags")] 
        [SerializeField] public static string CreatedTag { get; }*/
        
        private void Awake()
        {
            var obj = GameObject.FindGameObjectWithTag("Menu_Music");
            if (obj != null)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.tag = "Menu_Music";
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}
