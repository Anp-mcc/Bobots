using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobotWars.RobotLogic.Test
{
    [TestClass]
    public class MapTest
    {
        private static Map _target;

        [TestInitialize]
        public void Init()
        {
            MapObject[,] arr = {{MapObject.RedBot, MapObject.Empty, MapObject.Empty},
                                {MapObject.Empty, MapObject.BlueBot, MapObject.Empty},
                                {MapObject.Block, MapObject.Block, MapObject.Empty}};
            _target = new Map(arr, 1);
        }

        [TestMethod]
        public void GetSubMap_ZeroX_ZeroY_RadiusEquals1()
        {
            MapObject[,] testArr = {{MapObject.Block, MapObject.Block, MapObject.Block},
                                    {MapObject.Block, MapObject.RedBot, MapObject.Empty},
                                    {MapObject.Block, MapObject.Empty, MapObject.BlueBot}};
            MapObject[,] arr = _target.GetSubMap(0, 0);

            Assert.AreEqual(testArr.GetLength(0), arr.GetLength(0));
            Assert.AreEqual(testArr.GetLength(1), arr.GetLength(1));

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.AreEqual(testArr[i, j], arr[i, j]);
        }
    }
}
