namespace Curd.CommonLayer.Model
{
    public class DeleteRecordRequest
    {
        public int Id { get; set; }
    }
    public class DeleteRecordResponse
    {
        public string Message { get; set; }  
        public bool IsSucess { get; set; }
    }
}
