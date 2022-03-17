namespace Curd.CommonLayer.Model
{
    public class CreateRecordRequest
    {
        public string Name { get; set; }
        public string age { get; set; }
    }

    public class CreateReacordReasponce 
    {
        public bool Issuccess { get; set; }
        public string Message { get; set; }
    }
}
