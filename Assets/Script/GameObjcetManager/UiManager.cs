using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        PopDownAllPanpel();
    }
    #region Main Menu

    public void NewGame()
    {
        SceneManager.LoadScene("Game");
        PopDownAllPanpel();
        mainMenu.SetActive(false);
    }

    

    public void PopDownAllPanpel()
    {
        infomationPanpel.SetActive(false);
        settingPanpel.SetActive(false);
    }

    public void PopUpSettingPanpel() 
    {
        PopDownAllPanpel();
        settingPanpel.SetActive(true);
    }

    public void PopUpInfomationPanpel()
    {
        PopDownAllPanpel();
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
}
