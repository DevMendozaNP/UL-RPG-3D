using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance { get; private set; }

    #region Eventos
    public event UnityAction<Interaction> OnDialogStart;
    public event UnityAction<Interaction> OnDialogNext;
    public event UnityAction OnDialogFinish;
    #endregion

    private Dialog currentDialog = null;
    private int currentDialogIndex = 0;
    private void Awake()
    {
        Instance = this;
    }

    public void StartDialog(Dialog dialog)
    {
        currentDialogIndex = 0;
        currentDialog = dialog;
        Debug.Log("Se inicia el dialogo");
        OnDialogStart?.Invoke(dialog.interactions[currentDialogIndex]);
    }

    public void NextDialog()
    {
        currentDialogIndex++;
        if (currentDialogIndex < currentDialog.interactions.Count)
        {
            Interaction nextInteraction = currentDialog.interactions[currentDialogIndex];
            OnDialogNext?.Invoke(nextInteraction);
        }
        else
        {
            FinishDialog();
        }
    }

    public void FinishDialog()
    {
        OnDialogFinish?.Invoke();
    }
}
