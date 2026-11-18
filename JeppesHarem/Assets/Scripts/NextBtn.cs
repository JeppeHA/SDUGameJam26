using UnityEngine;

public class NextBtn : MonoBehaviour
{
    SceneFader sceneFader;

    private void Start()
    {
        sceneFader = FindFirstObjectByType<GameManager>().GetComponent<SceneFader>();
    }
    public void PressBtn()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Card"))
        {
            Destroy(item);
        }

        sceneFader.FadeAndLoadScene("Map");
    }
}
