using UnityEngine;
using UnityEngine.UI;

public class CharacterToggle : MonoBehaviour
{
    public Image[] images;
    public int index = 0;


    private void Start()
    {
        images = GetComponentsInChildren<Image>(true);
    }

    //0: preButton > --
    //1: nextButton > ++
    //V
    //index == i > active charaterImage 
    public void ToggleCharacter(int isNext)
    {
        index = isNext == 1 ? ++index : --index;
        if (index == images.Length)
            index = 0;
        else if (index == -1)
            index = images.Length - 1;
        for (int i = 0; i < images.Length; i++)
        {
            if (index != i)
                images[i].gameObject.SetActive(false);
            else
            {
                images[i].gameObject.SetActive(true);
                FindObjectOfType<SpriteRendererManager>().spriteRenderer.sprite = images[i].GetComponent<SpriteRenderer>().sprite;
                FindObjectOfType<Player>().animator.runtimeAnimatorController = images[i].GetComponent<Animator>().runtimeAnimatorController;
            }

        }
    }
}
