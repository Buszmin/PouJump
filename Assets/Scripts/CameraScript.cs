using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public static CameraScript Instance;
    [SerializeField] public Transform deathZone;
    Transform playerTransform;
    public float maxY;
    [SerializeField] float yCameraOffSet = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        playerTransform = PlayerController.Instance.transform;
        maxY = playerTransform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.y >= maxY)
        {
            maxY = playerTransform.position.y;
        }
        transform.position = new Vector3(transform.position.x, maxY + yCameraOffSet, transform.position.z);
    }
}
