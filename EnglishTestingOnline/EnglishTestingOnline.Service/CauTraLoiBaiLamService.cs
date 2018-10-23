    using EnglishTestingOnline.Data.Respositories;
using EnglishTestingOnline.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using EnglishTestingOnline.Data.Infrastructure;

namespace EnglishTestingOnline.Service
{
    public interface ICauTraLoiBaiLamService
    {
        CauTraLoiBaiLam Add(CauTraLoiBaiLam cauTraLoiBaiLam);
        CauTraLoiBaiLam Delete(int id);
        void Update(CauTraLoiBaiLam cauTraLoiBaiLam);
        IEnumerable<CauTraLoiBaiLam> GetAll();
        IEnumerable<CauTraLoiBaiLam> GetAllPaging(int page, int pageSize, out int totalRow);
        IEnumerable<CauTraLoiBaiLam> SearchByName(int keyword, int page, int pageSize, out int totalRow);
        CauTraLoiBaiLam GetById(int id);

        void Save();
    }
    public class CauTraLoiBaiLamService : ICauTraLoiBaiLamService
    {
        private ICauTraLoiBaiLamRepository _cauTraLoiBaiLamRepository;
        private IUnitOfWork _unitOfWork;

        public CauTraLoiBaiLamService(ICauTraLoiBaiLamRepository cauTraLoiBaiLamRepository, IUnitOfWork unitOfWork)
        {
            this._cauTraLoiBaiLamRepository = cauTraLoiBaiLamRepository;
            this._unitOfWork = unitOfWork;
        }

        public CauTraLoiBaiLam Add(CauTraLoiBaiLam cauTraLoiBaiLam)
        {
            return _cauTraLoiBaiLamRepository.Add(cauTraLoiBaiLam);
        }

        public CauTraLoiBaiLam Delete(int id)
        {
            return _cauTraLoiBaiLamRepository.Delete(id);
        }

        public IEnumerable<CauTraLoiBaiLam> GetAll()
        {
            return _cauTraLoiBaiLamRepository.GetAll();
        }

        public CauTraLoiBaiLam GetById(int id)
        {
            return _cauTraLoiBaiLamRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<CauTraLoiBaiLam> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            var query = _cauTraLoiBaiLamRepository.GetAll();
            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<CauTraLoiBaiLam> SearchByName(int keyword, int page, int pageSize, out int totalRow)
        {
            var query = _cauTraLoiBaiLamRepository.GetMulti(c => c.BaiLam_ID.Equals(keyword));
            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public void Update(CauTraLoiBaiLam cauTraLoiBaiLam)
        {
            _cauTraLoiBaiLamRepository.Update(cauTraLoiBaiLam);
        }
    }
}
