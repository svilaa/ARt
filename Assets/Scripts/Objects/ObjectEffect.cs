using UnityEngine;
using System.Collections;

public class ObjectEffect : MonoBehaviour {

    public EffectItemsEnum.EffectItem effectItem;
    public float value = 1;
    int mainCharacterLayer;
    float lifeTime = 10f;

    // Use this for initialization
    void Start () {
        mainCharacterLayer = LayerMask.NameToLayer("MainCharacter");
        Destroy(this.gameObject, lifeTime);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == mainCharacterLayer)
        {
            EffectsController.Instance.AddCollectedObject(this);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            Destroy(gameObject, audio.clip.length);
        }
    }
}
