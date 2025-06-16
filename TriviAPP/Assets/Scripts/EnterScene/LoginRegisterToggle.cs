using UnityEngine;

public class LoginRegisterToggle : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject loginPanel;
    [SerializeField] private GameObject registerPanel;

    private void Start()
    {

    }

    public void ShowLoginPanel()
    {
        loginPanel.SetActive(true);
        registerPanel.SetActive(false);
        Debug.Log("Panel LOGIN activo");
    }

    public void ShowRegisterPanel()
    {
        loginPanel.SetActive(false);
        registerPanel.SetActive(true);
        Debug.Log("Panel REGISTRO activo");
    }
}
