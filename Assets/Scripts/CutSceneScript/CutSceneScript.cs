using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutSceneScript : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName;

    private void Start()
    {
        videoPlayer.loopPointReached += EndReached;
    }

    private void EndReached(VideoPlayer vp)
    {
        SceneManager.LoadSceneAsync(nextSceneName);
    }
}
