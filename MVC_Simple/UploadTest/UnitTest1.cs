using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryCommon;
using System.Web;
using System.Collections.Generic;
using Moq;

namespace UploadTest
{
    [TestClass]
    public class UnitTest1
    {
        private HttpPostedFileBase fileImg;
        private HttpPostedFileBase fileDoc;

        [TestInitialize]
        public void Init() {
            Mock<HttpPostedFileBase> moqDoc = new Mock<HttpPostedFileBase>();
            moqDoc.Setup(file => file.FileName).Returns("my.doc");
            moqDoc.Setup(file => file.ContentLength).Returns(1024 * 1024 * 3);
            fileDoc = moqDoc.Object;

            Mock<HttpPostedFileBase> moqFile=new Mock<HttpPostedFileBase>();
            moqFile.Setup(file => file.FileName).Returns("my.jpg");
            moqFile.Setup(file => file.ContentLength).Returns(1024 * 1024 * 6);
            fileImg = moqFile.Object;
        }

        private UploadManage FileCollection() {
            List<HttpPostedFileBase> files = new List<HttpPostedFileBase>();
            files.Add(fileImg);
            return new UploadManage(files);
        }

        [TestMethod]
        public void FileFilter_True_Test()
        {
            var m= FileCollection();
            m.SetNext(new FileFilter(FileType.Image));
            bool IsOk=m.Execute();
            Assert.IsTrue(IsOk);
        }

        [TestMethod]
        public void Filelimit_False_Test()
        {
            var m = FileCollection();
            m.SetNext(new Filelimit());
            bool IsOk = m.Execute();
            Assert.IsFalse(IsOk);
        }
    } 
}
