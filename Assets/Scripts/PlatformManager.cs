using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] List<GameObject> platforms = new List<GameObject>();
    [SerializeField] List<GameObject> clouds = new List<GameObject>();
    [SerializeField] GameObject jumpPad;
    [SerializeField] GameObject superPad;

    [Header("Settings Platforms")]
    [SerializeField] float platformScaleHorizontalMin = 0.5f;
    [SerializeField] float platformScaleHorizontalMax = 2.5f;
    [SerializeField] float distanceBetweenPlatformsMin = 0.5f;
    [SerializeField] float distanceBetweenPlatformsMax = 2.5f;
    [SerializeField][Range(0,100)] float movingPlatformChance = 15f;
    [SerializeField] float movingPlatformSpeedMin = 0.6f;
    [SerializeField] float movingPlatformSpeedMax = 1.8f;

    [Header("Settings JumpPad")]
    [SerializeField][Range(0, 100)] float jumpPadChance = 100f;
    [SerializeField][Range(0, 100)] float superPadChance = 15f;

    [Header("Settings Platforms")]
    [SerializeField] float cloudScaleMin = 0.5f;
    [SerializeField] float cloudScaleMax = 1.7f;
    [SerializeField] float distanceBetweenCloudsMin = 6f;
    [SerializeField] float distanceBetweenCloudsMax = 20f;
    [SerializeField] float cloudSpeedMin = 0.3f;
    [SerializeField] float cloudSpeedMax = 1.2f;


    float lastPlatformY = -4;
    float lastCloudY = -4;
    void Start()
    {
        foreach(GameObject platform in platforms)
        {
            PlatformPooling(platform);
        }

        foreach (GameObject cloud in clouds)
        {
            CloudPooling(cloud);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject platform in platforms)
        {
            if (platform.transform.position.y <= CameraScript.Instance.deathZone.position.y)
            {
                PlatformPooling(platform);
            }
        }

        foreach (GameObject cloud in clouds)
        {
            if (cloud.transform.position.y <= CameraScript.Instance.deathZone.position.y)
            {
                CloudPooling(cloud);
            }
        }
    }

    void PlatformPooling(GameObject platform)
    {
        if(platform.transform.childCount>0)
        {
            Destroy(platform.transform.GetChild(0).gameObject);
        }

        MovingPlatform movingPlatform = platform.GetComponent<MovingPlatform>();
        movingPlatform.enabled = false;


        float x = Random.Range(-2.7f, 2.7f);
        float y = Random.Range(distanceBetweenPlatformsMin, distanceBetweenPlatformsMax);
        lastPlatformY += y;

        platform.transform.localScale = new Vector3(Random.Range(platformScaleHorizontalMin, platformScaleHorizontalMax), platform.transform.localScale.y, platform.transform.localScale.z);
        platform.transform.position = new Vector3(x, lastPlatformY, 1);

        int random = Random.Range(0, 100);
        if (random <= movingPlatformChance)
        {
            movingPlatform.speed = Random.Range(movingPlatformSpeedMin, movingPlatformSpeedMax);
            movingPlatform.enabled = true;
        }

        random = Random.Range(0, 100);

        if(random <= jumpPadChance)
        {
            GameObject newJumpPad;


            random = Random.Range(0, 100);

            if (random < superPadChance)
            {
                newJumpPad = Instantiate(superPad);
            }
            else
            {
                newJumpPad = Instantiate(jumpPad);
            }

            newJumpPad.transform.position = (platform.transform.position + new Vector3(0,0.225f,0));
            newJumpPad.transform.parent = platform.transform;
        }
    }

    void CloudPooling(GameObject cloud)
    {
        float x = Random.Range(-2.7f, 2.7f);
        float y = Random.Range(distanceBetweenCloudsMin, distanceBetweenCloudsMax);
        lastCloudY += y;

        float randomScale = Random.Range(cloudScaleMin, cloudScaleMax);
        cloud.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        cloud.transform.position = new Vector3(x, lastCloudY, 1);

        cloud.GetComponent<MovingPlatform>().speed = Random.Range(cloudSpeedMin, cloudSpeedMax);
        }
    }

