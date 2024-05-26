using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [Header("Options")]
    public Slider volumeFX;
    public Slider volumeMaster;
    public Toggle mute;
    public AudioMixer mixer;
    public AudioSource fxSource;
    public AudioClip clickSound;
    
    private float lastVolumeMaster;
    private float lastVolumeFX;
    private bool isMuted = false;

    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject Options;
    public GameObject playPanel;

    private void Awake()
    {
        volumeFX.onValueChanged.AddListener(ChangeVolumeFX);
        volumeMaster.onValueChanged.AddListener(ChangeVolumeMaster);
        mute.onValueChanged.AddListener(SetMute);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetMute(bool isOn)
    {
        isMuted = isOn;
        float masterVolume = isMuted ? -80f : lastVolumeMaster;
        float fxVolume = isMuted ? -80f : lastVolumeFX;
        
        mixer.SetFloat("VolMaster", masterVolume);
        mixer.SetFloat("VolFX", fxVolume);
    }

    public void OpenPanel(GameObject panel)
    {
        mainPanel.SetActive(false);
        Options.SetActive(false);
        playPanel.SetActive(false);

        panel.SetActive(true);
        PlaySoundButton();
    }

    public void ChangeVolumeMaster(float v)
    {
        if (!isMuted)
        {
            mixer.SetFloat("VolMaster", v);
            lastVolumeMaster = v;
        }
    }

    public void ChangeVolumeFX(float v)
    {
        if (!isMuted)
        {
            mixer.SetFloat("VolFX", v);
            lastVolumeFX = v;
        }
    }

    public void PlaySoundButton()
    {
        if (!isMuted && fxSource != null && clickSound != null)
        {
            fxSource.PlayOneShot(clickSound);
        }
    }
}