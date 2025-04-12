using System;
using Microsoft.Xna.Framework;

namespace tetris.Tetrominos;

public abstract class Tetromino
{
    public Point[] Rotation0;
    public Point[] Rotation90;
    public Point[] Rotation180;
    public Point[] Rotation270;

    protected BlockColour Colour;

    public BlockColour GetColour()
    {
        return Colour;
    }

    public Point[] GetPointsFromRotation(ActiveTetrominoRotation rotation)
    {
        switch (rotation)
        {
            case ActiveTetrominoRotation.Zero:
                return Rotation0;
            case ActiveTetrominoRotation.Ninety:
                return Rotation90;
            case ActiveTetrominoRotation.OneEighty:
                return Rotation180;
            case ActiveTetrominoRotation.TwoSeventy:
                return Rotation270;
            default:
                return Rotation0;
        }
    }

    public int GetWidthOfRotation(ActiveTetrominoRotation rotation)
    {
        var points = GetPointsFromRotation(rotation);
        int? minX = null;
        int? maxX = null;
        foreach (var point in points)
        {
            if (minX == null || point.X < minX)
            {
                minX = point.X;
            }

            if (maxX == null || point.X > maxX)
            {
                maxX = point.X;
            }
        }

        if (!maxX.HasValue || !minX.HasValue || maxX.Value < minX.Value)
        {
            throw new Exception("Could not get width of rotation");
        }

        return maxX.Value - minX.Value;
    }
}
