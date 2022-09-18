namespace Water;

public static class WaterCollector
{

    public static long CalculateWaterVolume(List<int> heights)
    {
        var sufMax = new List<int>(Enumerable.Repeat(0, heights.Count));
        for (var i = heights.Count - 2; i >= 0; i--)
        {
            sufMax[i] = Math.Max(sufMax[i + 1], heights[i + 1]);
        }

        var volume = 0L;
        var curMax = 0;

        for (var i = 0; i < heights.Count; i++)
        {
            var targetHeight = Math.Min(curMax, sufMax[i]);
            if (targetHeight > heights[i])
            {
                volume += targetHeight - heights[i];
            }

            curMax = Math.Max(curMax, heights[i]);
        }
        
        return volume;
    }

}