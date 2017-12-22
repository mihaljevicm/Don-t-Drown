using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Platform")
        {
            Destroy(other.gameObject);
            GameManager.gm.PlatformCount(1);
            PlatformManager.instance.GenerateNewPlatform();
        }
    }
}
