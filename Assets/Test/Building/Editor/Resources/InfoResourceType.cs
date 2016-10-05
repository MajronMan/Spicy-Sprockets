using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using NSubstitute;
using System.IO;
using GameControllers;
using Assets.Scripts.Resources;
using System.Xml.Linq;

namespace Assets.Test.Building.Editor.Resources
{
    class InfoResourceTypeTestCase
    {
        Info info;
        GameObject testGameObject;
        string path;

        [Test]
        public void TestInfo()
        {
            SetUp();
            CheckLoadsTypesFromXML();
            CheckCreatesResources();
        }

        private void SetUp()
        {
            testGameObject = new GameObject("Game Controller", typeof(GameController));
            var testGameController = testGameObject.GetComponent<GameController>();
            var mapGameObject = new GameObject("map", typeof(Map));
            var mapPrefab = mapGameObject.GetComponent<Map>();
            testGameController.MapPrefab = mapPrefab;
            testGameController.Start();
            path = Directory.GetCurrentDirectory() + @"\Assets\Test\Building\Editor\Resources\TestTypes.xml";
            info = new Info(path);
        }

        private void CheckLoadsTypesFromXML()
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
            CollectionAssert.AreEquivalent(expectedTypes, info.ResourceTypes.Data);
        }

        private void CheckCreatesResources()
        {
            var expectedResources = new Dictionary<string, Resource>()
            {
                { "a", new Resource("a", 1, Quality.Lux, info) },
                { "b", new Resource("b", 2, Quality.Lux, info) },
                { "c", new Resource("c", 3, Quality.Lux, info) },
                { "d", new Resource("d", 4, Quality.Lux, info) }
            };
            foreach(var key in expectedResources.Keys)
                Assert.AreEqual(expectedResources[key].ToString(), info.Resources[key].ToString());
        }
    }
}
