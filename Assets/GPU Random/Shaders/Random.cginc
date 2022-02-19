#include "UnityCG.cginc"

	// Inspired by the Collatz Conjecture
	float GetFixedRandom(float extent, float seed)
	{
		extent = abs(extent);
		seed = abs(seed);

		float multiplier;
		for (int i = 0; i < 2; ++i)
		{
			multiplier = frac(seed);
			seed = (seed * 3 + 1) * multiplier + (1 - multiplier) * seed * 0.5f;
		}
		return seed % extent;
	}

	float GetRandom(float extent, float seed)
	{
		return GetFixedRandom(extent, _Time.y + seed);
	}