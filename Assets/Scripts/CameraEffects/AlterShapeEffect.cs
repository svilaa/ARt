using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlterShapeEffect : CameraEffect
{
    public AlterShapeAnchorPoint anchorPoint;
    public AlterShapeQuad quad;
    public int numAnchors;
    public Material[] materials;

    List<AlterShapeAnchorPoint> anchorPoints;
    GameObject quadsParent;

    override
        protected void Init()
    {
        anchorPoints = new List<AlterShapeAnchorPoint>();
    }

    override
    public void AttachToCamera(Camera camera)
    {
        return;
        GameObject alterShape = new GameObject("AlterShape");
        alterShape.transform.SetParent(camera.transform, false);
        Vector3 alterShapeLocalPosition = alterShape.transform.localPosition;
        alterShapeLocalPosition.z += 3f;
        alterShape.transform.localPosition = alterShapeLocalPosition;
        GameObject anchorPointsParent = new GameObject("AnchorPoints");
        anchorPointsParent.transform.SetParent(alterShape.transform, false);
        quadsParent = new GameObject("Quads");
        quadsParent.transform.SetParent(alterShape.transform, false);

        float horizontalValue, verticalValue;
        //if(SaveData.GetInstance().userOptions.cameraType == CameraType.ORTOGRAPHIC)
        //{
        //    horizontalValue = (16f / 9f) * 2f;
        //    verticalValue = 12f;
        //} else
        //{
            horizontalValue = (16f / 9f) / 2f;
            verticalValue = 6f;
        //}

        for(float degrees=0; degrees<360; degrees+=360f/numAnchors)
        {
            AlterShapeAnchorPoint currentAnchorPoint = Instantiate(anchorPoint);
            currentAnchorPoint.Init(anchorPoints.Count);
            currentAnchorPoint.transform.SetParent(anchorPointsParent.transform, false);
            float radians = degrees * Mathf.Deg2Rad;
            currentAnchorPoint.transform.localPosition = new Vector3(Mathf.Sin(radians) * horizontalValue, Mathf.Cos(radians), 0f) * verticalValue;
            anchorPoints.Add(currentAnchorPoint);
        }
    }

    override
    protected void UpdateEffect()
    {
        return;
        float currentValue = GetEvaluatedEffectValue();
        int expectedNumQuads = (int)currentValue;
        int numQuads = quadsParent.transform.childCount;

        if (expectedNumQuads < numQuads)
        {
            Destroy(quadsParent.transform.GetChild(numQuads-1).gameObject);
        }

        if (expectedNumQuads > numQuads)
        {
            AlterShapeQuad currentQuad = Instantiate(quad);
            currentQuad.transform.SetParent(quadsParent.transform, false);
            currentQuad.alterShapeManager = this;
            currentQuad.Init(anchorPoints[Random.Range(0, anchorPoints.Count)], 3f, 100f,
                //SaveData.GetInstance().userOptions.cameraType == CameraType.ORTOGRAPHIC ? 3f : 1f
                1f
                );
        }
    }

    public AlterShapeAnchorPoint GetRandomAnchorPoint(AlterShapeAnchorPoint lastAnchorPoint)
    {
        int lastPosition = lastAnchorPoint.position;
        int maxMovements = 2;
        int newPosition = (lastPosition + anchorPoints.Count / 2) + Random.Range(-maxMovements, maxMovements);

        if(newPosition < 0)
        {
            newPosition += anchorPoints.Count;
        } else if(newPosition >= anchorPoints.Count)
        {
            newPosition -= anchorPoints.Count;
        }

        return anchorPoints[newPosition];
    }

    public Material GetRandomMaterial()
    {
        return materials[Random.Range(0, materials.Length)];
    }
}
