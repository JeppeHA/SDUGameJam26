using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MMButtonAppear : MonoBehaviour
{
    public Image btn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(BtnApear());
    }

    
    IEnumerator BtnApear()
    {
        btn.enabled = false;
        yield return new WaitForSeconds(25);
        btn.enabled = true;
    }
    
}
