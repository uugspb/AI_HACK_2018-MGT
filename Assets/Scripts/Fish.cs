using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {

    [SerializeField]
    private FishConfig fishConfig;
    private SpriteRenderer spriteRenderer;

    public Vector3 target;

    void OnValidate()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = fishConfig.kindFish;
    }

    void Update () {
       target = getPosition();
       this.transform.position = Vector3.Lerp(this.transform.position, target, fishConfig.speed * Time.deltaTime);
       this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, target.y*10);
	}

    Vector3 getPosition()
    {
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
        return Camera.main.ScreenToWorldPoint(position);
    }
}
