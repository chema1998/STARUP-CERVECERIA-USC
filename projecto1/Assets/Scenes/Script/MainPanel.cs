using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
  [Header("Options")]
  public Slider volumeFX;
  public Slider volumeMaster;
  public Toggle mute;
  [Header("Panels")]
  public GameObject mainPanel;
  public GameObject Options;
  public GameObject playPanel;

  public void OpenPanel(GameObject panel)
  {
    mainPanel.SetActive(false);
    Options.SetActive(false);
    playPanel.SetActive(false);

    panel.SetActive(true);
  }

}
