using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour {

    VideoPlayer videoPlayer;

	private void Start()
{
    videoPlayer.prepareCompleted += VideoPlayer_prepareCompleted;
    videoPlayer.Prepare();
}

private void VideoPlayer_prepareCompleted(VideoPlayer source)
{
    videoPlayer.Play();
} 
}
