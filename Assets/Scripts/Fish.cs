using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {

    [SerializeField]
    private FishConfig FishConfig;
    private SpriteRenderer SpriteRenderer;

    public Vector3 target;

    void OnValidate()
    {
        SpriteRenderer = this.GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = FishConfig.kindFish;
    }

    void Update () {
       target = getPosition();
       this.transform.position = Vector3.Lerp(this.transform.position, target, FishConfig.speed * Time.deltaTime);
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, target.y*10);
	}

    Vector3 getPosition()
    {
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
        return Camera.main.ScreenToWorldPoint(position);
    }
}
