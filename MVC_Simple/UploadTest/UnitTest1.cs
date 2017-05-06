using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryCommon;
using System.Web;
using System.Collections.Generic;

namespace UploadTest
{
    [TestClass]
    public class UnitTest1
    {
        private UploadManage FileCollection() {
            List<HttpPostedFileBase> files = new List<HttpPostedFileBase>();
            files.Add(new FakeFile("my.jpg"));
            //files.Add(new FakeFile("my.doxds"));
            return new UploadManage(files);
        }
        [TestMethod]
        public void FileFilter_Test()
        {
            var m= FileCollection();
            m.SetNext(new FileFilter(FileType.Image));
            bool IsOk=m.Execute();
            Assert.IsTrue(IsOk);
        }
    } 
    public class FakeFile : HttpPostedFileBase {
        private string _filename;
        public FakeFile(string filename) {
            this._filename = filename;
        }
        public override string FileName
        {
            get
            {
                return _filename;
            }
        }
    }
}
