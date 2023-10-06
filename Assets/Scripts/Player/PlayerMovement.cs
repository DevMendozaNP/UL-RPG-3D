using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 speed = new Vector3(4f, 0f, 4f);

    private Rigidbody rb;
    private Vector2 moveDir;
    private Animator animator;
    private PlayerInput playerInput;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        DialogManager.Instance.OnDialogStart += OnDialogStartDelegate;
        DialogManager.Instance.OnDialogFinish += OnDialogFinishDelegate;
    }

    private void Update()
    {
        moveDir.Normalize();
        rb.velocity = new Vector3(
            moveDir.x * speed.x,
            rb.velocity.y,
            moveDir.y * speed.z
        );
    }
    
    public void OnDialogStartDelegate(Interaction interaction)
    {
        //Cambiar el input map a modo Dialog
        playerInput.SwitchCurrentActionMap("Dialog");
    }

    public void OnDialogFinishDelegate()
    {
        //Cambiar el input map a modo Player
        playerInput.SwitchCurrentActionMap("Player");
    }

    private void OnMovement(InputValue value)
    {
        moveDir = value.Get<Vector2>();
        if(Mathf.Abs(moveDir.x) > Mathf.Epsilon ||
           Mathf.Abs(moveDir.y) > Mathf.Epsilon)
        {
            animator.SetBool("IsWalking", true);
            animator.SetFloat("Horizontal", moveDir.x);
            animator.SetFloat("Vertical", moveDir.y);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    private void OnNextInteraction(InputValue value)
    {
        if(value.isPressed)
        {
            //Siguiente dialogo
            Debug.Log("Siguiente dialogo");
            DialogManager.Instance.NextDialog();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Dialog dialog = other.collider.transform.GetComponent<Dialog>();
        if (dialog != null)
        {
            // Iniciar sistema de dialogos
            DialogManager.Instance.StartDialog(dialog);
        }
    }
}
