namespace Curd.CommonLayer.Model
{
    public class CreateRecordRequest
    {
        public string UserName { get; set; }
        public int age { get; set; }
    }

    public class CreateReacordReasponce 
    {
        public bool Issuccess { get; set; }
        public string Message { get; set; }
    }
}
