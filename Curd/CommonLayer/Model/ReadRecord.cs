using System.Collections.Generic;

namespace Curd.CommonLayer.Model
{
    public class ReadRecord
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<ReadRecordData> readRecordData { get; set; }

    }
    public class ReadRecordData
    {
        public string UserName { get; set; }
        public int age { get; set; }
    }
}
