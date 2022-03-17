

using Curd.CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Curd.RepositryLayer
{
    
    public class CurdOprationRL : ICurdOprationRL
    {
        public readonly IConfiguration _configuration;
        public readonly SqlConnection _sqlConnection

        public CurdOprationRL(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public Task<CreateReacordReasponce> CreateRecord(CreateRecordRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
