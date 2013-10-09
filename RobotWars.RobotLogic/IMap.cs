using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotWars.RobotLogic
{
    public interface IMap
    {
        MapObject this[int x, int y] { get; set; }

        MapObject[,] GetSubMap(int x, int y);
        MapObject[,] RotateMatrix(MapObject[,] matrix);
    }
}
