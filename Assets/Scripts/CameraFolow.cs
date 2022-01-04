using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    public GameObject _player;
    public Vector3 _playerToCameraOffset;

    private void OnCollisionEnter(Collision collision)
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = _player.transform.position + _playerToCameraOffset;
        transform.position = position;
      
    }
}
