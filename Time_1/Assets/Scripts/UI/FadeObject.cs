using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeObject : MonoBehaviour
{
    [SerializeField] private Image img; 
    [SerializeField] private bool fadeIn;
    public float duration;
    void Start()
    {
        StartCoroutine(FadeImage(fadeIn));
    }
 
    IEnumerator FadeImage(bool fadeIn)
    {
        if (fadeIn)
        {
            for (float i = duration; i >= 0; i -= Time.deltaTime)
            {
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        else
        {
            for (float i = 0; i <= duration; i += Time.deltaTime)
            {
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        yield return null;
        Destroy(transform.gameObject);
    }
}
