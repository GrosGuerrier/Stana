using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRigBehaviour : MonoBehaviour
{
	public new Camera camera;
	public Vector3 startPosition;
	public AnimationCurve YWithSpeed;
	public AnimationCurve ZWithSpeed;
	public float Speed { get; set; }

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		camera.transform.localPosition = transform.localPosition + startPosition + new Vector3(0, YWithSpeed.Evaluate(Speed), ZWithSpeed.Evaluate(Speed));
	}

#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		float max = Mathf.Min(YWithSpeed[YWithSpeed.length - 1].time, ZWithSpeed[ZWithSpeed.length - 1].time);
		for (float i = 0; i < 1; i+= .01f)
		{
			Gizmos.color = Color.Lerp(Color.green, Color.red, i);
			Gizmos.DrawLine(transform.localPosition + startPosition + new Vector3(0, YWithSpeed.Evaluate(i * max), ZWithSpeed.Evaluate(i * max)), transform.localPosition + startPosition + new Vector3(0, YWithSpeed.Evaluate((i + .01f) * max), ZWithSpeed.Evaluate((i + .01f) * max)));
		}
	}
#endif
}
