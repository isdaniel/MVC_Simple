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
            files.Add(new FakeFile(new FileModel() {
                FileLenght = 1024 * 1024 * 6,
                FileName = "my.jpg"
            }));
            //files.Add(new FakeFile("my.doxds"));
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

    public class FakeFile : HttpPostedFileBase {
        private string _filename;
        private int _filelenght;
        public FakeFile(FileModel model) {
            _filename = model.FileName;
            _filelenght = model.FileLenght;
        }
        public override string FileName
        {
            get
            {
                return _filename;
            }
        }
        public override int ContentLength
        {
            get
            {
                return _filelenght;
            }
        }
    }

    public class FileModel
    {
        public int FileLenght { get; set; }

        public string FileName { get; set; }
    }

}
