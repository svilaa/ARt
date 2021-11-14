using UnityEngine;
using System.Collections;

public class AlterShapeQuad : MonoBehaviour {

    public AlterShapeEffect alterShapeManager;

    float initialTravelTime;
    float initialRotationVelocity;
    Vector3 initialScale;
    float travelTime;
    float currentTravelTime;
    float rotationVelocity;
    Vector3 rotationDirection;
    AlterShapeAnchorPoint startPoint;
    AlterShapeAnchorPoint endPoint;

    Renderer[] rendererFaces;

	// Use this for initialization
	void Start () {
        
	}

    public void Init(AlterShapeAnchorPoint anchorPoint, float initialTravelTime, float initialRotationVelocity, float initialScale)
    {
        this.startPoint = anchorPoint;
        this.endPoint = anchorPoint;
        this.initialTravelTime = initialTravelTime;
        this.initialRotationVelocity = initialRotationVelocity;
        this.initialScale = new Vector3(initialScale, initialScale, initialScale);
        rendererFaces = GetComponentsInChildren<Renderer>();
        StartTravel();
    }

    void StartTravel()
    {
        this.startPoint = endPoint;
        this.endPoint = alterShapeManager.GetRandomAnchorPoint(this.startPoint);
        rotationDirection = Random.insideUnitSphere;
        foreach(Renderer currentRenderer in rendererFaces)
        {
            currentRenderer.material = alterShapeManager.GetRandomMaterial();
        }
        RandomizeQuad();
        transform.position = startPoint.transform.position;
        currentTravelTime = 0f;
    }

    void RandomizeQuad()
    {
        this.travelTime = this.initialTravelTime * Random.Range(0.7f, 1.3f);
        this.rotationVelocity = this.initialRotationVelocity * Random.Range(0.5f, 1.5f);
        this.transform.localScale = this.initialScale * Random.Range(0.7f, 1.5f);
    }
	
	// Update is called once per frame
	void Update () {
        if(currentTravelTime < travelTime)
        {
            currentTravelTime += Time.deltaTime;
        }

        transform.position = Vector3.Lerp(startPoint.transform.position, endPoint.transform.position, currentTravelTime/travelTime);
        transform.Rotate(rotationDirection * rotationVelocity * Time.deltaTime);

        if(Vector3.Distance(this.transform.position, endPoint.transform.position) < 0.2f)
        {
            StartTravel();
        }
	}
}
