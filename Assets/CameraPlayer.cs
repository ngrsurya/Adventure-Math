using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public int MusicToPlay;
    private bool musicStarted;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!musicStarted)
        {
            musicStarted = true;
            AudioManager.instance.PlayMusic(MusicToPlay);
        }
    }
}
