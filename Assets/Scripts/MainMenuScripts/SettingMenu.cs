using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public GameObject settingPanel;

    public Slider volumeSlider;
    public TMP_Dropdown resolutionDropdown;

    private float originalVolume;
    private int originalResolutionIndex;

    private void Start()
    {
        // Сохраняем оригинальные настройки при открытии панели настроек
        originalVolume = PlayerPrefs.GetFloat("Volume", 0.5f);
        originalResolutionIndex = PlayerPrefs.GetInt("Resolution", 0);

        // Устанавливаем начальные значения
        volumeSlider.value = originalVolume;
        resolutionDropdown.value = originalResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleSettingPanel();
        }
         
    }

    // Метод для открытия панели настроек
    public void ToggleSettingPanel()
    {
        settingPanel.SetActive(true);
    }

    // Метод для закрытия панели настроек без сохранения изменений
    public void CloseSettingPanel()
    {
        settingPanel.SetActive(false);
    }

    // Метод для обработки изменения громкости
    public void OnVolumeChanged()
    {
        float volume = volumeSlider.value;
        AudioListener.volume = volume;
    }

    // Метод для обработки изменения разрешения
    public void OnResolutionChanged()
    {
        int selectedIndex = resolutionDropdown.value;
        // Реализуйте здесь логику для изменения разрешения экрана
        // Пример:
        if (selectedIndex == 0)
        {
            Screen.SetResolution(1920, 1080, true);
        }
        else if (selectedIndex == 1)
        {
            Screen.SetResolution(1280, 720, true);
        }

        // Сохраняем индекс разрешения в настройках
        PlayerPrefs.SetInt("Resolution", selectedIndex);
        PlayerPrefs.Save();
    }

    // Метод для сохранения настроек
    public void SaveSettings()
    {
        float volume = volumeSlider.value;
        int resolutionIndex = resolutionDropdown.value;

        // Сохраняем настройки
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.SetInt("Resolution", resolutionIndex);
        PlayerPrefs.Save();

        // Закрываем панель настроек
        settingPanel.SetActive(false);
    }

    // Метод для отмены изменений настроек
    public void CancelSettings()
    {
        // Восстанавливаем оригинальные настройки
        volumeSlider.value = originalVolume;
        resolutionDropdown.value = originalResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Закрываем панель настроек
        settingPanel.SetActive(false);
    }
}
