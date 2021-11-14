
public static class StaticTools {

    public static float Map(float fromValue, float fromMin, float fromMax, float toMin, float toMax)
    {
        return (fromValue - fromMin) * (toMax - toMin) / (fromMax - fromMin) + toMin;
    }

    public static string SecondsToFormatedTimeString(float seconds)
    {
        System.TimeSpan t = System.TimeSpan.FromSeconds(seconds);
        return string.Format("{0:D2}:{1:D2}:{2:D2}",
                                t.Hours,
                                t.Minutes,
                                t.Seconds);
    }
}
