namespace FleetManagement_MW.Models.Services
{
    public interface ICarTypeMasterRepository
    {
        CarTypeMaster GetCarTypeById(long carTypeId);
        IEnumerable<CarTypeMaster> GetAllCarTypes();
        void AddCarType(CarTypeMaster carType);
        void UpdateCarType(CarTypeMaster carType);
        void RemoveCarType(long carTypeId);

       IEnumerable<CarTypeMaster>  GetCarTypesByHubId(long hubId);
        void SaveChanges();
       
    }
}
