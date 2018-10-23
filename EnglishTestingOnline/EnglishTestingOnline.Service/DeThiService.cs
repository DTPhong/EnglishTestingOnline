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
    public interface IDeThiSercive
    {
        DeThi Add(DeThi DeThi);
        DeThi Delete(int id);
        void Update(DeThi DeThi);
        DeThi GetById(int id);
        IEnumerable<DeThi> GetAll();
        IEnumerable<DeThi> GetAllPaging(int page, int pageSize, out int totalRow);
        IEnumerable<DeThi> SearchByName(int keyword, int page, int pageSize, out int totalRow);
        void Save();
    }
    public class DeThiService : IDeThiSercive
    {
        private IDeThiRepository _DeThiRepository;
        private IUnitOfWork _unitOfWork;

        public DeThiService(IDeThiRepository DeThiRepository, IUnitOfWork unitOfWork)
        {
            this._DeThiRepository = DeThiRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<DeThi> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            var query = _DeThiRepository.GetAll();
            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<DeThi> SearchByName(int keyword, int page, int pageSize, out int totalRow)
        {
            var query = _DeThiRepository.GetMulti(c => c.ID.Equals(keyword));
            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public DeThi Add(DeThi DeThi)
        {
            return _DeThiRepository.Add(DeThi);
        }

        public DeThi Delete(int id)
        {
            return _DeThiRepository.Delete(id);
        }

        public IEnumerable<DeThi> GetAll()
        {
            return _DeThiRepository.GetAll();
        }

        public DeThi GetById(int id)
        {
            return _DeThiRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(DeThi DeThi)
        {
            _DeThiRepository.Update(DeThi);
        }
    }
}

