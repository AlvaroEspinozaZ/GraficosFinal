using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class gameController : MonoBehaviour
{
    public GameObject inicio;
    public GameObject menu;
    private PlayerInput _playerInput;
    public InputActionAsset YourInputActionAsset;
    bool presionado;
    private void OnEnable()
    {
        YourInputActionAsset.FindActionMap("Player");
        YourInputActionAsset.FindAction("Pause");
        YourInputActionAsset.FindAction("Exit");
        var actionMap = YourInputActionAsset.FindActionMap("Player");
        var action = actionMap.FindAction("Pause");
        action.performed += Pause;
        var action2 = actionMap.FindAction("Exit");
        action2.performed += Exit;

    }
    void Start()
    {
        StartCoroutine(Inicio());
        _playerInput = GetComponent<PlayerInput>();
        presionado = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    
    IEnumerator Inicio()
    {
        yield return new WaitForSecondsRealtime(1);
        inicio.SetActive(false);
    }
    private void Pause(InputAction.CallbackContext context)
    {        
        float inputValue = context.ReadValue<float>();

        if (context.control.name == "p" && inputValue == 1f)
        {
            if (presionado)
            {
                menu.SetActive(false);
                Time.timeScale = 1;
                presionado = false;
            }
            else
            {
                menu.SetActive(true);
                Time.timeScale = 0;
                presionado = true;
            }
            
        }
    }
    private void Exit(InputAction.CallbackContext context)
    {
        float inputValue = context.ReadValue<float>();

        if (inputValue == 1f)
        {
            // Envía un mensaje a todos los scripts en el objeto actual con el nombre "OnPKeyPressed"
            ReloadScene();
        }
    }
}
