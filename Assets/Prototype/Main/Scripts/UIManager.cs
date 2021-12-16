using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text HealthText;

    [SerializeField] private Button menuButton;
    [SerializeField] private Button closemenuButton;
    [SerializeField] private GameObject popupMenu;

    [SerializeField] private Slider slider;

    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private Image picture;

    private void Start()
    {
        gameManager.OnScoreChanged += ChangeScoreText;
        gameManager.OnWrongClick += SetHaelthSlider;
    }
    
    private void ChangeScoreText(int score)
    {
        ScoreText.text = score.ToString();
    }


    private void SetHaelthSlider(int health)
    {
        slider.value = health;
 
    }

    

    public void OnClickMenuButton()
    {
        popupMenu.SetActive(true);
    }

    public void OnClickClosemenuButton()
    {
        popupMenu.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }



}
