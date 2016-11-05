using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Interface;
using Assets.Scripts.Resources;
using Assets.Scripts.Utils;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Test.Editor.Resources
{
    public class InfoResourceTypeTestCase
    {
        private GameData _gameData;
        private GameObject _testGameObject;
        private string _path;

        [Test]
        public void TestInfo()
        {
            SetUp();
            CheckLoadsTypesFromXml();
            CheckCreatesResources();
        }

        [Test]
        public void TestLimits()
        {
            
        }

        private void SetUp()
        {
            _path = Directory.GetCurrentDirectory() + @"\Assets\Test\Editor\Resources\TestTypes.xml";
            _gameData = new GameData(_path);
        }

        private void CheckLoadsTypesFromXml()
        {
            var expectedTypes = new Dictionary<string, Dictionary<string, string>>()
            {
                {"a", new Dictionary<string, string>(){
                                                        { "mass", "1" },
                                                        { "volume", "1" },
                                                        { "price", "1" },
                                                        { "initial", "1" }
                                                      }
                },
                {"b", new Dictionary<string, string>(){
                                                        { "mass", "2" },
                                                        { "volume", "2" },
                                                        { "price", "2" },
                                                        { "initial", "2" }
                                                      }
                },
                {"c", new Dictionary<string, string>(){
                                                        { "mass", "3" },
                                                        { "volume", "3" },
                                                        { "price", "3" },
                                                        { "initial", "3" }
                                                      }
                },
                {"d", new Dictionary<string, string>(){
                                                        { "mass", "4" },
                                                        { "volume", "4" },
                                                        { "price", "4" },
                                                        { "initial", "4" }
                                                      }
                }
            };
            CollectionAssert.AreEquivalent(expectedTypes, _gameData.ResourceTypes);
        }

        private void CheckCreatesResources()
        {
            var expectedResources = new Dictionary<string, Resource>()
            {
                { "a", new Resource("a", 1) },
                { "b", new Resource("b", 2) },
                { "c", new Resource("c", 3) },
                { "d", new Resource("d", 4) }
            };
            foreach(var key in expectedResources.Keys)
                Assert.AreEqual(expectedResources[key].ToString(), Controllers.CurrentInfo.Resources[key].ToString());
        }
    }
}
