using System.Threading.Tasks;
using Curd.CommonLayer.Model;

namespace Curd.ServiceLayer
{
    public interface ICurdOprationSL
    {

        public Task<CreateReacordReasponce> CreateRecord(CreateRecordRequest request);
    }
}
