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
    public interface IKyThiSercive
    {
        KyThi Add(KyThi KyThi);
        KyThi Delete(int id);
        void Update(KyThi KyThi);
        KyThi GetById(int id);
        IEnumerable<KyThi> GetAll();
        IEnumerable<KyThi> GetAllPaging(int page, int pageSize, out int totalRow);
        IEnumerable<KyThi> SearchByName(int keyword, int page, int pageSize, out int totalRow);
        void Save();
    }
    public class KyThiService : IKyThiSercive
    {
        private IKyThiRepository _KyThiRepository;
        private IUnitOfWork _unitOfWork;

        public KyThiService(IKyThiRepository KyThiRepository, IUnitOfWork unitOfWork)
        {
            this._KyThiRepository = KyThiRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<KyThi> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            var query = _KyThiRepository.GetAll();
            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<KyThi> SearchByName(int keyword, int page, int pageSize, out int totalRow)
        {
            var query = _KyThiRepository.GetMulti(c => c.ID.Equals(keyword));
            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public KyThi Add(KyThi KyThi)
        {
            return _KyThiRepository.Add(KyThi);
        }

        public KyThi Delete(int id)
        {
            return _KyThiRepository.Delete(id);
        }

        public IEnumerable<KyThi> GetAll()
        {
            return _KyThiRepository.GetAll();
        }

        public KyThi GetById(int id)
        {
            return _KyThiRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(KyThi KyThi)
        {
            _KyThiRepository.Update(KyThi);
        }
    }
}

