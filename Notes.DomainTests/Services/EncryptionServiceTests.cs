using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notes.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Domain.Services.Tests
{
    [TestClass()]
    public class EncryptionServiceTests
    {
        [TestMethod()]
        public void EncryptValueTest()
        {
            EncryptionService EncryptionService = new EncryptionService();
            Assert.AreEqual("098f6bcd4621d373cade4e832627b4f6", EncryptionService.EncryptValue("test"));
        }
    }
}