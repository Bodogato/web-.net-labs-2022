using NUnit.Framework;
using OwnDictionary.Models;

namespace OwnDictionary.Tests
{
    public class Tests
    {
        [Test]
        public void AddToDictionary_IncreaseSize()
        {
            var dict = new OwnDictionary<string, string>();
            int sizeStart = dict.Count;
            dict.Add("name", "ben");
            Assert.AreEqual(1, dict.Count);
            Assert.AreEqual(0, sizeStart);
        }

        [Test]
        public void DeleteFromDictionary_DecreaseSize()
        {
            var dict = new OwnDictionary<string, string>();
            dict.Add("name", "ben");
            int sizeAfterAdd = dict.Count;

            dict.Remove("name");
            Assert.AreEqual(0, dict.Count);
            Assert.AreEqual(1, sizeAfterAdd);
        }

        [Test]
        public void ClearDictionary_SizeToNull()
        {
            var dict = new OwnDictionary<string, string>();
            dict.Add("name", "ben");
            dict.Remove("name");
            dict.Clear();
            Assert.AreEqual(0, dict.Count);
        }

        [Test]
        public void GetValueFromDictionary_ReturnTrue()
        {
            var dict = new OwnDictionary<string, string>();
            dict.Add("name", "ben");
            Assert.IsTrue(dict.ContainsKey("name"));
        }

        [Test]
        public void GetValueFromDictionary_ReturnFalse()
        {
            var dict = new OwnDictionary<string, string>();
            dict.Add("name", "ben");
            Assert.IsFalse(dict.ContainsKey("namewww"));
        }

        [Test]
        public void TryGetValue_ReturnObject()
        {
            var dict = new OwnDictionary<string, string>();
            dict.Add("name", "ben");
            string obj;
            dict.TryGetValue("name", out obj);
            Assert.IsNotNull(obj);
        }
    }
}