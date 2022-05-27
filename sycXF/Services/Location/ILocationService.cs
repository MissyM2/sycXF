using System.Threading.Tasks;

namespace sycXF.Services.Location
{    
    public interface ILocationService
    {
        Task UpdateUserLocation(sycXF.Models.Location.Location newLocReq, string token);
    }
}