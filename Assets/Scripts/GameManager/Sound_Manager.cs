using UnityEngine;
using UnityEngine.UI;

public class Sound_Manager : MonoBehaviour
{
    public static Sound_Manager instance;
    [SerializeField] Slider volumeSlider;
    float volume;
    void Start()
    {
        if (instance == null) instance = this;
        Load();
        ChangeVolume();
        volume = volumeSlider.value;
    }
    private void Update() {
        if (volume != volumeSlider.value){
            volume = volumeSlider.value;
            PlayerPrefs.SetFloat("volume", volume);
        }
    }

    public void ChangeVolume() {
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    private void Load() {
        volumeSlider.value = PlayerPrefs.GetFloat("volume", 1);
    }
    private void Save() {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }
}
