namespace Curd.CommonLayer.Model
{
    public class UpdateRecordRequest
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public int age { get; set; }
    }
    public class UpdateRecordResponse
    {
        public  bool IsSucess { get; set; }
        public string Message { get; set; }
    }
}
