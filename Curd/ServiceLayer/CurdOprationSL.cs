using Curd.CommonLayer.Model;
using Curd.RepositryLayer;
using System.Threading.Tasks;

namespace Curd.ServiceLayer
{
    public class CurdOprationSL:ICurdOprationSL
    {
        public readonly ICurdOprationRL _curdOprationRL;

        public CurdOprationSL(ICurdOprationRL CurdOprationRL)
        {
            _curdOprationRL = CurdOprationRL;
        }
        public async Task<CreateReacordReasponce> CreateRecord(CreateRecordRequest request)
        {
            return await _curdOprationRL.CreateRecord(request);


            //Read Record Form Here

        }
        public async Task<ReadRecord> ReadRecord()
        {
            return await _curdOprationRL.ReadRecord();
        }
        // Update recode 
        public async Task<UpdateRecordResponse> updateRecord(UpdateRecordRequest request)
        {
            return await _curdOprationRL.updateRecord(request);
        }
    }
}
 