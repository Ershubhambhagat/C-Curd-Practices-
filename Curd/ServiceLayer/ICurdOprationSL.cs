using System.Threading.Tasks;
using Curd.CommonLayer.Model;

namespace Curd.ServiceLayer
{
    public interface ICurdOprationSL
    {

        public Task<CreateReacordReasponce> CreateRecord(CreateRecordRequest request);
        public Task<ReadRecord> ReadRecord();
        // Update Record
        public Task<UpdateRecordResponse>updateRecord(UpdateRecordRequest request);
        public Task<DeleteRecordResponse> DeleteRecord (DeleteRecordRequest request);

    }

}
