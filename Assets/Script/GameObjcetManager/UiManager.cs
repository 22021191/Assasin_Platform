using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : Singleton<UiManager>
{
    [Header("Main Menu")]
    [SerializeField] private GameObject infomationPanpel;
    [SerializeField] private GameObject settingPanpel;
    [SerializeField] private GameObject mainMenu;

    [Header("Setting Panpel")]
    [SerializeField] private Button musicButton;
    [SerializeField] private Button sfxButton;
    [SerializeField] private Sprite onSfx,onMusic;
    [SerializeField] private Sprite offSfx,offMusic;
    [SerializeField] private Slider sfxSlider, musicSlider;

    [Header("End Game")]
    [SerializeField] private GameObject endGamePanpel;
    [SerializeField] private GameObject loss;
    [SerializeField] private GameObject Won;

    [Header("Orther")]
    [SerializeField] public Animator transitionAnim;
    [SerializeField] private PlayableDirector playable;
    public bool isTransition=false;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        playable.Stop();
    }
    private void Start()
    {
        PopDownAllPanpel();
        /*transitionAnim.SetBool("Start", false);
        transitionAnim.SetBool("End", true);*/
        transitionAnim.gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }
    #region Main Menu

    public void NewGame()
    {
        StartCoroutine(TransitionScene("Game"));
        
    }

    

    public void PopDownAllPanpel()
    {
        mainMenu.SetActive(false);
        infomationPanpel.SetActive(false);
        settingPanpel.SetActive(false);
        endGamePanpel.SetActive(false);
    }

    public void PopUpSettingPanpel() 
    {
        PopDownAllPanpel();
        mainMenu.SetActive(true) ;
        settingPanpel.SetActive(true);
    }

    public void PopUpInfomationPanpel()
    {
        PopDownAllPanpel();
        mainMenu.SetActive(true) ;
        infomationPanpel.SetActive(true);
    }
    #endregion

    #region Setting
    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
        if (!AudioManager.Instance.musicSource.mute)
        {
            musicButton.image.overrideSprite = onMusic;
        }
        else
        {
            musicButton.image.overrideSprite = offMusic;
        }
    }
    public void ToggleSfx()
    {
        AudioManager.Instance.ToggleSfx();
        if (!AudioManager.Instance.sfxSource.mute)
        {
            sfxButton.image.overrideSprite = onSfx;
        }
        else
        {
            sfxButton.image.overrideSprite = offSfx;
        }
    }

    public void SliderMusic()
    {
        AudioManager.Instance.MusicVolume(musicSlider.value);
    }

    public void SliderSfx()
    {
        AudioManager.Instance.SfxVolume(sfxSlider.value);
    }

    #endregion

    #region EndGame
    public void GoHome()
    {
        //GameManager.Instance.player.gameObject.SetActive(false);
        StartCoroutine(TransitionScene("Menu"));
    }

    public void EndGame()
    {
        PopDownAllPanpel();
        endGamePanpel.SetActive(true);
        if (GameManager.Instance.won)
        {
            Won.SetActive(true );
            loss.SetActive(false );
        }
        else
        {
            loss.SetActive(true);
            Won.SetActive(false);
        }
    }

    #endregion

    #region Orther
    IEnumerator TransitionScene(string sceneName)
    {
        transitionAnim.gameObject.SetActive(true);
        transitionAnim.SetBool("Start", true);
        transitionAnim.SetBool("End", false);
        yield return new WaitForSeconds(1.5f);
        PopDownAllPanpel();
        playable.Play();
        yield return new WaitForSeconds(15);
        transitionAnim.SetBool("Start", false);
        transitionAnim.SetBool("End", true);
        SceneManager.LoadScene(sceneName);
        AudioManager.Instance.PlayMusic("Theme"+sceneName);
        yield return new WaitForSeconds(2f);
        transitionAnim.gameObject.SetActive(false );
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public IEnumerator Transition(Vector3 pos)
    {
        yield return new WaitForSeconds(0.5f);

        transitionAnim.gameObject.SetActive(true);
        transitionAnim.SetBool("Start", true);
        transitionAnim.SetBool("End", false);
        yield return new WaitForSeconds(1.5f);
        PopDownAllPanpel();
        yield return new WaitForSeconds(0.5f);
        transitionAnim.SetBool("Start", false);
        transitionAnim.SetBool("End", true);
       /* GameManager.Instance.player.gameObject.SetActive(false);
        GameManager.Instance.player.input.enabled = false;
        GameManager.Instance.player.gameObject.transform.position = pos;*/
        yield return new WaitForSeconds(2f);
        //GameManager.Instance.player.gameObject.SetActive(true);
        transitionAnim.gameObject.SetActive(false);
    }
    #endregion
}
