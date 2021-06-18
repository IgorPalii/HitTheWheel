using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField]
    private GameObject swordPref, gamePanel;

    public void SpawnSword()
    {
        if (gamePanel.activeSelf && 
            GameObject.Find("GameController").GetComponent<GameController>().currentShield != null)
        {
            GameObject obj = Instantiate(swordPref);
            obj.transform.position = transform.position;
            obj.GetComponent<SpriteRenderer>().color =
                new Color(
                Random.Range(0.5f, 1f),
                Random.Range(0.5f, 1f),
                Random.Range(0.5f, 1f));
        }
    }
}
