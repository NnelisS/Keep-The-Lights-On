using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FootstepGlow : MonoBehaviour
{
    [SerializeField] private RawImage footImage;

    private float alpha;

    private void Start()
    {

    }

    void Update()
    {
        footImage.CrossFadeAlpha(alpha = 255 - 255, 0.1f, false);
    }

    public void FootstepFade()
    {
        footImage.CrossFadeAlpha(alpha = 0 + 255 * Time.deltaTime, 0.4f, false);
    }
}
