using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogUI : MonoBehaviour
{
    [SerializeField]
    private Transform characterImage;
    [SerializeField]
    private Transform characterText;
    [SerializeField]
    private Transform characterName;
    
    private void Start()
    {
        DialogManager.Instance.OnDialogStart += OnDialogStartDelegate;
        DialogManager.Instance.OnDialogNext += OnDialogNextDelegate;
        DialogManager.Instance.OnDialogFinish += OnDialogFinishDelegate;

        gameObject.SetActive(false);
    }

    private void OnDialogStartDelegate(Interaction interaction)
    {
        if (interaction != null)
        {
            gameObject.SetActive(true);
            ShowInteraction(interaction);
        }
    }

    private void OnDialogNextDelegate(Interaction interaction)
    {
        if (interaction != null)
        {
            ShowInteraction(interaction);
        }
    }

    private void OnDialogFinishDelegate()
    {
        gameObject.SetActive(false);
    }

    private void ShowInteraction(Interaction interaction)
    {
        characterImage.GetComponent<Image>().sprite = interaction.sprite;
        characterName.GetComponent<TextMeshProUGUI>().text = interaction.characterName;
        characterText.GetComponent<TextMeshProUGUI>().text = interaction.text;
    }
}
