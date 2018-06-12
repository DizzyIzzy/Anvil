using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;

public class UnityCoord: MonoBehaviour
{

	[SerializeField]
	AbstractMap _map;

	//Center 33.9425 -118.408056

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Debug.Log ("Q pressed");
			Vector2d latLong = new Vector2d(33.951948, -118.402236);
			Vector2d latLong1 = new Vector2d(33.949028, -118.431064);
			Vector2d latLong2 = new Vector2d(33.936320, -118.426153);
			Vector2d latLong3 = new Vector2d(33.940991, -118.383353);
			Vector2d latLong4 = new Vector2d(33.931410, -118.422255);


		//	Debug.Log("Map Center : " + _map.CenterMercator.ToString());
		//	Debug.Log("Map World Relative Scale : " + _map.WorldRelativeScale.ToString());
		//	Debug.Log("World Position : " + Conversions.GeoToWorldPosition(latLong, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz());


			GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			go.transform.localPosition = Conversions.GeoToWorldPosition(latLong, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();
			go.transform.localPosition += new Vector3 (0, 8, 0);


		

		//	Debug.Log ("Debug1: " + go.transform.localPosition.x + " " + go.transform.localPosition.y + " " + go.transform.localPosition.z);



			GameObject go1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			go1.transform.localPosition = Conversions.GeoToWorldPosition(latLong1, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();

			GameObject go2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			go2.transform.localPosition = Conversions.GeoToWorldPosition(latLong2, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();

			GameObject go3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			go3.transform.localPosition = Conversions.GeoToWorldPosition(latLong3, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();

			GameObject go4 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			go4.transform.localPosition = Conversions.GeoToWorldPosition(latLong4, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();

			

		}
	}




}