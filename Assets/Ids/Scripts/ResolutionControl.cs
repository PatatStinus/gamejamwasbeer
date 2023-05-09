using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionControl : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;
    private List<Resolution> resolutionList;

    public float CurrentRefreshRate;
    public int CurrentResolution;
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionList = new List<Resolution>();

        resolutionDropdown.ClearOptions();
        CurrentRefreshRate = Screen.currentResolution.refreshRate;

        for (int i = 0; i < resolutions.Length; i++) 
        {
            if (resolutions[i].refreshRate == CurrentRefreshRate) 
            {
                resolutionList.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++) 
        {
            string resolutionOptions = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "hz";
            options.Add(resolutionOptions);
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height) 
            {
                CurrentResolution = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = CurrentResolution;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResoltion(int ResolutionIndex) 
    {
        Resolution resolution = Screen.resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
