using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamps : MonoBehaviour
{
    [Header("Lamps")]
    public List<GameObject> lamps = new List<GameObject>();
    public int current;

    public bool chooseLamp = false;
    public bool chosen = false;

    // Update is called once per frame
    void Update()
    {
        if (chooseLamp)
        {
            StartCoroutine(ChooseOutLamps());
        }

        if (chosen)
        {
            Debug.Log("yes");
            lamps[current].SetActive(false);
            lamps.RemoveAt(current);
            chosen = false;
        }
    }

    private IEnumerator ChooseOutLamps()
    {
        current = Random.Range(0, lamps.Count);
        chooseLamp = false;
        chosen = true;
        yield return current;
    }
}
