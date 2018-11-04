using EnglishTestingOnline.Data.Infrastructure;
using EnglishTestingOnline.Data.Respositories;
using EnglishTestingOnline.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Service
{
    public interface ICauTraLoiTracNghiemService
    {
        CauTraLoiTracNghiem Add(CauTraLoiTracNghiem cauTraLoiTracNghiem);

        CauTraLoiTracNghiem Delete(int id);

        void Update(CauTraLoiTracNghiem cauTraLoiTracNghiem);

        IEnumerable<CauTraLoiTracNghiem> GetAll();
        IEnumerable<CauTraLoiTracNghiem> GetAllPaging(int page, int pageSize, out int totalRow);

        CauTraLoiTracNghiem GetById(int id);
        IEnumerable<CauTraLoiTracNghiem> SearchByName(string keyword, int page, int pageSize, out int totalRow);

        void Save();
    }
    public class CauTraLoiTracNghiemService : ICauTraLoiTracNghiemService
    {
        private ICauTraLoiTracNghiemRepository _cauTraLoiTracNghiemRepository;
        private IUnitOfWork _unitOfWork;
        string[] includes = { "LoaiCauTraLoiTracNghiem", "CauHoi" };

        public CauTraLoiTracNghiemService(ICauTraLoiTracNghiemRepository cauTraLoiTracNghiemRepository, IUnitOfWork unitOfWork)
        {
            this._cauTraLoiTracNghiemRepository = cauTraLoiTracNghiemRepository;
            this._unitOfWork = unitOfWork;
        }
        public CauTraLoiTracNghiem Add(CauTraLoiTracNghiem cauTraLoiTracNghiem)
        {
            return _cauTraLoiTracNghiemRepository.Add(cauTraLoiTracNghiem);
        }

        public CauTraLoiTracNghiem Delete(int id)
        {
            return _cauTraLoiTracNghiemRepository.Delete(id);
        }

        public IEnumerable<CauTraLoiTracNghiem> GetAll()
        {
            return _cauTraLoiTracNghiemRepository.GetAll(includes);
        }
        public IEnumerable<CauTraLoiTracNghiem> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            var query = _cauTraLoiTracNghiemRepository.GetAll(includes);
            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public CauTraLoiTracNghiem GetById(int id)
        {
            return _cauTraLoiTracNghiemRepository.GetSingleById(id);
        }
        public IEnumerable<CauTraLoiTracNghiem> SearchByName(string keyword, int page, int pageSize, out int totalRow)
        {
            var query = _cauTraLoiTracNghiemRepository.GetMulti(c => c.NoiDung.Contains(keyword), includes);
            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(CauTraLoiTracNghiem cauTraLoiTracNghiem)
        {
            _cauTraLoiTracNghiemRepository.Update(cauTraLoiTracNghiem);
        }
    }
}
