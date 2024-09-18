using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{

    public Button[] buttons;
    public CharacterToggle toggle;

    private void Start()
    {
        buttons = GetComponentsInChildren<Button>();
        toggle = GetComponentInChildren<CharacterToggle>();

        if (buttons.Length > 0)
            for (int i = 0; i < buttons.Length; i++)
            {
                int currentNumber = i;
                buttons[currentNumber].onClick.AddListener(() => toggle.ToggleCharacter(currentNumber));
            }

    }

}
