using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathFade : MonoBehaviour
{
    public bool fadeIn = false;
    private RawImage footImage;
    private float alpha;

    private void Start()
    {
        footImage = gameObject.GetComponent<RawImage>();
    }

    void Update()
    {
        if (fadeIn)
        {
            footImage.CrossFadeAlpha(alpha = 0 + 255 * Time.deltaTime, 1f, false);
        }
        else if (fadeIn == false)
        {
            footImage.CrossFadeAlpha(alpha = 255 - 255, 0.1f, false);
        }
    }
}
