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

        return maxX.Value - minX.Value + 1;
    }

    public int GetLowestXPoint(ActiveTetrominoRotation rotation)
    {
        int? minX = null;
        foreach (var point in GetPointsFromRotation(rotation))
        {
            if (minX == null || point.X < minX)
            {
                minX = point.X;
            }
        }

        if (!minX.HasValue)
        {
            throw new Exception("Could not get lowest x point");
        }
        
        return minX.Value;
    }

    public int GetLowestYPoint(ActiveTetrominoRotation rotation)
    {
        int? minY = null;
        foreach (var point in GetPointsFromRotation(rotation))
        {
            if (minY == null || point.Y < minY)
            {
                minY = point.Y;
            }
            
        }

        if (!minY.HasValue)
        {
            throw new Exception("Could not get lowest y point");
        }

        return minY.Value;
    }

    public int GetHeightOfRotation(ActiveTetrominoRotation rotation)
    {
        var points = GetPointsFromRotation(rotation);
        int? minY = null;
        int? maxY = null;
        foreach (var point in points)
        {
            if (minY == null || point.Y < minY)
            {
                minY = point.Y;
            }

            if (maxY == null || point.Y > maxY)
            {
                maxY = point.Y;
            }
        }

        if (!maxY.HasValue || !minY.HasValue || maxY.Value < minY.Value)
        {
            throw new Exception("Could not get height of rotation");
        }

        return maxY.Value - minY.Value + 1;
    }
}
