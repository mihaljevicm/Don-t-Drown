using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {

    public static PlatformManager instance;

    public List<GameObject> Platforms = new List<GameObject>();

    public Vector2 OffsetX = Vector2.zero;
    public Vector2 OffsetY = Vector2.zero;
    public Vector2 OffsetZ = Vector2.zero;

    private int _numberOfPlatforms; //number of platforms added to the list
    [Header("Read-only")]
    public GameObject _lastPlatform;

    private Transform _transform;

    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _transform = transform;
        _numberOfPlatforms = Platforms.Count;

        for (int i = 0; i < _numberOfPlatforms; i++)
        {
            GenerateNewPlatform();
        }
    }
    
    public void GenerateNewPlatform()
    {
        float randomXOffset = Random.Range(OffsetX.x, OffsetX.y);
        float randomZOffset = Random.Range(OffsetZ.x, OffsetZ.y);
        float newYposition = Random.Range(OffsetY.x, OffsetY.y);
        if(_lastPlatform == null) //if there is no last platform, make one
        {
            GameObject firstPlatform = Instantiate(Platforms[Random.Range(0, _numberOfPlatforms)], _transform.position, Quaternion.identity);
            _lastPlatform = firstPlatform; 
            _lastPlatform.transform.SetParent(_transform); //attach this platform to PlatformManager
        }
        if (_lastPlatform)
        {
            newYposition += _lastPlatform.transform.position.y;
        }

        Vector3 newPosition = new Vector3(_transform.position.x + randomXOffset,
                                            newYposition,
                                            _lastPlatform.transform.position.z + randomZOffset);

        GameObject newPlatform = Platforms[Random.Range(0,_numberOfPlatforms)];

        GameObject platformClone = Instantiate(newPlatform, newPosition, Quaternion.identity);
        platformClone.transform.SetParent(_transform);

        _lastPlatform = platformClone;
    }
}
