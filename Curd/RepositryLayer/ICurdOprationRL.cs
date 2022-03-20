using Curd.CommonLayer.Model;
using System.Threading.Tasks;

namespace Curd.RepositryLayer
{ 
    public interface ICurdOprationRL 
    {
        public Task<CreateReacordReasponce> CreateRecord(CreateRecordRequest request);
        public Task<ReadRecord> ReadRecord();

        //update from here 

       
        public Task<UpdateRecordResponse> updateRecord(UpdateRecordRequest request);
    }
}
