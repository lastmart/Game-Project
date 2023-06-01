using UnityEngine;

public class CharLivesBar : MonoBehaviour
{
    private readonly Transform[] hearts = new Transform[3];
    public Character character;

    private void Awake()
    {
        for (var i = 0; i < hearts.Length; i++)
        {
            hearts[i] = transform.GetChild(i);
        }
    }

    public void Refresh()
    {
        for (var i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(i < character.lives);
        }
    }
}
