using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterControl : MonoBehaviour {

    private Transform _transform;
    [SerializeField]
    private float _distanceFromPlatform = 10.0f;

    void Start()
    {
        _transform = transform;        
    }
    void FixedUpdate()
    {
        _transform.position = PlatformManager.instance._lastPlatform.transform.position - new Vector3(0, _distanceFromPlatform, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.gm.SaveScore();
            GameManager.gm.LoadScene(2);
        }
    }
}
