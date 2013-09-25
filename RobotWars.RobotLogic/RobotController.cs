using System;

namespace RobotWars.RobotLogic
{
    internal class RobotController:IRobotController
    {
        public MoveType NextMove(MapObject[,] map)
        {
            if(map.GetLength(0) % 2 == 0) throw new ArgumentException();
            if(map.GetLength(1) % 2 == 0) throw new ArgumentException();

            int selfXPosition = map.GetLength(1)/2;
            int selfYPosition = map.GetLength(0)/2;

            for (var i = selfYPosition-1; i >= 0; i--)
            {
                if(map[i, selfXPosition] == MapObject.Enemy)
                    return MoveType.Shoot;
                if(map[i, selfXPosition] == MapObject.Block)
                    return MoveType.TurnLeft;
                if (map[i, selfXPosition] == MapObject.Friend)
                    return MoveType.TurnRight;
            }
            return MoveType.MoveForvard;
        }
    }
}
