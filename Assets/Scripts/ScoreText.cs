using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    void Update()
    {
        text.text = "Score: " + (int)(CameraScript.Instance.maxY + 3f);
    }
}
