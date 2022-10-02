using SonicBloom.Koreo;
using UnityEngine;

public class BeatRotation : MonoBehaviour
{
	[SerializeField] private float rotation;

	private int lastQuarterNote = 0;
	void Update()
	{
		// The Demo song has a quarter note as it's beat value.  This will get us the current
		//  quarter note!
		int curQuarterNote = Mathf.FloorToInt(Koreographer.GetBeatTime());

		if (curQuarterNote != lastQuarterNote)
		{
			if (lastQuarterNote % 2 != 0)
			{
				transform.rotation = Quaternion.Euler(0, 0, rotation);
			}
			else
			{
				transform.rotation = Quaternion.Euler(0, 0, -rotation);
			}

			lastQuarterNote = curQuarterNote;
		}
	}
}