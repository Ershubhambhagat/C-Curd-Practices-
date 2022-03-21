using Curd.CommonLayer.Model;
using System.Threading.Tasks;

namespace Curd.RepositryLayer
{ 
    public interface ICurdOprationRL 
    {
        //Create from here
        public Task<CreateReacordReasponce> CreateRecord(CreateRecordRequest request);

        //Fatch from here 
        public Task<ReadRecord> ReadRecord();

        //update from here 
        public Task<UpdateRecordResponse> updateRecord(UpdateRecordRequest request);

        //Delete from here
        Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request);
    }
}
