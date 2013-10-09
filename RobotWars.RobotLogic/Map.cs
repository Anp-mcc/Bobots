using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotWars.RobotLogic
{
    public class Map : IMap
    {
        private MapObject[,] _arr;

        public int XLength { get; set; }
        public int YLength { get; set; }

        public int VisibleRadius { get; set; }

        public Map(MapObject[,] arr, int visibleRadius)
        {
            VisibleRadius = visibleRadius;
            XLength = arr.GetLength(0);
            YLength = arr.GetLength(1);
            _arr = arr;
        }

        public MapObject this[int x, int y]
        {
            get
            {
                if (x < 0 || y < 0 || x > XLength || y > YLength)
                    return MapObject.Block;
                return _arr[x, y];
            }

            set { _arr[x, y] = value;}
        }

        public MapObject[,] GetSubMap(int x, int y)
        {
           var arr = new List<MapObject>();
           for (int i = -VisibleRadius + x; i <= VisibleRadius + x; i++)
               for (int j = -VisibleRadius + y; j <= VisibleRadius + y; j++)
                       arr.Add(this[i, j]);
            
           return ListToArr(arr, VisibleRadius*2 + 1);
        }

        static MapObject[,] ListToArr(List<MapObject> list, int size)
        {
            var resArr = new MapObject[size, size];
            int index = 0;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    resArr[i, j] = list[index];
                    index++;
                }
            return resArr;
        }

        public MapObject[,] RotateMatrix(MapObject[,] matrix)
        {
            MapObject[,] ret = new MapObject[XLength, YLength];

            for (int i = 0; i < XLength; ++i)
            {
                for (int j = 0; j < YLength; ++j)
                {
                    ret[i, j] = matrix[XLength - j - 1, i];
                }
            }

            return ret;
        }

    }
}
