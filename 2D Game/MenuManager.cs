using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Button")]
    public GameObject gameSet;
    public GameObject optionSet;
    public GameObject exit;
    public Animator gameSetAnim;
    public Animator optionSetAnim;
    public Animator exitAnim;
    public Animator whiteColorAnim;
    public Button gamePlayBtn;
    public Button optionBtn;
    public Button exitBtn;
    public Text dayText;
    public Image whiteColor;

    [Header("Audio")]
    public AudioManager audioManager;

    private void Update()
    {
        if (gameSet.transform.localScale == new Vector3(1f, 1f, 1f) && Input.GetButtonDown("Cancel"))
            GamePlayOnESC();
        else if (optionSet.transform.localScale == new Vector3(1f, 1f, 1f) && Input.GetButtonDown("Cancel"))
            OptionOnESC();
        else if (exit.transform.localScale == new Vector3(1f, 1f, 1f) && Input.GetButtonDown("Cancel"))
            ExitOnEsc();
        else if (gameSet.transform.localScale == new Vector3(0f, 0f, 0f) && optionSet.transform.localScale == new Vector3(0f, 0f, 0f)
            && exit.transform.localScale == new Vector3(0f, 0f, 0f) && Input.GetButtonDown("Cancel"))
            ClickExit();

        if (whiteColor.transform.localPosition == new Vector3(0, 0, 0))
        {
            audioManager.BgmFadeOut();
        }
    }

    // Btn Reset
    public void InitBtnState()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }

    // Game Play Btn
    public void ClickGamePlay()
    {
        gameSet.transform.localPosition = new Vector3(0, -230, 0);
        gameSetAnim.SetTrigger("Bounce");
        /* quick fix timer
         * dayText.text = DateTime.Now.ToString(("yyyy. MM. dd. HH:mm")); 
         */

        audioManager.ClickPlay();
    }
    public void GamePlayExit()
    {
        gameSetAnim.SetTrigger("UnBounce");

        audioManager.ClickPlay();
    }
    public void GamePlayOnESC()
    {
        gameSetAnim.SetTrigger("UnBounce");
    }
    public void NewGame()
    {
        whiteColor.transform.localPosition = new Vector3(0, 0, 0);
        whiteColorAnim.SetTrigger("FadeIn");

        audioManager.NextScenePlay();

        Invoke("NextScene", 2.0f);
    }
    public void ContinueGame()
    {

    }

    // Option Btn
    public void ClickOption()
    {
        optionSet.transform.localPosition = new Vector3(0, -210, 0);
        optionSetAnim.SetTrigger("Bounce");

        audioManager.ClickPlay();
    }
    public void OptionExit()
    {
        optionSetAnim.SetTrigger("UnBounce");

        audioManager.ClickPlay();
    }
    public void OptionOnESC()
    {
        optionSetAnim.SetTrigger("UnBounce");
    }

    // Exit Btn
    public void ClickExit()
    {
        exit.transform.localPosition = new Vector3(0, 0, 0);
        exitAnim.SetTrigger("Bounce");

        audioManager.ClickPlay();

        // Off interactable other btn
        gamePlayBtn.interactable = false;
        optionBtn.interactable = false;
        exitBtn.interactable = false;
    }
    public void ExitExit()
    {
        exitAnim.SetTrigger("UnBounce");

        audioManager.ClickPlay();

        // On interactable other btn
        gamePlayBtn.interactable = true;
        optionBtn.interactable = true;
        exitBtn.interactable = true;
    }
    public void ExitOnEsc()
    {
        exitAnim.SetTrigger("UnBounce");
        gamePlayBtn.interactable = true;
        optionBtn.interactable = true;
        exitBtn.interactable = true;
    }

    // Escape Game
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit() 
#endif
    }

    // Next Scene
    public void NextScene()
    {
        SceneManager.LoadScene("2Prologue");
    }
}