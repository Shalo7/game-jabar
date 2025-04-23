using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject congklakMenuPanel;
    public GameObject lompatTaliMenuPanel;
    public GameObject thumbnailCover;

    public CongklakAnimasi congklakAnimasi;
    public TaliAnimasi taliAnimasi;

    void Start()
    {
        // Di awal, hanya main menu yang aktif
        mainMenuPanel.SetActive(true);
        congklakMenuPanel.SetActive(false);
        lompatTaliMenuPanel.SetActive(false);
    }

    public void OpenPilihGame()
    {

        mainMenuPanel.SetActive(true);
        congklakMenuPanel.SetActive(false);
        lompatTaliMenuPanel.SetActive(false);
        thumbnailCover.SetActive(false);
    }
    

public void OpenCongklakMenu()
    {
        mainMenuPanel.SetActive(false);
        congklakMenuPanel.SetActive(true);
        lompatTaliMenuPanel.SetActive(false);
        congklakAnimasi.ShowCongklakMenu();
    }

    public void OpenLompatTaliMenu()
    {
        mainMenuPanel.SetActive(false);
        congklakMenuPanel.SetActive(false);
        lompatTaliMenuPanel.SetActive(true);
        taliAnimasi.AnimateTali();
    }

    public void BackToMainMenu()
    {
        mainMenuPanel.SetActive(true);
        congklakMenuPanel.SetActive(false);
        lompatTaliMenuPanel.SetActive(false);
    }

    public void GoToCongklakScene()
    {
        SceneManager.LoadScene("SceneCongklak");
    }

    public void GoToLompatTaliScene()
    {
        SceneManager.LoadScene("SceneLompatTali");
    }


}
