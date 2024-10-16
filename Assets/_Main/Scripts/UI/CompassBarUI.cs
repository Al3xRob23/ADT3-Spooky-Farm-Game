using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassBarUI : MonoBehaviour
{

    public RawImage compassImage;
    public Transform player;

    public GameObject iconPrefab;
    List<QuestMarkers> questMarkers = new List<QuestMarkers>();

    float compassUnit;

    public QuestMarkers one;
    public QuestMarkers two;
    public QuestMarkers three;
    public QuestMarkers four;
    public QuestMarkers nPCMarker;
    public QuestMarkers shotgunMarker;

    public float maxDistance = 200f;
    private void Start()
    {
        compassUnit = compassImage.rectTransform.rect.width / 360f;

        AddQuestMarker(one);
        AddQuestMarker(two);
        AddQuestMarker(three);
        AddQuestMarker(four);
        AddQuestMarker(nPCMarker);
        AddQuestMarker(shotgunMarker);
    }

    private void Update() 
    {
        compassImage.uvRect = new Rect (player.localEulerAngles.y / 360f, 0f, 1f, 1f);

        foreach(QuestMarkers markers in questMarkers)
        {
            if (markers.image != null)
            {
                markers.image.rectTransform.anchoredPosition = GetPosOnCompass(markers);
            }

            //float dst = Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.z), markers.position);
            //float scale = 0f;

            //if (dst < maxDistance)
            //{
            //    scale = 1f - (dst / maxDistance);
            //}

            //markers.image.rectTransform.localScale = Vector3.one * scale;
        }
    }

    public void AddQuestMarker(QuestMarkers marker)
    {
        GameObject newMarker = Instantiate(iconPrefab, compassImage.transform);
        marker.image = newMarker.GetComponent<Image>();
        marker.image.sprite = marker.icon;

        questMarkers.Add(marker);
    }

    Vector2 GetPosOnCompass(QuestMarkers marker)
    {
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.z);
        Vector2 playerFwd = new Vector2(player.transform.forward.x, player.transform.forward.z);

        float angle = Vector2.SignedAngle(marker.position - playerPos, playerFwd);

        //Debug.Log(new Vector2(compassUnit * angle, 0f));

        return new Vector2(compassUnit * angle, 0f);
    }
}
