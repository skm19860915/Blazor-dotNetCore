using Ortho.Client.Data.ViewModels.DemandInputs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ortho.Client.Data.Services.DemandInputs
{
    /// <summary>
    /// Assay Mapping Service
    /// </summary>
    public class AssayMappingServices : IAssayMappingServices
    {
        public async Task<IEnumerable<PriorityModel>> GetPrioritiesAsync()
        {
            var list = new List<PriorityModel>();
            var record1 = new PriorityModel()
            {
                Id = 1,
                Name = "Urgent",
                State = true
            };
            var record2 = new PriorityModel()
            {
                Id = 2,
                Name = "S",
                State = false
            };
            var record3 = new PriorityModel()
            {
                Id = 3,
                Name = "Routine",
            };

            list.Add(record1);
            list.Add(record2);
            list.Add(record3);

            return await Task.Run(() => list.AsEnumerable());
        }

        public async Task<IEnumerable<MapTypeModel>> GetMapTypesAsync()
        {
            var list = new List<MapTypeModel>();
            var record1 = new MapTypeModel()
            {
                Id = 1,
                Name = "Panel"
            };
            var record2 = new MapTypeModel()
            {
                Id = 2,
                Name = "Assay"
            };
            var record3 = new MapTypeModel()
            {
                Id = 3,
                Name = "OEM"
            };
            list.Add(record1);
            list.Add(record2);
            list.Add(record3);

            return await Task.Run(() => list.AsEnumerable());
        }

        public Task<IEnumerable<MapValueModel>> GetMapValuesAsync()
        {
            var list = new List<MapValueModel>();
            var record1 = new MapValueModel()
            {
                Id = 1,
                Name = "BMP"
            };
            var record2 = new MapValueModel()
            {
                Id = 2,
                Name = "Glucone"
            };
            var record3 = new MapValueModel()
            {
                Id = 3,
                Name = "Assay1"
            };
            var record4 = new MapValueModel()
            {
                Id = 4,
                Name = "Assay2"
            };
            var record5 = new MapValueModel()
            {
                Id = 5,
                Name = "Assay3"
            };
            list.Add(record1);
            list.Add(record2);
            list.Add(record3);
            list.Add(record4);
            list.Add(record5);

            return Task.Run(() => list.AsEnumerable());
        }

        public async Task<IEnumerable<AssayMappingViewModel>> GetAssayMappingListAsync()
        {
            var list = new List<AssayMappingViewModel>();
            var record1 = new AssayMappingViewModel()
            {
                Id = 1,
                AssayName = "BasicMPanel",
                Occurances = 60,
                MappingType = "",
                MappingValue = "",
                SaveToUserMapping = true,
                SaveToGlobalMapping = false
            };
            var record2 = new AssayMappingViewModel()
            {
                Id = 2,
                AssayName = "Glucose",
                Occurances = 20,
                MappingType = "Map to...",
                MappingValue = "Map to...",
                SaveToUserMapping = true,
                SaveToGlobalMapping = true
            };
            var record3 = new AssayMappingViewModel()
            {
                Id = 3,
                AssayName = "Assay1",
                Occurances = 45,
                MappingType = "Map to...",
                MappingValue = "Map to...",
                SaveToUserMapping = false,
                SaveToGlobalMapping = false
            };
            var record4 = new AssayMappingViewModel()
            {
                Id = 4,
                AssayName = "Assay2",
                Occurances = 50,
                MappingType = "Map to...",
                MappingValue = "Map to...",
                SaveToUserMapping = false,
                SaveToGlobalMapping = false
            };
            var record5 = new AssayMappingViewModel()
            {
                Id = 5,
                AssayName = "Assay3",
                Occurances = 20,
                MappingType = "Map to...",
                MappingValue = "Map to...",
                SaveToUserMapping = false,
                SaveToGlobalMapping = false
            };

            list.Add(record1);
            list.Add(record2);
            list.Add(record3);
            list.Add(record4);
            list.Add(record5);

            return await Task.Run(() => list.AsEnumerable());
        }

        public async Task<IEnumerable<string>> GetMapTypeNameListAsync()
        {
            var list = await GetMapTypesAsync();
            var typeNameList = new List<string>();
            foreach (var data in list)
            {
                var name = data.Name;
                typeNameList.Add(name);
            }

            return typeNameList.AsEnumerable();
        }

        public async Task<IEnumerable<string>> GetMapValueNameListAsync()
        {
            var list = await GetMapValuesAsync();
            var valueNameList = new List<string>();
            foreach (var data in list)
            {
                var name = data.Name;
                valueNameList.Add(name);
            }

            return valueNameList.AsEnumerable();
        }
    }
}
