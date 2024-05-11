using System.Collections;
using System.Collections.Generic;
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
  private float lastvolume;

  [Header("Panels")]
  public GameObject mainPanel;
  public GameObject Options;
  public GameObject playPanel;

  private void Awake()
  {
    volumeFX.onValueChanged.AddListener(ChangevolumeFX);
    volumeMaster.onValueChanged.AddListener(ChangeVolumeMaster);
  }

  public void SetMute()
  {
    if (mute.isOn)
    {
    mixer.GetFloat("volMaster",out lastvolume);
    mixer.SetFloat("volMaster", -80);
    }
    else
    mixer.SetFloat("volMaster", lastvolume);
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
    mixer.SetFloat("volMaster", v);
  }
  public void ChangevolumeFX(float v)
  {
    mixer.SetFloat("volFX", v);
  }
  public void PlaySoundButton()
  {
    fxSource.PlayOneShot(clickSound);
  }
  
}
