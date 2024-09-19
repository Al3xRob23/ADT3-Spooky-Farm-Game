using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestMarkers : MonoBehaviour
{
    public Sprite icon;
    public Image image;

    public Vector2 position
    {
        get { return new Vector2(transform.position.x, transform.position.z); }
    }

    public void OnDisable()
    {
        if (image != null)
        {
            Destroy(image.gameObject);
        }
    }
}
