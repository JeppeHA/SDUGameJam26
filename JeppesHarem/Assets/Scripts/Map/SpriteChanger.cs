using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    public Button button;
    public Sprite sprite;
    public void SpriteChange()
    {
        button.image.sprite = sprite;
    }
}