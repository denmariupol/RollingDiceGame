using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

    public Text wave;
    public Text mobsLeft;
    public Text preWaveTimer;
    public Slider playerHealthSlider;
    public Text playerLoose;
    public Text playerWin;
    public Text playerHealthText;
    private int mobsInWave;

	void Start ()
    {
        HidePreWaveTimer();
        playerLoose.gameObject.SetActive(false);
        playerWin.gameObject.SetActive(false);
    }


    public void PreWaveTimer(int timer)
    {
        preWaveTimer.gameObject.SetActive(true);
        preWaveTimer.text = "New wave in :" + timer.ToString();
        mobsLeft.gameObject.SetActive(false);
        wave.gameObject.SetActive(false);
    }


    public void HidePreWaveTimer()
    {
        preWaveTimer.gameObject.SetActive(false);
        mobsLeft.gameObject.SetActive(true);
        wave.gameObject.SetActive(true);
    }


    public void Wave(int w)
    {
        wave.text = "Wave : " + w.ToString();
    }


    public void MobsInWave(int count)
    {
        mobsInWave = count;
        mobsLeft.text = "Mobs left :" + count.ToString();
    }


    public void PlayerHealthSlider(float fullhealth,float currentHealth)
    {
        playerHealthSlider.value = currentHealth / fullhealth;
    }


    public void MobsLeft()
    {
        mobsInWave--;
        mobsLeft.text = "Mobs left :" + mobsInWave.ToString();
    }


    public void PlayerLoose()
    {
        playerHealthText.gameObject.SetActive(false);
        wave.gameObject.SetActive(false);
        mobsLeft.gameObject.SetActive(false);
        preWaveTimer.gameObject.SetActive(false);
        playerHealthSlider.gameObject.SetActive(false);
        playerLoose.gameObject.SetActive(true);
    }

    public void PlayerWin()
    {
        playerHealthText.gameObject.SetActive(false);
        wave.gameObject.SetActive(false);
        mobsLeft.gameObject.SetActive(false);
        preWaveTimer.gameObject.SetActive(false);
        playerHealthSlider.gameObject.SetActive(false);
        playerWin.gameObject.SetActive(true);
    }
}
