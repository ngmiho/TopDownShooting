using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StorageButton : MonoBehaviour
{
    public Button button;
    public StorageUIManager StorageUIManager;

    private void Start()
    {
        if (StorageUIManager == null)
            StorageUIManager = FindObjectOfType<StorageUIManager>(true);

        if (button == null)
            button = GetComponent<Button>();

        if (button != null)
            button.onClick.AddListener(Select);
    }

    private void Select()
    {
        bool isActive = StorageUIManager.gameObject.activeSelf;
        TextMeshProUGUI textUI = GetComponentInChildren<TextMeshProUGUI>();
        StorageUIManager.gameObject.SetActive(!isActive);
    }

}
