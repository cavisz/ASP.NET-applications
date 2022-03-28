using System;

public class RainStorm
{
    public double EyeRadius { get; protected set; }
    public Tuple<double, double> EyePosition { get; protected set; }
    
    public RainStorm(double eyeRadius, Tuple<double, double> eyePosition)
    {
        this.EyeRadius = eyeRadius;
        this.EyePosition = eyePosition;
    }
    
    public bool IsInEyeOfTheStorm(Tuple<double, double> position)
    {
        double distance = Math.Sqrt(Math.Pow(position.Item1 - EyePosition.Item1, 2) +
                                    Math.Pow(position.Item2 - EyePosition.Item2, 2));
        return distance < EyeRadius;
    }
    
    public double AmountOfRain()
    {
        return EyeRadius * 20;
    }
}

public class SnowStorm
{
    public double EyeRadius { get; protected set; }
    public Tuple<double, double> EyePosition { get; protected set; }
    
    public double AmountOfSnow { get; private set; }
    
    public SnowStorm(double eyeRadius, Tuple<double, double> eyePosition, double amountOfSnow)
    {
        this.EyeRadius = eyeRadius;
        this.EyePosition = eyePosition;
        this.AmountOfSnow = amountOfSnow;
    }
    
    public bool IsInEyeOfTheStorm(Tuple<double, double> position)
    {
        double distance = Math.Sqrt(Math.Pow(position.Item1 - EyePosition.Item1, 2) +
                                    Math.Pow(position.Item2 - EyePosition.Item2, 2));
        return distance < EyeRadius;
    }
}
