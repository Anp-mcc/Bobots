namespace RobotWars.RobotLogic
{
    public interface IRobotController
    {
        MoveType NextMove(MapObject[,] map);
    }
}
