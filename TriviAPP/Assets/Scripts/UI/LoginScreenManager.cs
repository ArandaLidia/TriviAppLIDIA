using UnityEngine;
using UnityEngine.SceneManagement;
public class LoginScreenManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject loginPanel;
    [SerializeField] private GameObject registerPanel;
    [SerializeField] private GameObject forgotPasswordPanel;
    [SerializeField] private string sceneToLoadFromLogin = "LoginScene";
    [SerializeField] private string sceneToLoadForRegister = "EnterScene";
    [SerializeField] private string sceneToLoadForMainMenu = "MainMenuScene";

    private void Start()
    {
        if (AuthScreenSettings.OpenRegisterPanel)
        {
           
            ShowRegisterPanel();
            AuthScreenSettings.OpenRegisterPanel = false; 
        }
        else
        {
            
            ShowLoginPanel();
        }
    }

    public void ShowLoginPanel()
    {
        Debug.Log("? Mostrando Panel Login");
        PanelSwitch(true);
        loginPanel.SetActive(true);
        registerPanel.SetActive(false);
        forgotPasswordPanel.SetActive(false);
    }

    public void ShowRegisterPanel()
    {
        Debug.Log("? Mostrando Panel Registro");
        PanelSwitch(false);
        loginPanel.SetActive(false);
        registerPanel.SetActive(true);
        forgotPasswordPanel.SetActive(false);
    }
    // Screen replacement method
    private void PanelSwitch(bool showLogin)
    {
        loginPanel.SetActive(showLogin);
        registerPanel.SetActive(!showLogin);
    }
    public void ShowForgotPasswordPanel()
    {
        Debug.Log("? Mostrando Panel de visualización de contraseña olvidada");
        loginPanel.SetActive(false);
        registerPanel.SetActive(false);
        forgotPasswordPanel.SetActive(true);
    }

    public void BackButton()
    {
        if (forgotPasswordPanel.activeSelf || registerPanel.activeSelf)
        {
            // If you are in the registration or password panel, go back to login
            ShowLoginPanel();
            Debug.Log(" Volver a LoginPanel");
        }
        else if (loginPanel.activeSelf)
        {
            // If you are in the login panel, switch to LoginScene
            SceneManager.LoadScene(sceneToLoadFromLogin);
            Debug.Log(" Cambiar a LoginScene");
        }
    }

    public void GoToRegisterPanel()
    {
        Debug.Log(" Cargando EnterScene con panel Registro activo.");
        AuthScreenSettings.OpenRegisterPanel = true;
        SceneManager.LoadScene(sceneToLoadForRegister);
    }

    public void GoToMainMenuScene() //test
    {
        Debug.Log(" Cambiando para el Menu Principal");
        SceneManager.LoadScene(sceneToLoadForMainMenu);
    }
}

