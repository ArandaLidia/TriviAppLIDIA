using UnityEngine;
using UnityEngine.UI;

public class ExitPanelManager : MonoBehaviour
{
    [Header("Panel de confirmación")]
    [Tooltip("Panel que aparece al pulsar Salir")]
    public GameObject panelConfirmExit;

    [Tooltip("Efecto de desenfoque de fondo (opcional)")]
    public GameObject panelBlurEffect;

    [Header("Botones")]
    public Button btnExit;   // Botón que abre el panel
    public Button btnYes;    // Botón de "Sí, salir"
    public Button btnNo;     // Botón de "No, cancelar"

    void Start()
    {
        panelConfirmExit.SetActive(false);
        if (panelBlurEffect != null)
            panelBlurEffect.SetActive(false);

        if (btnExit != null)
            btnExit.onClick.AddListener(ShowExitPanel);

        if (btnYes != null)
            btnYes.onClick.AddListener(ConfirmExit);

        if (btnNo != null)
            btnNo.onClick.AddListener(HideExitPanel);
    }

    /// <summary>
    /// Muestra el panel de confirmación.
    /// </summary>
    void ShowExitPanel()
    {
        if (panelBlurEffect != null)
            panelBlurEffect.SetActive(true);

        panelConfirmExit.SetActive(true);
    }

    /// <summary>
    /// Oculta el panel de confirmación.
    /// </summary>
    void HideExitPanel()
    {
        if (panelBlurEffect != null)
            panelBlurEffect.SetActive(false);

        panelConfirmExit.SetActive(false);
    }

    /// <summary>
    /// Confirma salida:
    /// - Si hay PhotonPrueba => LeaveRoom
    /// - Si no => cierra la app normal.
    /// </summary>
    void ConfirmExit()
    {
        PhotonPrueba photonPrueba = FindFirstObjectByType<PhotonPrueba>();

        if (photonPrueba != null)
        {
            Debug.Log("Encontrado PhotonPrueba → saliendo de la Room...");
            photonPrueba.LeaveRoomAndReturnToMenu();
        }
        else
        {
            Debug.Log(" No hay PhotonPrueba → cerrando la aplicación normal...");
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}
